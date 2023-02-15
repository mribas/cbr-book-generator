using System.Diagnostics.CodeAnalysis;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace Renamer
{
    public class SepararPaginas
    {
        public void Executar(
                string diretorioInicial,
                bool pesquisarSubDiretorios,
                string subDiretorio,
                bool leituraPadraoOcidental,
                string diretorioDestino,
                Action<string, Color> gravarLog
            )
        {
            gravarLog($@"INICIO DO PROCESSO DE SEPARAÇÃO OS ARQUIVOS." + Environment.NewLine, System.Drawing.Color.GreenYellow);

            var diretorios = pesquisarSubDiretorios
                                ? Directory.GetDirectories(diretorioInicial, subDiretorio, SearchOption.AllDirectories).OrderBy(o => o).ToList()
                                : Directory.GetDirectories($@"{diretorioInicial}\{subDiretorio}").OrderBy(o => o).ToList();

            List<string> files = new List<string>();

            foreach(var dir in diretorios)
            {
                var filesPerDirectory = Directory.GetFiles(dir, "*.*").ToList();

                if(filesPerDirectory?.Any() == true)
                {
                    files.AddRange(filesPerDirectory);
                }
            }

            if (!files.Any())
            {
                gravarLog("Separação não realizada. Nenhum arquivo foi encontrado!", Color.Red);
                gravarLog($@"PROCESSO DE SEPARAÇÃO FINALIZADO SEM AÇÃO PARA: '{diretorioInicial.ToUpper()}'" + Environment.NewLine + Environment.NewLine + Environment.NewLine, Color.Green);
                return;
            }

            var diretoriosParaUnificacao = new List<string>();
            var diretoriosComFalhas = new List<string>();
            var diretoriosParaExclusao = new List<string>();

            foreach (var file in files.OrderBy(o => o))
            {
                var diretorioParente = Directory.GetParent(file)!.FullName;

                if (!diretoriosParaUnificacao.Contains(diretorioParente))
                {
                    var paginas = Directory.GetFiles(diretorioParente);

                    if (paginas.Where(w => !(w.ToLower().EndsWith(".jpg") || w.ToLower().EndsWith(".jpeg"))).Any())
                    {
                        diretoriosComFalhas.Add(diretorioParente);
                        gravarLog($@"Separação não realizada para o diretório: '{diretorioParente}'. Existem arquivos inválidos no diretório!", Color.Red);
                    }
                }
            }

            gravarLog(Environment.NewLine, Color.Red);

            foreach (var file in files)
            {
                if (diretoriosComFalhas.Contains(Directory.GetParent(file)!.FullName))
                {
                    continue;
                }

                using var img = System.Drawing.Image.FromFile(file);

                var width = Convert.ToInt32(img.Width / 2);
                var height = img.Height;

                using var splited1 = new Bitmap(width, height);
                splited1.SetResolution(img.HorizontalResolution, img.VerticalResolution);

                using var splited2 = new Bitmap(width, height);
                splited2.SetResolution(img.HorizontalResolution, img.VerticalResolution);

                using var graphics1 = Graphics.FromImage(splited1);
                graphics1.CompositingQuality = CompositingQuality.HighQuality;
                graphics1.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics1.CompositingMode = CompositingMode.SourceCopy;
                graphics1.SmoothingMode = SmoothingMode.HighQuality;

                graphics1.Clear(System.Drawing.Color.White);
                graphics1.DrawImage(img, new System.Drawing.Rectangle(0, 0, img.Width, height));

                using var graphics2 = Graphics.FromImage(splited2);
                graphics2.CompositingQuality = CompositingQuality.HighQuality;
                graphics2.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics2.CompositingMode = CompositingMode.SourceCopy;
                graphics2.SmoothingMode = SmoothingMode.HighQuality;

                graphics2.Clear(System.Drawing.Color.White);
                graphics2.DrawImage(img, 0, 0,new Rectangle((img.Width - width), 0, width, height), GraphicsUnit.Pixel);

                var nomeArquivo = Path.GetFileName(file);
                string? diretorioCompletoDestino = null;
                var dirPai = Directory.GetParent(file)!.FullName;

                if (!string.IsNullOrEmpty(diretorioDestino))
                {
                    var dirAvo = Directory.GetParent(dirPai)!.FullName;

                    if(!diretoriosParaExclusao.Contains(dirPai) && dirPai.ToLower() != $@"{dirAvo.ToLower()}\{diretorioDestino.Trim().ToLower()}")
                    {
                        diretoriosParaExclusao.Add(dirPai);
                    }

                    diretorioCompletoDestino = $@"{dirAvo.ToLower()}\{diretorioDestino.Trim().ToLower()}";
                }

                if(string.IsNullOrWhiteSpace(diretorioCompletoDestino))
                {
                    diretorioCompletoDestino = $@"{dirPai.ToLower()}";
                }

                if(!Directory.Exists(diretorioCompletoDestino))
                {
                    Directory.CreateDirectory(diretorioCompletoDestino);
                }

                var extensao = Path.GetExtension(file);

                var file01Sufix = ".1";
                var file02Sufix = ".2";

                if (!leituraPadraoOcidental)
                {
                    file01Sufix = ".2";
                    file02Sufix = ".1";
                }

                splited1.Save($@"{diretorioCompletoDestino.ToLower()}\{nomeArquivo.Replace(extensao, string.Empty)}{file01Sufix}{extensao}", ImageFormat.Jpeg);
                splited2.Save($@"{diretorioCompletoDestino.ToLower()}\{nomeArquivo.Replace(extensao, string.Empty)}{file02Sufix}{extensao}", ImageFormat.Jpeg);
                graphics1.Dispose();
                splited1.Dispose();

                img.Dispose();

                GC.Collect();
                GC.WaitForPendingFinalizers();
            }

            GC.Collect();
            GC.WaitForPendingFinalizers();

            foreach (var dir in diretoriosParaExclusao)
            {
                if(Directory.Exists(dir))
                {
                    Directory.Delete(dir, true);
                    gravarLog($@"Diretório '{dir}' excluído!", Color.Red);
                }
            }

            gravarLog(Environment.NewLine, Color.Red);

            if (string.IsNullOrWhiteSpace(diretorioDestino))
            {
                for (int i = 0; i < files.Count(); i++)
                {
                    if (diretoriosComFalhas.Contains(Directory.GetParent(files[i])!.FullName))
                    {
                        continue;
                    }

                    if (File.Exists(files[i]))
                    {
                        File.Delete(files[i]);
                        gravarLog($@"Arquivo '{files[i]}' excluído!", Color.Red);
                    }
                }
            }

            gravarLog($@"PROCESSO DE SEPARAÇÃO DOS ARQUIVOS FINALIZADO PARA: '{diretorioInicial.ToUpper()}'" + Environment.NewLine + Environment.NewLine + Environment.NewLine, Color.Green);
        }
    }
}
