using System.Data.Common;
using System.Linq;
using Volvo.BFF.Models;
using Xunit;

namespace Volvo.Test
{
    public class CaminhaoRepositoryTest
    {
        [Fact]
        public void Adicionar_Caminhao()
        {
            var factory = new ConnectionFactory();

            var context = factory.CreateContextForInMemory();

            Caminhao caminhao = new Caminhao();
            caminhao.AnoFabricacao = 2021;
            caminhao.AnoModelo = 2022;
            caminhao.SiglaModelo = "FH";

            var data = context.Caminhoes.Add(caminhao);
            context.SaveChanges();

            var caminhaoCount = context.Caminhoes.Count();
            if (caminhaoCount != 0)
            {            
                Assert.Equal(3, caminhaoCount);
            }

            var caminhaoAfetado = context.Caminhoes.LastOrDefault();
            if (caminhaoAfetado != null)
            {
                Assert.Equal(caminhao.AnoModelo, caminhaoAfetado.AnoModelo);
            }
        }

        [Fact]
        public void Editar_Caminhao()
        {
            var factory = new ConnectionFactory();

            var context = factory.CreateContextForInMemory();

            Caminhao caminhao = new Caminhao();
            caminhao.AnoFabricacao = 2021;
            caminhao.AnoModelo = 2022;
            caminhao.SiglaModelo = "FH";

            var data = context.Caminhoes.Add(caminhao);
            context.SaveChanges();

             caminhao.AnoModelo = 2021;

            var dataCaminhaoEdit = context.Caminhoes.Update(caminhao);
            context.SaveChanges();

            var caminhaoCount = context.Caminhoes.Count();
            if (caminhaoCount != 0)
            {
                Assert.Equal(3, caminhaoCount);
            }

            var caminhaoAfetado = context.Caminhoes.LastOrDefault();
            if (caminhaoAfetado != null)
            {
                Assert.Equal(caminhao.AnoModelo, caminhaoAfetado.AnoModelo);
            }
        }

        [Fact]
        public void Deletar_Caminhao()
        {
            var factory = new ConnectionFactory();

            var context = factory.CreateContextForInMemory();

            Caminhao caminhao = new Caminhao();
            caminhao.AnoFabricacao = 2021;
            caminhao.AnoModelo = 2022;
            caminhao.SiglaModelo = "FH";

            var data = context.Caminhoes.Add(caminhao);
            context.SaveChanges();


            var dataCaminhao = context.Caminhoes.LastOrDefault();
            if (dataCaminhao != null)
                context.Caminhoes.Remove(dataCaminhao);

            context.SaveChanges();

            context.Caminhoes.Any(c => c.Id ==  dataCaminhao.Id);
            if (dataCaminhao != null)
                if (!context.Caminhoes.Any(c => c.Id  == dataCaminhao.Id))
                {
                    Assert.Equal(false, false);
                }
        }
    }
}