using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Livraria.Classes
{
    [Table("livro")]
    public class Livro
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id;

        [ForeignKey("autor")]
        public int AutorId { get; set; }

        [ForeignKey("categorias")]
        public int CategoriaId { get; set; }
        [ForeignKey("editora")]
        public int EditoraId { get; set; }
        public string Nome { get; set; }
    }
}
