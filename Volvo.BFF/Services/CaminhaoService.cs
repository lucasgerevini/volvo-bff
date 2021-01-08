using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Volvo.BFF.Models;
using Volvo.BFF.Repositories;
using Volvo.BFF.Utils;

namespace Volvo.BFF.Services
{
    public class CaminhaoService : ICaminhaoService
    {
        private readonly IConfiguration _configuration;
        private readonly ICaminhaoRepository _caminhaoRepository;
        private readonly IModeloService _modeloService;

        public CaminhaoService(IConfiguration configuration, ICaminhaoRepository caminhaoRepository, IModeloService modeloService)
        {
            _configuration = configuration;
            _caminhaoRepository = caminhaoRepository;
            _modeloService = modeloService;
        }

        public async Task Delete(int id)
        {
            Caminhao retorno = await _caminhaoRepository.Get(id);

            if (retorno is null) throw new ArgumentException("Caminhão não encontrado!");

            await _caminhaoRepository.Delete(retorno);
        }

        public async Task<Caminhao> Get(int id)
        {
            return await _caminhaoRepository.Get(id);
        }

        public async Task<IEnumerable<Caminhao>> Get()
        {
            return await _caminhaoRepository.Get();
        }

        public async Task<Caminhao> Save(Caminhao caminhao)
        {
            ValidaCaminhao(caminhao);

            return await _caminhaoRepository.Save(caminhao);
        }

        private void ValidaCaminhao(Caminhao caminhao)
        {
            int anoAtual = DateTime.Now.Year;

            if (caminhao is null) throw new ArgumentException("Caminhão inválido!");

            if (caminhao.AnoModelo != anoAtual && caminhao.AnoModelo != (DateTime.Now.AddYears(1).Year)) throw new ArgumentException($"Ano do Modelo deve ser igual ou subsequente a {anoAtual}!");

            if (caminhao.AnoFabricacao != anoAtual) throw new ArgumentException($"Ano do Fabricacao deve ser igual a {anoAtual}!");        

            if (!_modeloService.ModeloPermitido(caminhao.SiglaModelo)) throw new ArgumentException($"Modelo não existe ou não é permitido!");
        }

        public async Task Update(Caminhao caminhao, int id)
        {
            ValidaCaminhao(caminhao);

            await _caminhaoRepository.Update(caminhao);
        }
    }
}