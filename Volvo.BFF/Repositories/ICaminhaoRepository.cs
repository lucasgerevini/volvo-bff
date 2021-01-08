using System.Collections.Generic;
using System.Threading.Tasks;
using Volvo.BFF.Models;

namespace Volvo.BFF.Repositories
{
    public interface ICaminhaoRepository
    {
        Task<Caminhao> Get(int id);
        Task<IEnumerable<Caminhao>> Get();
        Task Delete(Caminhao caminhao);
        Task<Caminhao> Save(Caminhao caminhao);
        Task Update(Caminhao caminhao);
    }
}