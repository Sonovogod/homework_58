using System.ComponentModel;

namespace ToDoList.Enums;

public enum PriorityState
{
    [Description("Высокий")]
    Hi,
    [Description("Средний")]
    Midle,
    [Description("Низкий")]
    Low
}