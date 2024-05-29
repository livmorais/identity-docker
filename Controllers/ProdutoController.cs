using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace project
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        [Authorize(Roles = "users,admin,manager")]
        public async Task<ActionResult<List<Produto>>> GetProdutos()
        {
            var produtos = await _produtoService.GetProdutos();
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "admin,manager")]
        public async Task<ActionResult<Produto>> GetProdutoId(int id)
        {
            var produto = await _produtoService.GetProdutoId(id);
            if (produto == null)
            {
                return NotFound();
            }
            return Ok(produto);
        }

        [HttpPost]
        [Authorize(Roles = "admin,manager")]
        public async Task<ActionResult<Produto>> CreateProduto(ProdutoDTO produtoDTO)
        {
            var produto = await _produtoService.CreateProduto(produtoDTO);
            return CreatedAtAction(nameof(GetProdutoId), new { id = produto.Id }, produto);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin,manager")]
        public async Task<ActionResult<Produto>> UpdateProduto(int id, ProdutoDTO produtoDTO)
        {
            var produto = await _produtoService.UpdateProduto(id, produtoDTO);
            if (produto == null)
            {
                return NotFound();
            }
            return Ok(produto);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin,manager")]
        public async Task<ActionResult> DeleteProduto(int id)
        {
            var result = await _produtoService.DeleteProduto(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}