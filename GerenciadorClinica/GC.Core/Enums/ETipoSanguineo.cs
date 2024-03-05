using System.ComponentModel;

namespace GC.Core.Enums
{
    /// <summary>
    /// Enumerador destinado aos tipos sanguíneos 
    /// </summary>
    public enum ETipoSanguineo
    {
        /// <summary>
        /// Tipo A Positivo
        /// </summary>
        [Description("Tipo A +")]
        A_Positivo = 0,

        /// <summary>
        /// Tipo A Negativo
        /// </summary>
        [Description("Tipo A -")]
        A_Negativo = 1,

        /// <summary>
        /// Tipo B Positivo
        /// </summary>
        [Description("Tipo B +")]
        B_Positivo = 2,

        /// <summary>
        /// Tipo B Negativo
        /// </summary>
        [Description("Tipo B -")]
        B_Negativo = 3,

        /// <summary>
        /// Tipo AB Positivo
        /// </summary>
        [Description("Tipo AB +")]
        AB_Positivo = 4,

        /// <summary>
        /// Tipo AB Negativo
        /// </summary>
        [Description("Tipo AB -")]
        AB_Negativo = 5,

        /// <summary>
        /// Tipo O Positivo
        /// </summary>
        [Description("Tipo O +")]
        O_Positivo = 6,

        /// <summary>
        /// Tipo O Negativo
        /// </summary>
        [Description("Tipo O -")]
        O_Negativo= 7
    }
}
