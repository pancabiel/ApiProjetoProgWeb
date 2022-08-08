namespace ApiProjetoProgWeb.Model.DTO
{
    public class ComandaDTO
    {
        public int? id { get; set; }
        public string? nomeUsuario { get; set; }
        public string? telefoneUsuario { get; set; }
        public List<ComandaProdutoDTO>? comandaProdutos { get; set; }
    }
}
