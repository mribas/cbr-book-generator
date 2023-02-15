using System.Diagnostics.CodeAnalysis;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Net.NetworkInformation;

using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.PixelFormats;

using static System.Net.Mime.MediaTypeNames;

namespace Renamer
{
    public class AjustarAqruivos
    {
        public void Executar(
                string diretorioInicial,
                bool pesquisarSubDiretorios,
                bool converterJPG,
                bool ajustarAspectRatio,
                int? alturaMinima,
                string? destinyDirectory,
                string? ignoreImageName,
                Action<string, System.Drawing.Color> gravarLog
            )
        {
            if(!converterJPG &&
                !ajustarAspectRatio &&
                !alturaMinima.HasValue)
            {
                gravarLog($@"     <ajustes>", System.Drawing.Color.MistyRose);
                gravarLog($@"          <executar>false</executar>", System.Drawing.Color.Red);
                GravaLogFechamentoTagPrincipal(gravarLog: gravarLog);
                return;
            }

            var files = pesquisarSubDiretorios
                ? Directory.GetFiles(diretorioInicial, "*.*", SearchOption.AllDirectories).ToList()
                : Directory.GetFiles(diretorioInicial).ToList();

            if (!string.IsNullOrWhiteSpace(ignoreImageName))
            {
                files.Where(w => w.Contains(ignoreImageName.Trim())).ToList()
                    .ForEach(f =>
                    {
                        files.Remove(f);
                    });
            }

            var filesPng = files?.Where(w => w.ToLower().EndsWith(".png") && (converterJPG || alturaMinima.HasValue))?.OrderBy(o => o)?.ToList();
            var filesGif = files?.Where(w => w.ToLower().EndsWith(".gif") && (converterJPG || alturaMinima.HasValue))?.OrderBy(o => o)?.ToList();
            var filesWebp = files?.Where(w => w.ToLower().EndsWith(".webp") && (converterJPG || alturaMinima.HasValue))?.OrderBy(o => o)?.ToList();
            var filesJpg = files?.Where(w => w.ToLower().EndsWith(".jpg") && (ajustarAspectRatio || alturaMinima.HasValue))?.OrderBy(o => o)?.ToList();
            var filesJpeg = files?.Where(w => w.ToLower().EndsWith(".jpeg") && (converterJPG || alturaMinima.HasValue))?.OrderBy(o => o)?.ToList();
            var filesImg = files?.Where(w => w.ToLower().EndsWith(".img") && (converterJPG || alturaMinima.HasValue))?.OrderBy(o => o)?.ToList();

            if (
                files?.Any() != true || (
                    filesPng?.Any() != true && 
                    filesGif?.Any() != true && 
                    filesJpeg?.Any() != true && 
                    filesImg?.Any() != true && 
                    filesWebp?.Any() != true && 
                    filesJpg?.Any() != true
                    )
                )
            {
                gravarLog($@"     <ajustes totalArquivos='0' />", System.Drawing.Color.MistyRose);
                return;
            }

            var allFiles = new List<string>();
            allFiles.AddRange(filesPng ?? new List<string>());
            allFiles.AddRange(filesGif ?? new List<string>());
            allFiles.AddRange(filesWebp ?? new List<string>());
            allFiles.AddRange(filesJpg ?? new List<string>());
            allFiles.AddRange(filesJpeg ?? new List<string>());
            allFiles.AddRange(filesImg ?? new List<string>());

            if(allFiles.Count() != files.Count)
            {
                gravarLog($@"     <ajustes>", System.Drawing.Color.MistyRose);
                gravarLog($@"          <executar>false</executar>", System.Drawing.Color.Red);
                gravarLog($@"          <mensagem>Existem arquivos não podem ser ajustados!</mensagem>", System.Drawing.Color.LightPink);
                GravaLogFechamentoTagPrincipal(gravarLog: gravarLog);
                return;
            }

            gravarLog($@"     <ajustes totalArquivos='{allFiles.Count()}'>", System.Drawing.Color.MistyRose);
            gravarLog($@"          <executar>true</executar>", System.Drawing.Color.Red);

            var currentDirectory = string.Empty;
            var jpeg = 0;
            var jpg = 0;
            var gif = 0;
            var png = 0;
            var img = 0;
            var webp = 0;

            var countFiles = 0;

            foreach (var file in allFiles.OrderBy(o => o))
            {
                var tempDirectory = new DirectoryInfo(Directory.GetParent(file)!.FullName).Name;

                if(!string.IsNullOrWhiteSpace(destinyDirectory) && tempDirectory.ToLower() == destinyDirectory.ToLower())
                {
                    tempDirectory = new DirectoryInfo(Directory.GetParent(Directory.GetParent(file)!.FullName)!.FullName).Name;
                }

                if(currentDirectory != tempDirectory)
                {
                    if(!string.IsNullOrWhiteSpace(currentDirectory))
                    {
                        GravarLogFechamentoTagImagens(
                                jpeg: ref jpeg,
                                jpg: ref jpg,
                                gif: ref gif,
                                png: ref png,
                                img: ref img,
                                webp: ref webp,
                                currentDirectory: currentDirectory,
                                gravarLog: gravarLog
                            );
                    }

                    if (currentDirectory != tempDirectory)
                    {
                        currentDirectory = tempDirectory;
                        gravarLog($@"          <{tempDirectory}>", System.Drawing.Color.LightGreen);
                    }
                }

                switch(Path.GetExtension(file).ToLower())
                {
                    case ".jpeg":
                        jpeg++;
                        break;
                    case ".jpg":
                        jpg++;
                        break;
                    case ".gif":
                        gif++;
                        break;
                    case ".png":
                        png++;
                        break;
                    case ".img":
                        img++;
                        break;
                    case ".webp":
                        webp++;
                        break;
                }

                SaveAs(
                        filePath: file,
                        ajustarAspectRatio: ajustarAspectRatio,
                        alturaMinima: alturaMinima
                    );

                countFiles++;

                if(countFiles == allFiles.Count())
                {
                    GravarLogFechamentoTagImagens(
                                jpeg: ref jpeg,
                                jpg: ref jpg,
                                gif: ref gif,
                                png: ref png,
                                img: ref img,
                                webp: ref webp,
                                currentDirectory: currentDirectory,
                                gravarLog: gravarLog
                            );
                }

                File.Delete(file);
            }

            GravaLogFechamentoTagPrincipal(gravarLog: gravarLog);
        }

