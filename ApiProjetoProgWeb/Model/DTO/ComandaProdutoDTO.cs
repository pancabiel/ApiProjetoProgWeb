namespace ApiProjetoProgWeb.Model.DTO
{
    public class ComandaProdutoDTO
    {
        public int? id { get; set; }
        public int idProduto { get; set; }
        public int? idComanda { get; set; }
        public int quantidade { get; set; }
    }
}
