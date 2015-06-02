using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurboRango.Dominio;
using System.Xml.Linq;

namespace TurboRango.ImportadorXML
{
    class Program
    {
        static void Main(string[] args)
        {

            const string nomeArquivo = ("restaurantes.xml");
            var restaurantesXML = new RestaurantesXML(nomeArquivo);
            var nomes = restaurantesXML.ObterNomes();
            var capacidadeMedia = restaurantesXML.CapacidadeMedia();

            /*Restaurante restaurante = new Restaurante();
            //Console.Write(restaurante.Capacidade);
            //Console.WriteLine(restaurante.Contato.Site);
            Console.WriteLine(restaurante.Capacidade.HasValue ?
                restaurante.Capacidade.Value.ToString() : "oi");

            Console.WriteLine(restaurante.Nome ?? "Nulo!!!"); //Coersão Nula - Se for nulo ele printa "Nulo!!" se não ele printa o nome.

            restaurante.Nome = string.Empty + " ";

            Console.WriteLine(!string.IsNullOrEmpty(restaurante.Nome.Trim()) ? "tem valor" : "não tem valor"); //Método estático que retorna se a string está vazia ou nula.
            //Console.ReadLine(); //Para depurar

            var oQueEuGosto = "Bacon";
            var texto = String.Format("Eu gosto de {0}", oQueEuGosto);
                //C# 6 - String.Format("Eu gosto de \{oQueEuGosto});
            Console.WriteLine(texto);

            StringBuilder pedreiro = new StringBuilder();
            pedreiro.AppendFormat("Eu gosto de {0}", oQueEuGosto);

            Console.WriteLine(pedreiro);*/
        }
    }
}
