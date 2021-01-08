using Microsoft.Extensions.Configuration;
using Volvo.BFF.Repositories;

namespace Volvo.BFF.Services
{
    public class ModeloService : IModeloService
    {
        private IConfiguration _configuration;
        private IModeloRepository _modeloRepository;

        public ModeloService(IConfiguration configuration, IModeloRepository modeloRepository)
        {
          _configuration = configuration;
          _modeloRepository = modeloRepository;
        }
        public bool ModeloPermitido(string modelo)
        {
          return _modeloRepository.ModeloPermitido(modelo);
        }
    }
}