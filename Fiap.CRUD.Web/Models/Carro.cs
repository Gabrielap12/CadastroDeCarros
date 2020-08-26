using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.CRUD.Web.Models
{
    public class Carro
    {

        public int Codigo { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public int Ano { get; set; }
        public DateTime DataFabricacao { get; set; }
        public Combustivel Combustivel { get; set; }

        public decimal Valor { get; set; }
        public bool Novo { get; set; }


    }
}
