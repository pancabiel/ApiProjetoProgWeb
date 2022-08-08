using System.ComponentModel.DataAnnotations;

namespace ApiProjetoProgWeb.Model
{
    public class Comanda
    {
        [Key]
        public int id { get; set; }
        [MaxLength(255)]
        public string? nomeUsuario { get; set; }
        [MaxLength(255)]
        public string? telefoneUsuario { get; set; }
        public List<ComandaProduto> comandaProdutos { get; set; }
    }
}
