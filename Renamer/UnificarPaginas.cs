using System.Diagnostics.CodeAnalysis;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace Renamer
{
    public class UnificarPaginas
    {
        public void Executar(
                string diretorioInicial,
                bool pesquisarSubDiretorios,
                string subDiretorio,
                bool leituraPadraoOcidental,
                string diretorioDestino
            )
        {

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
                MessageBox.Show("Unificação não realizada. Nenhum arquivo foi encontrado!");
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

                    if(paginas.Count() % 2 != 0)
                    {
                        diretoriosComFalhas.Add(diretorioParente);
                    }
                    else if (paginas.Where(w => !(w.ToLower().EndsWith(".jpg") || w.ToLower().EndsWith(".jpeg"))).Any())
                    {
                        diretoriosComFalhas.Add(diretorioParente);
                    }
                }
            }

            if(diretoriosComFalhas.Any())
            {
                MessageBox.Show($@"Unificação não realizada!{Environment.NewLine}Quantidade de imagens impares encontrada nos seguintes diretórios:{Environment.NewLine}{string.Join(Environment.NewLine, diretoriosComFalhas)}");
            }

            for (int i = 0; i < files.Count();)
            {
                if (diretoriosComFalhas.Contains(Directory.GetParent(files[i])!.FullName))
                {
                    continue;
                }

                var idxImagem0 = leituraPadraoOcidental ? 0 : 1;
                var idxImagem1 = leituraPadraoOcidental ? 1 : 0;

                using var img1 = System.Drawing.Image.FromFile(files[i + idxImagem0]);
                using var img2 = System.Drawing.Image.FromFile(files[i + idxImagem1]);

                var height = Math.Max(img1.Height, img2.Height);

                using var imgResized1 = Resize(img1, height);
                using var imgResized2 = Resize(img2, height);

                using var resized = new Bitmap(Convert.ToInt32(imgResized1.Width + imgResized2.Width), height);
                resized.SetResolution(imgResized1.HorizontalResolution, imgResized1.VerticalResolution);

                using var graphics = Graphics.FromImage(resized);
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.SmoothingMode = SmoothingMode.HighQuality;

                graphics.Clear(System.Drawing.Color.White);
                graphics.DrawImage(imgResized1, new System.Drawing.Rectangle(0, 0, imgResized1.Width, height));
                graphics.DrawImage(imgResized2, new System.Drawing.Rectangle(imgResized1.Width, 0, imgResized2.Width, height));

                var nomePrimeiroArquivo = Path.GetFileName(files[i]);
                string? diretorioCompletoDestino = null;
                var dirPai = Directory.GetParent(files[i])!.FullName;

                if (!string.IsNullOrEmpty(diretorioDestino))
                {
                    var dirAvo = Directory.GetParent(dirPai)!.FullName;

                    if(!diretoriosParaExclusao.Contains(dirPai) && dirPai.ToLower() != $@"{dirAvo.ToLower()}\{diretorioDestino.Trim().ToLower()}")
                    {
                        diretoriosParaExclusao.Add(dirPai);
                    }

                    diretorioCompletoDestino = $@"{dirAvo.ToLower()}\{diretorioDestino.Trim().ToLower()}\{nomePrimeiroArquivo}";
                }

                if(string.IsNullOrWhiteSpace(diretorioCompletoDestino))
                {
                    var extensao = Path.GetExtension(files[i]);
                    diretorioCompletoDestino = $@"{dirPai.ToLower()}\{nomePrimeiroArquivo.Replace(extensao, string.Empty)}-01{extensao}";
                }

                resized.Save(diretorioCompletoDestino, ImageFormat.Jpeg);
                graphics.Dispose();
                resized.Dispose();

                img1.Dispose();
                img2.Dispose();

                GC.Collect();
                GC.WaitForPendingFinalizers();

                i += 2;
            }

            GC.Collect();
            GC.WaitForPendingFinalizers();

            foreach (var dir in diretoriosParaExclusao)
            {
                if(Directory.Exists(dir))
                {
                    Directory.Delete(dir, true);
                }
            }

            if(string.IsNullOrWhiteSpace(diretorioDestino))
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
                    }
                }
            }

            MessageBox.Show("Unificação Finalizada!");
        }

        private System.Drawing.Image Resize([NotNull] System.Drawing.Image imgOriginal, int height)
        {
            if (imgOriginal.Height < height)
            {
                var width = ((imgOriginal.Width * height) / imgOriginal.Height);

                var destRect = new Rectangle(0, 0, width, height);
                var destImage = new Bitmap(width, height);

                destImage.SetResolution(imgOriginal.HorizontalResolution, imgOriginal.VerticalResolution);

                using (var graphics = Graphics.FromImage(destImage))
                {
                    graphics.CompositingMode = CompositingMode.SourceCopy;
                    graphics.CompositingQuality = CompositingQuality.HighQuality;
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.SmoothingMode = SmoothingMode.HighQuality;
                    graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                    using var wrapMode = new ImageAttributes();
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(imgOriginal, destRect, 0, 0, imgOriginal.Width, imgOriginal.Height, GraphicsUnit.Pixel, wrapMode);
                }

                return destImage;
            }

            return imgOriginal;
        }
    }
}
