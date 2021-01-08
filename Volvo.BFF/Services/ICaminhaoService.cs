using System.Collections.Generic;
using System.Threading.Tasks;
using Volvo.BFF.Models;

namespace Volvo.BFF.Services
{
    public interface ICaminhaoService
    {
        Task<Caminhao> Get(int id);
        Task<IEnumerable<Caminhao>> Get();
        Task<Caminhao> Save(Caminhao caminhao);
        Task Update(Caminhao caminhao, int id);
        Task Delete(int id);
    }
}