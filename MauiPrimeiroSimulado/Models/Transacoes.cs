using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiPrimeiroSimulado.Models
{
    public class Transacoes
    {
        public int? idTransacao { get; set; }
        public int produtoId { get; set; }
        public int quantidadeTransacao { get; set; }

        public DateTime? dataTransacao { get; set; } = DateTime.Now;
        public  string tipoTransacao { get; set; }

    }
}
