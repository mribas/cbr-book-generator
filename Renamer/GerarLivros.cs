using Renamer.Entidades;

using System.Diagnostics.CodeAnalysis;
using System.IO.Compression;
using System.Xml.Serialization;

namespace Renamer
{
    public class GerarLivros
    {
        public void Executar(
                string diretorioInicial,
                bool pesquisarSubDiretorios,
                string subDiretorio,
                string? nomeArquivoCapa,
                bool utilizarMetadados,
                bool apagarArquivosOriginais,
                bool gerarCbz,
                bool gerarEpub,
                string? diretorioDestino,
                string? ignoreImageName,
                Action<string, Color> gravarLog
            )
        {
            if (!gerarCbz && !gerarEpub)
            {
                gravarLog($@"     <geração>", Color.Coral);
                gravarLog($@"          <executar>false</executar>", Color.Red);
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
            
            if (!string.IsNullOrWhiteSpace(nomeArquivoCapa))
            {
                files.Where(w => w.Contains(nomeArquivoCapa.Trim())).ToList()
                    .ForEach(f =>
                    {
                        files.Remove(f);
                    });
            }

            if (files?.Any() != true)
            {
                gravarLog($@"     <geração totalLivros='0' />", Color.Coral);
                return;
            }

            if (files.Where(w => Path.GetExtension(w).ToLower() != ".jpg").Any())
            {
                gravarLog($@"     <geração>", Color.Coral);
                gravarLog($@"          <executar>false</executar>", Color.Red);
                gravarLog($@"          <mensagem>Existem arquivos não ajustados!</mensagem>", Color.LightPink);
                GravaLogFechamentoTagPrincipal(gravarLog: gravarLog);
                return;
            }

            var imagesDirectories = files
                                .Select(s => Directory.GetParent(s)!.FullName)
                                .Distinct()
                                .OrderBy(o => o)
                                .ToList();

            string? currentDirectory = null;
            var countDirectories = 0;
            string indentity = string.Empty;

            gravarLog($@"     <geração>", Color.Coral);
            gravarLog($@"          <executar>true</executar>", Color.Red);

            foreach (var diretorio in imagesDirectories)
            {
                var nomeArquivo = string.Empty;
                Metadados? metadados = null;

                var diretorioVolume = (!string.IsNullOrWhiteSpace(diretorioDestino) && diretorio.Contains($@"\{diretorioDestino.Trim()}"))
                                        ? Directory.GetParent(diretorio)!.FullName
                                        : diretorio;
                
                var diretorioSerie = Directory.GetParent(diretorioVolume)!.FullName;
                var nomeSerie = new DirectoryInfo(diretorioSerie).Name;

                if (!diretorioInicial.Contains(diretorioSerie) &&
                    currentDirectory != diretorioSerie && 
                    diretorioSerie != diretorioInicial)
                {
                    indentity = "     ";

                    if (!string.IsNullOrWhiteSpace(currentDirectory))
                    {
                        gravarLog($@"          </{nomeSerie}>", Color.LightCoral);
                    }

                    gravarLog($@"          <{nomeSerie}>", Color.LightCoral);
                    currentDirectory = diretorioSerie;
                }

                if (utilizarMetadados)
                {
                    metadados = ObterMetadados(caminhoArquvioMetadados: $@"{diretorioVolume}\metadata.opf");
                    nomeArquivo = LimpezaNomeDiretoriosArquivos(metadados.Titulo);
                }
                else
                {
                    nomeArquivo = $@"{nomeSerie} - {Directory.GetParent(diretorio)!.Name.PadLeft(4, '0')}";
                }

                if(gerarCbz)
                {
                    GerarCbz(
                            diretorio: diretorio,
                            diretorioPai: diretorioVolume,
                            diretorioSerie: diretorioSerie,
                            nomeArquivo: nomeArquivo,
                            nomeArquivoCapa: nomeArquivoCapa
                        );

                    gravarLog($@"{indentity}          {nomeArquivo}.cbz", Color.LightYellow);
                }

                if(gerarEpub)
                {
                    GerarEpub(
                            diretorio: diretorio,
                            diretorioPai: diretorioVolume,
                            diretorioSerie: diretorioSerie,
                            nomeArquivo: nomeArquivo,
                            metadados: metadados,
                            nomeArquivoCapa: nomeArquivoCapa
                        );

                    gravarLog($@"{indentity}          {nomeArquivo}.epub", Color.LightYellow);
                }

                countDirectories++;

                if (!string.IsNullOrWhiteSpace(currentDirectory) && countDirectories == imagesDirectories.Count())
                {
                    gravarLog($@"          </{nomeSerie}>", Color.LightCoral);
                }

                if (utilizarMetadados && metadados is { })
                {
                    File.Move($@"{diretorioVolume}\metadata.opf", $@"{diretorioSerie}\{nomeArquivo}-metadata.opf");
                }

                if(apagarArquivosOriginais && Directory.Exists(diretorioVolume))
                {
                    try
                    {
                        Directory.Delete(diretorioVolume, true);
                    }
                    catch 
                    {
                        gravarLog($@"{indentity}          <erro mensagem='Diretório {new DirectoryInfo(diretorioVolume).Name} não foi excluído' />", Color.Red);
                    }
                }
            }

            GravaLogFechamentoTagPrincipal(gravarLog: gravarLog);
        }

        private Metadados ObterMetadados(
                [NotNull] string caminhoArquvioMetadados
            )
        {
            XmlSerializer serializer = new XmlSerializer(typeof(package));

            // Declare an object variable of the type to be deserialized.
            package pkg;

            using (Stream reader = new FileStream(caminhoArquvioMetadados, FileMode.Open))
            {
                // Call the Deserialize method to restore the object's state.
                pkg = (package)serializer.Deserialize(reader)!;
            }

            var metadados = new Metadados();

            for (int i = 0; i < pkg.metadata.Items.Count(); i++)
            {
                switch (pkg.metadata.ItemsElementName[i])
                {
                    case ItemsChoiceType.title:
                        metadados.Titulo = pkg.metadata.Items[i].ToString();
                        break;

                    case ItemsChoiceType.publisher:
                        metadados.Editora = pkg.metadata.Items[i].ToString();
                        break;

                    case ItemsChoiceType.date:
                        metadados.DataPublicacao = (DateTime)pkg.metadata.Items[i];
                        break;

                    case ItemsChoiceType.creator:
                        if (metadados.Criadores.Length > 0)
                        {
                            metadados.Criadores.Append(",");
                        }

                        metadados.Criadores.Append(((creator)pkg.metadata.Items[i]).Value);
                        break;
                }
            }

            return metadados;
        }

        private static string LimpezaNomeDiretoriosArquivos(
                string nomeOriginal
            )
        {
            return nomeOriginal
                        .Replace(":", " - ")
                        .Replace("<", "[")
                        .Replace(">", "]")
                        .Replace("\"", "'")
                        .Replace("|", " ")
                        .Replace("?", "!!")
                        .Replace("*", "+")
                        .Replace("\\", " & ")
                        .Replace("/", " & ");
        }

        private void GerarCbz(
                [NotNull] string diretorio,
                [NotNull] string diretorioPai,
                [NotNull] string diretorioSerie,
                [NotNull] string nomeArquivo,
                string? nomeArquivoCapa
            )
        {
            var nomeCapa = "0".PadLeft(4, '0');

            if(!string.IsNullOrWhiteSpace(nomeArquivoCapa) && File.Exists($@"{diretorioPai}\{nomeArquivoCapa.Trim()}") && !File.Exists($@"{diretorio}\{nomeCapa}.jpg"))
            {
                File.Move($@"{diretorioPai}\{nomeArquivoCapa.Trim()}", $@"{diretorio}\{nomeCapa}.jpg");
            }

            ZipFile.CreateFromDirectory(diretorio, $@"{diretorioSerie}\{nomeArquivo}.cbz", CompressionLevel.NoCompression, false);
        }

        private void GerarEpub(
                [NotNull] string diretorio,
                [NotNull] string diretorioPai,
                [NotNull] string diretorioSerie,
                [NotNull] string nomeArquivo,
                Metadados? metadados,
                string? nomeArquivoCapa
            )
        {
            var files = Directory.GetFiles(diretorio)?.OrderBy(o => o);

            if (files?.Any() != true)
            {
                return;
            }

            var diretorioEpub = $@"{diretorioPai}\epub";
            var diretorioOebps = $@"{diretorioEpub}\OEBPS";
            var diretorioMeta = $@"{diretorioEpub}\META-INF";

            Directory.CreateDirectory(diretorioEpub);
            Directory.CreateDirectory(diretorioOebps);
            Directory.CreateDirectory(diretorioMeta);

            #region COVER
            if (!string.IsNullOrWhiteSpace(nomeArquivoCapa))
            {
                var nomeCover = "cover.jpg";

                if (!string.IsNullOrWhiteSpace(nomeArquivoCapa) && File.Exists($@"{diretorioPai}\{nomeArquivoCapa.Trim()}") && !File.Exists($@"{diretorioEpub}\{nomeCover}.jpg"))
                {
                    File.Move($@"{diretorioPai}\{nomeArquivoCapa.Trim()}", $@"{diretorioEpub}\{nomeCover}.jpg");
                }
            }
            #endregion COVER

            #region MIMETYPE
            File.WriteAllText(
                $@"{diretorioEpub}\mimetype",
                $@"application/epub+zip");
            #endregion MIMETYPE

            #region NAV
            File.WriteAllText(
                $@"{diretorioEpub}\nav.xhtml",
                $@"<?xml version='1.0' encoding='utf-8'?>
<html xmlns=""http://www.w3.org/1999/xhtml"" xmlns:epub=""http://www.idpf.org/2007/ops"" lang=""en"" xml:lang=""en"">
  <head>
    <title>nav</title>
    <meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8""/>
  <link rel=""stylesheet"" type=""text/css"" href=""../stylesheet.css""/>
<link rel=""stylesheet"" type=""text/css"" href=""../page_styles.css""/>
</head>
  <body class=""calibre4"">
<nav epub:type=""toc"" hidden="""">
  <ol>
    <li><a href=""OEBPS/part0000.xhtml"">Content</a></li>
  </ol>
</nav>
</body>
</html>");
            #endregion NAV

            #region PAGE_STYLES
            File.WriteAllText(
                $@"{diretorioEpub}\page_styles.css",
                $@"@page {{margin - bottom: 0;
  margin-top: 0;
}}");
            #endregion PAGE_STYLES

            #region STYLESHEET
            File.WriteAllText(
                $@"{diretorioEpub}\stylesheet.css",
                $@".calibre {{background: #FFF;
  color: #000;
}}
.calibre1 {{display: block;
  font-size: 1em;
  margin: 0;
  padding: 0;
}}
.calibre2 {{display: block;
  height: 1920px;
  width: 1280px;
  margin: 0;
  padding: 0;
}}
.calibre3 {{height: 1920px;
  position: absolute;
  width: 1280px;
  border: currentColor none 0;
}}
.calibre4 {{display: block;
  font-size: 1em;
  padding-left: 0;
  padding-right: 0;
  margin: 0;
}}
.calibre5 {{display: block;
  font-size: 2em;
  font-weight: bold;
  line-height: 1.2;
  margin: 0.67em 0;
}}
.calibre6 {{display: block;
  list-style-type: decimal;
  margin: 1em 0;
}}
.calibre7 {{display: list-item;}}");
            #endregion STYLESHEET

            #region TITLEPAGE
            File.WriteAllText(
                $@"{diretorioEpub}\titlepage.xhtml",
                $@"<?xml version='1.0' encoding='utf-8'?>
<html xmlns=""http://www.w3.org/1999/xhtml"" xmlns:epub=""http://www.idpf.org/2007/ops"" xml:lang=""en"">
  <head>
    <meta name=""calibre:cover"" content=""true""/>
    <title>Cover</title>
    <style type=""text/css"" title=""override_css"">
            @page {{padding: 0pt; margin:0pt}}
            body {{ text-align: center; padding:0pt; margin: 0pt; }}
        </style>
    <meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8""/>
  </head>
  <body>
        <div>
            <svg xmlns=""http://www.w3.org/2000/svg"" xmlns:xlink=""http://www.w3.org/1999/xlink"" version=""1.1"" width=""100%"" height=""100%"" viewBox=""0 0 1280 1920"" preserveAspectRatio=""none"">
                <image width=""1280"" height=""1920"" xlink:href=""cover.jpg""/>
            </svg>
        </div>
    </body>
</html>");
            #endregion TITLEPAGE

            #region CONTAINER
            File.WriteAllText(
                $@"{diretorioMeta}\container.xml",
                $@"<?xml version=""1.0""?>
<container version=""1.0"" xmlns=""urn:oasis:names:tc:opendocument:xmlns:container"">
   <rootfiles>
      <rootfile full-path=""content.opf"" media-type=""application/oebps-package+xml""/>
      
   </rootfiles>
</container>");
            #endregion TITLEPAGE

            var paginas = new List<string>();
            var imagens = new List<string>();
            var refs = new List<string>();

            #region IMAGES
            var countImages = 1;

            foreach (var file in files)
            {
                var ext = Path.GetExtension(file);
                ext = ext == ".jpeg" ? ".jpg" : ext;
                var nomeImagem = $@"img{countImages.ToString().PadLeft(4, '0')}{ext}";
                var nomePagina = $@"pag{countImages.ToString().PadLeft(4, '0')}.xhtml";

                using var img = Image.FromFile(file);

                File.Copy(file, $@"{diretorioOebps}\{nomeImagem}");
                File.WriteAllText(
                        $@"{diretorioOebps}\{nomePagina}",
                        $@"<?xml version='1.0' encoding='utf-8'?>
<html xmlns=""http://www.w3.org/1999/xhtml"" xmlns:epub=""http://www.idpf.org/2007/ops"" class=""calibre"">
  <head>
    <meta name=""viewport"" content=""width={img.Width}, height={img.Height}""/>
    <title>pag{countImages.ToString().PadLeft(4, '0')}</title>
    <link rel=""stylesheet"" type=""text/css"" href=""../stylesheet.css""/>
    <link rel=""stylesheet"" type=""text/css"" href=""../page_styles.css""/>
    <meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8""/>
  </head>
  <body class=""calibre1"">
<div class=""calibre2""><img src=""{nomeImagem}"" alt="""" class=""calibre3""/></div>
</body>
</html>"
                    );

                paginas.Add($@"<item id=""{nomePagina}"" href=""OEBPS/{nomePagina}"" media-type=""application/xhtml+xml""/>");
                imagens.Add($@"<item id=""{nomeImagem}"" href=""OEBPS/{nomeImagem}"" media-type=""image/jpeg""/>");
                refs.Add($@"<itemref idref=""{nomePagina}""/>");

                countImages++;
            }
            #endregion IMAGES

            #region CONTENT
            File.WriteAllText(
                $@"{diretorioEpub}\content.opf",
                $@"<?xml version='1.0' encoding='utf-8'?>
<package xmlns=""http://www.idpf.org/2007/opf"" version=""3.0"" unique-identifier=""uuid_id"" prefix=""calibre: https://calibre-ebook.com"">
  <metadata xmlns:opf=""http://www.idpf.org/2007/opf"" xmlns:dc=""http://purl.org/dc/elements/1.1/"" xmlns:dcterms=""http://purl.org/dc/terms/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:calibre=""http://calibre.kovidgoyal.net/2009/metadata"">
    <dc:title id=""id"">{metadados?.Titulo ?? string.Empty}</dc:title>
    <dc:creator id=""id-1"">{metadados?.Criadores?.ToString() ?? string.Empty}</dc:creator>
    <dc:language>en</dc:language>
    <dc:contributor id=""id-2"">calibre (6.5.0) [https://calibre-ebook.com]</dc:contributor>
    <dc:identifier id=""uuid_id"">uuid:{metadados?.Uuid.ToString("d") ?? string.Empty}</dc:identifier>
    <dc:identifier>calibre:{metadados?.Uuid.ToString("d") ?? string.Empty}</dc:identifier>
    <dc:publisher>{metadados?.Editora ?? string.Empty}</dc:publisher>
    <dc:date>{metadados?.DataPublicacao.ToString("yyyy-MM-ddT00:00:00+00:00") ?? string.Empty}</dc:date>
    <meta refines=""#id"" property=""title-type"">main</meta>
    <meta refines=""#id"" property=""file-as"">{metadados?.Titulo ?? string.Empty}</meta>
    <meta name=""cover"" content=""cover""/>
    <meta refines=""#id-1"" property=""role"" scheme=""marc:relators"">aut</meta>
    <meta refines=""#id-1"" property=""file-as"">{metadados?.Criadores?.ToString() ?? string.Empty}</meta>
    <meta refines=""#id-2"" property=""role"" scheme=""marc:relators"">bkp</meta>
    <meta property=""calibre:timestamp"" scheme=""dcterms:W3CDTF"">{metadados?.DataPublicacao.ToString("yyyy-MM-ddT00:00:00z") ?? string.Empty}</meta>
    <meta property=""belongs-to-collection"" id=""id-3"">{metadados?.Titulo ?? string.Empty}</meta>
    <meta refines=""#id-3"" property=""collection-type"">series</meta>
    <meta refines=""#id-3"" property=""group-position"">1</meta>
    <meta property=""dcterms:modified"" scheme=""dcterms:W3CDTF"">{DateTime.Now:yyyy-MM-ddTHH:mm:ss}</meta>
  </metadata>
  <manifest>
    <item id=""titlepage"" href=""titlepage.xhtml"" media-type=""application/xhtml+xml"" properties=""svg calibre:title-page""/>
    {string.Join(' ', paginas.ToArray())}
    <item id=""page_css"" href=""page_styles.css"" media-type=""text/css""/>
    <item id=""css"" href=""stylesheet.css"" media-type=""text/css""/>
    <item id=""cover"" href=""cover.jpg"" media-type=""image/jpeg"" properties=""cover-image""/>
    {string.Join(' ', imagens.ToArray())}
    <item id=""nav"" href=""nav.xhtml"" media-type=""application/xhtml+xml"" properties=""nav""/>
  </manifest>
  <spine>
    <itemref idref=""titlepage""/>
    {string.Join(' ', refs.ToArray())}
  </spine>
  </package>
");
            #endregion CONTENT

            #region ZIP
            ZipFile.CreateFromDirectory(diretorioEpub, $@"{diretorioSerie}\{nomeArquivo}.epub", CompressionLevel.NoCompression, false);
            #endregion ZIP

            #region DELETE FOLDER EPUB
            Directory.Delete(diretorioEpub, true);
            #endregion DELETE FOLDER EPUB
        }

        private void GravaLogFechamentoTagPrincipal(
                Action<string, Color> gravarLog
            )
        {
            gravarLog($@"     </geração>", Color.Coral);
        }
    }
}