        private void SaveAs(
                string filePath,
                bool ajustarAspectRatio,
                int? alturaMinima
            )
        {
            var deleteTempFile = false;

            if(filePath.ToLower().Contains(".webp"))
            {
                deleteTempFile = true;

                var tempFilePath = SaveWebpAsJpeg(
                        filePath: filePath,
                        alturaMinima: alturaMinima
                    );

                if (deleteTempFile)
                {
                    File.Delete(filePath);
                }

                if (!alturaMinima.HasValue)
                {
                    return;
                }

                filePath = tempFilePath;
            }

            if(filePath.ToLower().Contains(".jpeg") && !ajustarAspectRatio && !alturaMinima.HasValue)
            {
                File.Move(filePath, filePath.Replace(".jpeg", ".jpg"));
                return;
            }

            var color = GetBackgroundColorByImageExtension(filePath);

            using var img = System.Drawing.Image.FromFile(filePath);

            var width = 0;
            var height = 0;
            var resolucaoVertical = 0f;
            var resolucaoHorizontal = 0f;

            if (alturaMinima.HasValue && img.Height < alturaMinima.Value)
            {
                var fator = (float)alturaMinima.Value / (float)img.Height;

                width = (int)(img.Width * fator);
                height = (int)(img.Height * fator);

                resolucaoHorizontal = img.HorizontalResolution * fator; 
                resolucaoVertical = (ajustarAspectRatio ? img.HorizontalResolution : img.VerticalResolution) * fator;
            }
            else
            {
                width = img.Width;
                height = img.Height;

                resolucaoHorizontal = img.HorizontalResolution;
                resolucaoVertical = ajustarAspectRatio ? img.HorizontalResolution : img.VerticalResolution;
            }

            using var newImg = new Bitmap(width, height);

            newImg.SetResolution(resolucaoHorizontal, resolucaoVertical);

            using var graphics = Graphics.FromImage(newImg);
            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.CompositingMode = CompositingMode.SourceCopy;
            graphics.SmoothingMode = SmoothingMode.HighQuality;

            graphics.Clear(color);
            graphics.DrawImage(img, new System.Drawing.Rectangle(0, 0, newImg.Width, newImg.Height));

            EncoderParameter qualityParam = new EncoderParameter(Encoder.Quality, 100L);
            ImageCodecInfo? jpegCodec = ImageCodecInfo.GetImageEncoders().Where(w => w.MimeType == "image/jpeg").FirstOrDefault();
            EncoderParameters encoderParams = new EncoderParameters(1);
            encoderParams.Param[0] = qualityParam;

            var nomeArquivo = Path.GetFileNameWithoutExtension(filePath).PadLeft(4, '0');
            var dirPai = Directory.GetParent(filePath)!.FullName;
            var newFilePath = File.Exists($@"{dirPai}\{nomeArquivo}.jpg")
                            ? $@"{dirPai}\{nomeArquivo}-1.jpg"
                            : $@"{dirPai}\{nomeArquivo}.jpg";

            newImg.Save(newFilePath, jpegCodec, encoderParams);

            graphics.Dispose();
            newImg.Dispose();

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private string SaveWebpAsJpeg(
                string filePath,
                int? alturaMinima
            )
        {
            using var img = SixLabors.ImageSharp.Image.Load(filePath);

            var nomeSemExtensao = Path.GetFileNameWithoutExtension(filePath).PadLeft(4, '0');

            var nomeArquivo = alturaMinima.HasValue
                                ? $@"{nomeSemExtensao}-webp"
                                : nomeSemExtensao;
            var dirPai = Directory.GetParent(filePath)!.FullName;

            var newFilePath = File.Exists($@"{dirPai}\{nomeArquivo}.jpg")
                            ? $@"{dirPai}\{nomeArquivo}-1.jpg"
                            : $@"{dirPai}\{nomeArquivo}.jpg";

            img.SaveAsJpeg(newFilePath);

            img.Dispose();

            GC.Collect();
            GC.WaitForPendingFinalizers();

            return newFilePath;
        }

        private void GravarLogFechamentoTagImagens(
                ref int jpeg,
                ref int jpg,
                ref int gif,
                ref int png,
                ref int img,
                ref int webp,
                string currentDirectory,
                Action<string, System.Drawing.Color> gravarLog
            )
        {
            gravarLog($@"               <jpeg>{jpeg}</jpeg>", jpeg > 0 ? System.Drawing.Color.Yellow : System.Drawing.Color.Gray);
            gravarLog($@"               <jpg>{jpg}</jpg>", jpg > 0 ? System.Drawing.Color.Yellow : System.Drawing.Color.Gray);
            gravarLog($@"               <gif>{gif}</gif>", gif > 0 ? System.Drawing.Color.Yellow : System.Drawing.Color.Gray);
            gravarLog($@"               <png>{png}</png>", png > 0 ? System.Drawing.Color.Yellow : System.Drawing.Color.Gray);
            gravarLog($@"               <img>{img}</img>", img > 0 ? System.Drawing.Color.Yellow : System.Drawing.Color.Gray);
            gravarLog($@"               <webp>{webp}</webp>", webp > 0 ? System.Drawing.Color.Yellow : System.Drawing.Color.Gray);
            gravarLog($@"          </{currentDirectory}>", System.Drawing.Color.LightGreen);

            jpeg = 0;
            jpg = 0;
            gif = 0;
            png = 0;
            img = 0;
            webp = 0;
        }

        private System.Drawing.Color GetBackgroundColorByImageExtension(
                string filePath
            )
        {
            var ext = Path.GetExtension(filePath).ToLower();

            return ext switch
            {
                ".png" => System.Drawing.Color.White,
                _ => System.Drawing.Color.Black,
            };
        }

        private void GravaLogFechamentoTagPrincipal(
                Action<string, System.Drawing.Color> gravarLog
            )
        {
            gravarLog($@"     </ajustes>", System.Drawing.Color.MistyRose);
        }
    }
}
