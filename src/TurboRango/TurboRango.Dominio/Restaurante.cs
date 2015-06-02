
namespace TurboRango.Dominio
{
    class Restaurante
    { 
        /// <summary>
        /// Capacidade (lotação máxima) do restaurante
        /// </summary>
        internal int Capacidade { get; set; }
        internal string Nome { get; set; }
        internal Localizacao Localizacao { get; set; }
        internal Contato Contato { get; set; }
        internal Categoria Categoria { get; set; }


    }
}
