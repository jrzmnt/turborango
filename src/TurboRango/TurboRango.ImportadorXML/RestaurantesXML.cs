using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TurboRango.Dominio;
using System.Collections.Generic;

namespace TurboRango.ImportadorXML
{
    class RestaurantesXML
    {
        public String NomeArquivo { get; private set; }
        IEnumerable<XElement> restaurantes;
        /// <summary>
        /// Constrói RestaurantesXML
        /// </summary>
        /// <param name="nomeArquivo">Nome do arquivo XML</param>
        
        public IList<string> OrdenarPorNomeAsc()
         {
            return (
                from n in restaurantes
                orderby n.Attribute("nome").Value
                select n.Attribute("nome").Value
            ).ToList();
        }

        public IList<string> ObterSites()
        {
            //return restaurantes
            //    .Where(n => n.Element("contato") != null && n.Element("contato").Element("site") != null && !String.IsNullOrEmpty(n.Element("contato").Value))
            //    .Select(n => n.Element("contato").Element("site").Value)
            //    .ToList();
            return (
                from n in restaurantes
               let contato = n.Element("contato")
                let site = contato != null ? contato.Element("site") : null
               where site != null && !String.IsNullOrEmpty(site.Value)
                select contato.Element("site").Value
            ).ToList();
        }

         public object AgruparPorCategoria()
        {
            //return restaurantes.GroupBy(n => n.Attribute("categoria").Value).Select(g => new { Categoria = g.Key, Restaurantes = g.ToList() }).ToList();
            return (
                from n in restaurantes
                group n by n.Attribute("categoria").Value into g
                select new { Categoria = g.Key, Restaurantes = g.ToList() }
            ).ToList();
        }

        public IList<Categoria> ApenasComUmRestaurante()
        {
            //return restaurantes.GroupBy(x => x.Attribute("categoria").Value).Where(g => g.Count() == 1).Select(g => (Categoria)Enum.Parse(typeof(Categoria), g.Key, ignoreCase: true)).ToList();
            return (
                from n in restaurantes
                let cat = n.Attribute("categoria").Value
                group n by cat into g
                where g.Count() == 1
                select (Categoria)Enum.Parse(typeof(Categoria), g.Key, ignoreCase: true)
            ).ToList();
        }

        public IList<Categoria> ApenasMaisPopulares()
        {
            //return restaurantes.GroupBy(n => n.Attribute("categoria").Value).Where(g => g.Count() > 2).OrderByDescending(g => g.Count()).Take(2).Select(g => (Categoria)Enum.Parse(typeof(Categoria), g.Key, ignoreCase: true)).ToList();
            return (
                from n in restaurantes
                group n by n.Attribute("categoria").Value into g
                let groupLength = g.Count()
                where groupLength > 2
                orderby groupLength descending
                select (Categoria)Enum.Parse(typeof(Categoria), g.Key, ignoreCase: true)
            ).Take(2).ToList();
        }
        
        
        public IList<string> BairrosComMenosPizzarias()
        {
            return (
                 from n in restaurantes
                 let cat = (Categoria)Enum.Parse(typeof(Categoria), n.Attribute("categoria").Value, ignoreCase: true)
                 where cat == Categoria.Pizzaria
                 group n by n.Element("localizacao").Element("bairro").Value into g
                 orderby g.Count()
                 select g.Key).Take(8).ToList();
        }

        public object AgrupadosPorBairroPercentual()
        {
            //return restaurantes.GroupBy(n => n.Element("localizacao").Element("bairro").Value).Select(g => new { Bairro = g.Key, Percentual = Math.Round(Convert.ToDouble(g.Count() * 100) / restaurantes.Count(), 2) }).OrderByDescending(g => g.Percentual);
            return (
                from n in restaurantes
                group n by n.Element("localizacao").Element("bairro").Value into g
                let totalRestaurantes = restaurantes.Count()
                select new { Bairro = g.Key, Percentual = Math.Round(Convert.ToDouble(g.Count() * 100) / totalRestaurantes, 2) }
            ).OrderByDescending(g => g.Percentual);
         }



        public RestaurantesXML(String nomeArquivo)
        {
            this.NomeArquivo = nomeArquivo;
            restaurantes = XDocument.Load(NomeArquivo).Descendants("restaurante");
        }

        public double CapacidadeMedia() 
        { 
            return (
                from n in XDocument.Load(NomeArquivo).Descendants("restaurante")
                select Convert.ToInt32(n.Attribute("capacidade").Value)).Average();
        }

        public IList<string> ObterNomes() 
        {
        //    var resultado = new List<string>();

        //    var nodos = XDocument.Load(NomeArquivo).Descendants("restaurante");

        //    foreach (var item in nodos)
        //    {
        //        resultado.Add(item.Attribute("nome").Value);
        //    }

        //    return resultado;
           /* return XDocument
                .Load(NomeArquivo)
                .Descendants("restaurante")
                .Select(n => n.Attribute("nome").Value)
                .ToList(); */

            /*
            var res = XDocument.Load(NomeArquivo).Descendants("restaurante").Select(n => new Restaurante
            {
                Nome = n.Attribute("nome").Value,
                Capacidade = Convert.ToInt32(n.Attribute("capacidade").value)
            });
            */

            /*return (
                    from n in XDocument.Load(NomeArquivo).Descendants("restaurante")
                    orderby n.Attribute("nome").Value
                    select n.Attribute("nome").Value
                    ).ToList();*/

            return (
                from n in XDocument.Load(NomeArquivo).Descendants("restaurante")
                orderby n.Attribute("nome").Value
                where Convert.ToInt32(n.Attribute("capacidade").Value) < 100
                select n.Attribute("nome").Value).ToList();
        }


        public IEnumerable<Restaurante> TodosRestaurantes()
        {
            return (
                from n in restaurantes
                let contato = n.Element("contato")
                let site = contato != null && contato.Element("site") != null ? contato.Element("site").Value : null
                let telefone = contato != null && contato.Element("telefone") != null ? contato.Element("telefone").Value : null
                let localizacao = n.Element("localizacao")
                select new Restaurante
                {
                     Nome = n.Attribute("nome").Value,
                     Capacidade = Convert.ToInt32(n.Attribute("capacidade").Value),
                     Categoria = (Categoria)Enum.Parse(typeof(Categoria), n.Attribute("categoria").Value, ignoreCase: true),
                     Contato = new Contato
                     {
                          Site = site,
                          Telefone = telefone
                     },
                     Localizacao = new Localizacao
                     {
                          Bairro = localizacao.Element("bairro").Value,
                          Logradouro = localizacao.Element("logradouro").Value,
                          Latitude = Convert.ToDouble(localizacao.Element("latitude").Value),
                          Longitude = Convert.ToDouble(localizacao.Element("longitude").Value)
                     }
                }
            );
        }
    }
}
