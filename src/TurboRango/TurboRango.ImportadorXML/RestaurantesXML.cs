using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
    }
}
