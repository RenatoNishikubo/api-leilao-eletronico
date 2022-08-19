using Microsoft.AspNetCore.Mvc;
using Projeto_Leilao.Models;
using Projeto_Leilao.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Leilao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Produto>> GetProdutos()
        {
            return await _produtoRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> GetProdutos(int id)
        {
            return await _produtoRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Produto>> PostProdutos([FromBody] Produto produto)
        {
            var newProduto = await _produtoRepository.Create(produto);
            return CreatedAtAction(nameof(GetProdutos), new { id = newProduto.Id }, newProduto); 
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Produto>> Delete(int id)
        {
            var produtoToDelete = await _produtoRepository.Get(id);

            if (produtoToDelete == null)
                return NotFound();

            await _produtoRepository.Delete(produtoToDelete.Id);
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult<Produto>> PutProdutos(int id, [FromBody] Produto produto)
        {
            if (id != produto.Id)
                return BadRequest();

            await _produtoRepository.Update(produto);
            return NoContent();
        }
    }
}
