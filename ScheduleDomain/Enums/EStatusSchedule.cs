using System.ComponentModel;

namespace ScheduleDomain.Enums;

public enum EStatusSchedule
{
    [Description("Em Andamento")]
    InProgress = 0,
    [Description("Finalizado")]
    Finished = 1,
    [Description("Cancelado")]
    Cancel = 2,
}