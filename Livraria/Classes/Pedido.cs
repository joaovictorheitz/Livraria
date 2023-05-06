using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Livraria.Classes
{
    [Table("pedido")]
    public class Pedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("cliente")]
        public int ClienteId { get; set; }

        public DateTime DataPedido { get; set; }
        public DateTime DataEntrega { get; set; }
    }
}
