using System.Text;

namespace Renamer.Entidades
{
    public class Metadados
    {
        public Guid Uuid { get; set; } = Guid.NewGuid();
        
        public string Titulo { get; set; } = string.Empty;

        public string Editora { get; set; } = string.Empty;

        public DateTime DataPublicacao { get; set; }

        public StringBuilder Criadores { get; set; } = new StringBuilder();
    }
}
