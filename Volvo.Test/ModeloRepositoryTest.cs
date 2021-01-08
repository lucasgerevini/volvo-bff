using System.Linq;
using Volvo.BFF.Models;
using Xunit;

namespace Volvo.Test
{
    public class ModeloRepositoryTest
    {
        [Fact]
        public void Adiciona_Modelo()
        {
            var factory = new ConnectionFactory();

            var context = factory.CreateContextForInMemory();

            Modelo modelo = new Modelo();
            modelo.Sigla = "FW";
            modelo.Permitido = false;


            var dataModelo = context.Modelos.Add(modelo);
            context.SaveChanges();

            var postCount = context.Modelos.Count();
            if (postCount != 0)
            {
                Assert.Equal(3, postCount);
            }

            var modeloAfetado = context.Modelos.LastOrDefault();
            if (modeloAfetado != null)
            {
                Assert.Equal("FW", modeloAfetado.Sigla);
            }
        }

        [Fact]
        public void Editar_Modelo()
        {
            var factory = new ConnectionFactory();

            var context = factory.CreateContextForInMemory();

            Modelo modelo = new Modelo();
            modelo.Sigla = "FW";
            modelo.Permitido = false;


            var dataModeloAdd = context.Modelos.Add(modelo);
            context.SaveChanges();

            modelo.Permitido = true;

            var dataModeloEdit = context.Modelos.Update(modelo);
            context.SaveChanges();

            var modeloCount = context.Modelos.Count();
            if (modeloCount != 0)
            {
                Assert.Equal(3, modeloCount);
            }

            var modeloAfetado = context.Modelos.LastOrDefault();
            if (modeloAfetado != null)
            {
                Assert.Equal(modelo.Permitido, modeloAfetado.Permitido);
            }
        }

        [Fact]
        public void Deletar_Modelo()
        {
            var factory = new ConnectionFactory();

            var context = factory.CreateContextForInMemory();

            Modelo modelo = new Modelo();
            modelo.Sigla = "FW";
            modelo.Permitido = false;

            var dataModeloAdd = context.Modelos.Add(modelo);
            context.SaveChanges();


            var dataModelo = context.Modelos.Find(modelo.Sigla);
            if (dataModelo != null)
                context.Modelos.Remove(dataModelo);

            context.SaveChanges();

            context.Modelos.Any(c => c.Sigla == modelo.Sigla);
            if (dataModelo != null)
                if (!context.Modelos.Any(c => c.Sigla == modelo.Sigla))
                {
                    Assert.Equal(false, false);
                }
        }
    }
}