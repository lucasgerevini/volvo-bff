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

        public CaminhaoService(IConfiguration configuration, ICaminhaoRepository caminhaoRepository)
        {
            _configuration = configuration;
            _caminhaoRepository = caminhaoRepository;
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
            return await _caminhaoRepository.Save(caminhao);
        }

        public async Task Update(Caminhao caminhao, int id)
        {
            //Caminhao retorno = await _caminhaoRepository.Get(id);

            //if (retorno is null) throw new ArgumentException("Caminhão não encontrado!");
            //if (ObjectComparer<Caminhao>.IsDiff(caminhao, retorno)) throw new ArgumentException("Não possui alterações!");
                
            await _caminhaoRepository.Update(caminhao);
        }
    }
}