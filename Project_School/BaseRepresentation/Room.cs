using Project_School.Enums;

namespace Project_School.BaseRepresentation;


public class Room
{
    public Room(uint number, RoomType type, List<Class> classes)
    {
        Number = number;
        Type = type;
        Classes = classes;
    }

    public uint Number { get; set; }
    public RoomType Type { get; set; }
    public List<Class> Classes { get; set; }
}