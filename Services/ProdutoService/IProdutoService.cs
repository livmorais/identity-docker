namespace project;

public interface IProdutoService
{
        Task<List<Produto>> GetProdutos();
        Task<Produto?> GetProdutoId(int id);
        Task<Produto> CreateProduto(ProdutoDTO produtoDTO);
        Task<Produto?> UpdateProduto(int Id, ProdutoDTO produtoDTO);
        Task<bool> DeleteProduto(int Id);
}
