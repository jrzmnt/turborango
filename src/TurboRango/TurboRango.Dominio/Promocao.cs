using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurboRango.Dominio
{
    public class Promocao : Entidade
    {
        public Restaurante Restaurante { get; set; }
        public Decimal ValorPromocao { get; set; }
        public DateTime TerminoPromocao { get; set; } 
    }
}
