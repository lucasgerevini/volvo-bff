using System.Net.Cache;
using Xunit;
using Moq;
using Volvo.BFF.Models;
using Volvo.BFF.Services;
using Microsoft.Extensions.Configuration;
using Volvo.BFF.Repositories;
using System;

namespace Volvo.Test
{
    public class CaminhaoTest
    {
        [Fact]
        public void Adicionar_Caminhao_OK()
        {
            Modelo modelo = new Modelo();
            modelo.Sigla = "FH";
            modelo.Permitido = true;

            Caminhao caminhao = new Caminhao();
            caminhao.Id = 1;
            caminhao.AnoFabricacao = 2021;
            caminhao.AnoModelo = 2022;
            caminhao.SiglaModelo = "FH";
            caminhao.Modelo = modelo;

            var rep = new Mock<ICaminhaoRepository>();
            var modeloService = new Mock<IModeloService>();
            var config = new Mock<IConfiguration>();

            rep.Setup(r => r.Save(caminhao));

            var svc = new CaminhaoService(config.Object, rep.Object, modeloService.Object);

            rep.Setup(r => r.Save(caminhao))
                            .ReturnsAsync(caminhao);
            var result = rep.Object.Save(caminhao);

            Assert.Equal(result.Result, caminhao);
        }

        [Fact]
        public void Adicionar_Caminhao_AnoFabricacao_Diferente_ao_Atual()
        {
            Modelo modelo = new Modelo();
            modelo.Sigla = "FH";
            modelo.Permitido = true;

            Caminhao caminhao = new Caminhao();
            caminhao.Id = 1;
            caminhao.AnoFabricacao = 2022;
            caminhao.AnoModelo = 2022;
            caminhao.SiglaModelo = "FH";
            caminhao.Modelo = modelo;
            
            var rep = new Mock<ICaminhaoRepository>();
            var modeloService = new Mock<IModeloService>();
            var config = new Mock<IConfiguration>();

            rep.Setup(r => r.Save(caminhao));

           var svc = new CaminhaoService(config.Object, rep.Object, modeloService.Object);

            var message = Assert.ThrowsAsync<ArgumentException>(
                () => svc.Save(caminhao)).Result;

            int anoAtual = DateTime.Now.Year;
            Assert.Equal($"Ano do Fabricacao deve ser igual a {anoAtual}!", message.Message);

        }

        [Fact]
        public void Adicionar_Caminhao_AnoModelo_Diferente_ao_Atual_e_Subsequente()
        {
            Modelo modelo = new Modelo();
            modelo.Sigla = "FH";
            modelo.Permitido = true;

            Caminhao caminhao = new Caminhao();
            caminhao.Id = 1;
            caminhao.AnoFabricacao = 2021;
            caminhao.AnoModelo = 2020;
            caminhao.SiglaModelo = "FH";
            caminhao.Modelo = modelo;

            var rep = new Mock<ICaminhaoRepository>();
            var modeloService = new Mock<IModeloService>();
            var config = new Mock<IConfiguration>();

            rep.Setup(r => r.Save(caminhao));

            var svc = new CaminhaoService(config.Object, rep.Object, modeloService.Object);

            var message = Assert.ThrowsAsync<ArgumentException>(
                () => svc.Save(caminhao)).Result;
                
            int anoAtual = DateTime.Now.Year;
            Assert.Equal($"Ano do Modelo deve ser igual ou subsequente a {anoAtual}!", message.Message);
        }

        [Fact]
        public void Adicionar_Caminhao_Modelo_Diferente_Permitido()
        {
            Modelo modelo = new Modelo();
            modelo.Sigla = "FH";
            modelo.Permitido = false;

            Caminhao caminhao = new Caminhao();
            caminhao.Id = 1;
            caminhao.AnoFabricacao = 2021;
            caminhao.AnoModelo = 2022;
            caminhao.SiglaModelo = "FH";
            caminhao.Modelo = modelo;

            var rep = new Mock<ICaminhaoRepository>();
            var repModelo = new Mock<IModeloRepository>();
            var modeloService = new Mock<IModeloService>();
            var config = new Mock<IConfiguration>();

            rep.Setup(r => r.Save(caminhao));
            repModelo.Setup(m => m.ModeloPermitido("FW"));

            var svcModelo = new ModeloService(config.Object, repModelo.Object);

            var svc = new CaminhaoService(config.Object, rep.Object, svcModelo);

            var message = Assert.ThrowsAsync<ArgumentException>(
                () => svc.Save(caminhao)).Result;
                
            Assert.Equal($"Modelo não existe ou não é permitido!", message.Message);
        }
    }
}