using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Volvo.BFF.Models
{
    public class Caminhao
    {
        public int Id { get; set; }
        public int AnoFabricacao { get; set; }
        public int AnoModelo { get; set; }
        
        [ForeignKey("Modelo")]
        public string SiglaModelo { get; set; }
        public Modelo Modelo { get; set; }
    }
}