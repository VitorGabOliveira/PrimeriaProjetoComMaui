using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiPrimeiroSimulado.Models
{
    public class Produtos
    {
            public int idProduto { get; set; }

            public string nomeProduto { get; set; }

            public string categoria {  get; set; }

	        public decimal preco {  get; set; }
            public int quantidadeProduto {  get; set; }
            public DateTime dataCadastro { get; set; }
    }
}
