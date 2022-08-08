using System.ComponentModel.DataAnnotations;

namespace ApiProjetoProgWeb.Model
{
    public class ComandaProduto
    {
        [Key]
        public int id { get; set; }
        public Produto produto { get; set; }
        public int idProduto { get; set; }
        public int idComanda { get; set; }
        public int quantidade { get; set; }
    }
}
