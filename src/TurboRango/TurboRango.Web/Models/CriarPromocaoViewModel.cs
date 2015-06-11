using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TurboRango.Web.Models
{
    public class CriarPromocaoViewModel
    {
        public int RestauranteId { get; set; }
        public Decimal ValorPromocao { get; set; }
        public DateTime TerminoPromocao { get; set; }
    }
}