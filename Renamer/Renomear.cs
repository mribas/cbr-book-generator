namespace Renamer
{
    public class Renomear
    {
        public void Executar(
                string diretorioInicial,
                bool pesquisarSubDiretorios,
                string? diretorioDestino,
                string? ignoreImageName,
                Action<string, Color> gravarLog
            )
        {
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

            if (files?.Any() != true)
            {
                gravarLog($@"     <renomeamento totalArquivos='0' />", System.Drawing.Color.HotPink);
                return;
            }

            if(files.Where(w => Path.GetExtension(w).ToLower() != ".jpg").Any())
            {
                gravarLog($@"     <renomeamento>", System.Drawing.Color.HotPink);
                gravarLog($@"          <executar>false</executar>", System.Drawing.Color.Red);
                gravarLog($@"          <mensagem>Existem arquivos não ajustados!</mensagem>", System.Drawing.Color.LightPink);
                GravaLogFechamentoTagPrincipal(gravarLog: gravarLog);
                return;
            }

            gravarLog($@"     <renomeamento>", System.Drawing.Color.HotPink);
            gravarLog($@"          <executar>true</executar>", System.Drawing.Color.Red);

            var volumes = files
                            .Where(w => string.IsNullOrWhiteSpace(ignoreImageName) || !w.Contains(ignoreImageName))
                            .GroupBy(g => Directory.GetParent(Directory.GetParent(g)!.FullName)!.FullName)
                            .Select(s => s.Key)
                            .Distinct()
                            .OrderBy(o => o)
                            .ToList();

            foreach(var volume in volumes)
            {
                var volumeDirName = new DirectoryInfo(volume).Name;
                var indentity = string.Empty;

                if(!diretorioInicial.Contains(volume) && 
                    volume != diretorioInicial)
                {
                    gravarLog($@"          <{volumeDirName}>", Color.LightSalmon);
                    indentity = "     ";
                }

                var chapters = Directory.GetDirectories(volume).OrderBy(o => o).ToList();

                if(!string.IsNullOrWhiteSpace(diretorioDestino))
                {
                    chapters.Remove($@"{volume}\{diretorioDestino}");
                }

                var volumeImagesGroupDirTemp = $@"{volume}\{Guid.NewGuid():D}";

                if(!string.IsNullOrWhiteSpace(diretorioDestino) && !Directory.Exists($@"{volume}\{diretorioDestino}"))
                {
                    Directory.CreateDirectory($@"{volume}\{diretorioDestino}");
                }

                foreach (var chapter in chapters) 
                {
                    var chapterDirName = new DirectoryInfo(chapter).Name;

                    var destinyFolderFormatted = !string.IsNullOrWhiteSpace(diretorioDestino)
                                                    ? $@"{diretorioDestino.Trim()}\"
                                                    : $@"{chapterDirName.Trim()}\";

                    var filesPerChapter = Directory.GetFiles(chapter).OrderBy(o => o).ToList();
                    var countFiles = filesPerChapter?.Count ?? 0;

                    if(countFiles > 0)
                    {
                        foreach (var page in filesPerChapter!)
                        {
                            var currentName = Path.GetFileName(page).ToLower();
                            var newName = $@"{Path.GetFileNameWithoutExtension(page).ToLower().PadLeft(4, '0')}.jpg";

                            if (currentName != newName)
                            {
                                File.Move(page, page.Replace(currentName, newName));
                            }
                        }

                        filesPerChapter = Directory.GetFiles(chapter).OrderBy(o => o).ToList();
                        var pageNumber = 1;

                        foreach (var page in filesPerChapter!)
                        {
                            File.Move(page, $@"{volume}\{destinyFolderFormatted}{chapterDirName.PadLeft(4, '0')}-{pageNumber.ToString().PadLeft(4, '0')}.jpg");
                            pageNumber++;
                        }
                    }

                    if(!string.IsNullOrWhiteSpace(diretorioDestino))
                    {
                        try
                        {
                            Directory.Delete(chapter, true);
                        }
                        catch 
                        {
                            gravarLog($@"{indentity}          <erro mensagem='Diretório {chapterDirName} não foi excluído' />", Color.Red);
                        }
                    }

                    gravarLog($@"{indentity}          <{chapterDirName} totalArquivos='{countFiles}' />", countFiles > 0 ? Color.LightSalmon : Color.Gray);
                }

                if (!diretorioInicial.Contains(volume) &&
                    volume != diretorioInicial)
                {
                    gravarLog($@"          </{volumeDirName}>", Color.LightSalmon);
                }
            }

            GravaLogFechamentoTagPrincipal(gravarLog: gravarLog);
        }

        private void GravaLogFechamentoTagPrincipal(
                Action<string, System.Drawing.Color> gravarLog
            )
        {
            gravarLog($@"     </renomeamento>", System.Drawing.Color.HotPink);
        }
    }
}
