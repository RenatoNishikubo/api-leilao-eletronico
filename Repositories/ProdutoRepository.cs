using Microsoft.EntityFrameworkCore;
using Projeto_Leilao.Data;
using Projeto_Leilao.Models;

namespace Projeto_Leilao.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        public readonly ProdutoContext _context;
        public ProdutoRepository(ProdutoContext context)
        {
            _context = context;
        }

        public async Task<Produto> Create(Produto produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();

            return produto;
        }

        public async Task Delete(int Id)
        {
            var produtoDelete = await _context.Produtos.FindAsync(Id);
            _context.Produtos.Remove(produtoDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Produto>> Get()
        {
            return await _context.Produtos.ToListAsync();
        }

        public async Task<Produto> Get(int Id)
        {
            return await _context.Produtos.FindAsync(Id);
        }

        public async Task Update(Produto produto)
        {
            _context.Entry(produto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
