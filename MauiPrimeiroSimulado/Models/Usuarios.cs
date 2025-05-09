using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiPrimeiroSimulado.Models
{
    public class Usuarios
    {
        public int idUsuario { get; set; }
        public string nomeUsuario { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public string tipo { get; set; }
    }
}
