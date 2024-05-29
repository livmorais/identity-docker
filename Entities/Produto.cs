namespace project;

public class Produto
{
        public int Id { get; set; }
        public required string Nome { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public string Preco { get; set; } = string.Empty;
        public string Quantidade { get; set; } = string.Empty;
}
