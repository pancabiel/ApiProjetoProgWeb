using System.ComponentModel.DataAnnotations;

namespace ApiProjetoProgWeb.Model
{
    public class Produto
    {
        [Key]
        public int id { get; set; }
        [MaxLength(255)]
        public string? nome { get; set; }
        public double preco { get; set; }
    }
}
