using System.ComponentModel;

namespace ToDoList.Enums;

public enum TaskStates
{
    [Description("Новая")]
    New,
    [Description("Открытая")]
    Open,
    [Description("Закрытая")]
    Close
}