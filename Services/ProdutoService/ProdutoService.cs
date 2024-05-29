using Microsoft.EntityFrameworkCore;
using project.Data;

namespace project
{
    public class ProdutoService : IProdutoService
    {
        private readonly DataContext _context;

        public ProdutoService(DataContext context)
        {
            _context = context;
        }

        public async Task<Produto> CreateProduto(ProdutoDTO produtoDTO)
        {
            var produto = new Produto
            {
                Nome = produtoDTO.Nome,
                Descricao = produtoDTO.Descricao,
                Preco = produtoDTO.Preco,
                Quantidade = produtoDTO.Quantidade
            };

            _context.Add(produto);
            await _context.SaveChangesAsync();
            return produto;
        }

        public async Task<bool> DeleteProduto(int id)
        {
            var dbProduto = await _context.Produtos.FindAsync(id);
            if (dbProduto == null)
            {
                return false;
            }

            _context.Remove(dbProduto);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Produto?> GetProdutoId(int id)
        {
            return await _context.Produtos.FindAsync(id);
        }

        public async Task<List<Produto>> GetProdutos()
        {
            return await _context.Produtos.ToListAsync();
        }

        public async Task<Produto?> UpdateProduto(int id, ProdutoDTO produtoDTO)
        {
            var dbProduto = await _context.Produtos.FindAsync(id);
            if (dbProduto == null)
            {
                return null;
            }

            dbProduto.Nome = produtoDTO.Nome;
            dbProduto.Descricao = produtoDTO.Descricao;
            dbProduto.Preco = produtoDTO.Preco;
            dbProduto.Quantidade = produtoDTO.Quantidade;

            await _context.SaveChangesAsync();
            return dbProduto;
        }
    }
}
