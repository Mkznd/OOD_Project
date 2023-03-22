using System.ComponentModel;

namespace Project_School.Enums;

public enum RoomType
{
    [Description("Laboratory")]
    Laboratory,
    [Description("Training")]
    Training,
    [Description("Lecture")]
    Lecture,
    [Description("Other")]
    Other
}
