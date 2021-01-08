using System.Linq;
using Microsoft.Extensions.Configuration;
using Volvo.BFF.Data;

namespace Volvo.BFF.Repositories
{
    public class ModeloRepository : IModeloRepository
    {
        private VolvoContext _context;
        private IConfiguration _configuration;

        public ModeloRepository(IConfiguration configuration, VolvoContext context)
        {
            _context = context;
            _configuration = configuration;
        }
        public bool ModeloPermitido(string modelo)
        {
            return _context.Modelos.Where(c => c.Permitido == true && c.Sigla == modelo).Any();
        }
    }
}