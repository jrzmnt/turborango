using System;
using System.ComponentModel;
namespace TurboRango.Dominio
{
    public enum Categoria
    {
        [Description("Comum")]
        COMUM,
        [Description("Cozinha Natural")]
        COZINHA_NATURAL,
        [Description("Cozinha Mexicana")]
        COZINHA_MEXICANA,
        [Description("Churrascaria")]
        CHURRASCARIA,
        [Description("Cozinha Japonesa")]
        COZINHA_JAPONESA,
        [Description("Fast Food")]
        FASTFOOD,
        [Description("Pizzaria")]
        PIZZARIA
    }
}
