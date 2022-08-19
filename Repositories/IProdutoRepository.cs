using Projeto_Leilao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Leilao.Repositories
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<Produto>> Get();

        Task<Produto> Get(int Id);

        Task<Produto> Create(Produto produto);

        Task Update(Produto produto);

        Task Delete(int Id);
    }
}
