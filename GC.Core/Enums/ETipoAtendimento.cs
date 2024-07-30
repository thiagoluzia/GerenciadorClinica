using System.ComponentModel;

namespace GC.Core.Enums
{
    /// <summary>
    /// Enumerador destinado aos tipos de atendimento 
    /// </summary>
    public enum ETipoAtendimento
    {
        /// <summary>
        /// São os casos resultantes de acidentes pessoais ou de complicações durante a gravidez que necessitam de atenção imediata.
        /// </summary>
        [Description("Urgência")]
        Urgencia = 0,

        /// <summary>
        /// São os casos que implicam risco imediato de morte ou de lesões irreparáveis, caracterizados pelo médico assistente.
        /// </summary>
        [Description("Emergência")]
        Emergencia = 1,

        /// <summary>
        /// São consultas agendadas com antecedência.
        /// </summary>
        [Description("Consulta Eletiva")]
        Consulta_Eletiva = 2,
    }
}
