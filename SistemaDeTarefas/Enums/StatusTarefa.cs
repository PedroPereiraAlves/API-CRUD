using System.ComponentModel;

namespace SistemaDeTarefas.Enums
{
    public enum StatusTarefa
    {
        [Description("Por Fazer")]
        Por_Fazer = 1,
        [Description("Andamento")]
        Em_Andamento = 2,
        [Description("Concluido")]
        Concluido = 3
    }
}
