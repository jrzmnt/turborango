using System;
using System.ComponentModel;
namespace TurboRango.Dominio
{
    public enum Categoria
    {
        [Description("Comum")]
        Comum,
        [Description("Cozinha Natural")]
        CozinhaNatural,
        [Description("Cozinha Mexicana")]
        CozinhaMexicana,
        [Description("Churrascaria")]
        Churrascaria,
        [Description("Cozinha Japonesa")]
        CozinhaJaponesa,
        [Description("Fast Food")]
        FastFood,
        [Description("Pizzaria")]
        Pizzaria
    }
}
