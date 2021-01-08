using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Volvo.BFF.Data;
using Volvo.BFF.Models;

namespace Volvo.BFF.Repositories
{
    public class CaminhaoRepository : ICaminhaoRepository
    {
        private VolvoContext _context;
        private IConfiguration _configuration;

        public CaminhaoRepository(IConfiguration configuration, VolvoContext context)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task Delete(Caminhao caminhao)
        {
            _context.Remove(caminhao);
            await _context.SaveChangesAsync();
        }

        public async Task<Caminhao> Get(int id)
        {
            return await _context.Caminhoes.FindAsync(id);
        }

        public async Task<IEnumerable<Caminhao>> Get()
        {
            return await _context.Caminhoes.Include(m=> m.Modelo).ToListAsync();
        }

        public async Task<Caminhao> Save(Caminhao caminhao)
        {
            await _context.AddAsync(caminhao);
            await _context.SaveChangesAsync();
            return caminhao;
        }

        public async Task Update(Caminhao caminhao)
        {
            _context.Update(caminhao);
            await _context.SaveChangesAsync();
        }
    }
}