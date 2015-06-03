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

            #region ADO.NET

            //var connString = @"Data Source=.;Initial Catalog=TurboRango_dev;Integrated Security=True;";
            var connString = @"Data Source=.;Initial Catalog=TurboRango_dev;UID=sa;PWD=feevale;";
            var acessoAoBanco = new CarinhaQueManipulaOBanco(connString);


            acessoAoBanco.Inserir(new Contato { 
            Site="www.dogao.gif",
            Telefone="5555555555"
            });

            IEnumerable<Contato> contatos = acessoAoBanco.GetContatos();

            #endregion
            /*
            const string nomeArquivo = ("restaurantes.xml");
            var restaurantesXML = new RestaurantesXML(nomeArquivo);
            var nomes = restaurantesXML.ObterNomes();
            var capacidadeMedia = restaurantesXML.CapacidadeMedia();

            var ex1a = restaurantesXML.OrdenarPorNomeAsc();
            var ex1b = restaurantesXML.ObterSites();
            var ex1c = restaurantesXML.CapacidadeMedia();
            var ex1d = restaurantesXML.AgruparPorCategoria();
            var ex1e = restaurantesXML.ApenasComUmRestaurante();
            var ex1f = restaurantesXML.ApenasMaisPopulares();
            var ex1g = restaurantesXML.BairrosComMenosPizzarias();
            var ex1h = restaurantesXML.AgrupadosPorBairroPercentual();

            //ex. 2a
            var todos = restaurantesXML.TodosRestaurantes();

            */


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
