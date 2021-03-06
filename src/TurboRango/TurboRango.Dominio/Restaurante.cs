﻿
namespace TurboRango.Dominio
{
    public class Restaurante : Entidade
    { 
        /// <summary>
        /// Capacidade (lotação máxima) do restaurante
        /// </summary>
        public int? Capacidade { get; set; }
        public string Nome { get; set; }
        public Localizacao Localizacao { get; set; }
        public Contato Contato { get; set; }
        public Categoria Categoria { get; set; }


    }
}
