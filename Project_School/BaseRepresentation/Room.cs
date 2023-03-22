using Project_School.Enums;
using Project_School.Interfaces;

namespace Project_School.BaseRepresentation;

public class Room : IRoom
{
    public Room(uint number, RoomType type, List<IClass> classes)
    {
        Number = number;
        Type = type;
        Classes = classes;
        RoomList.AddToList(this);
    }

    public uint Number { get; set; }
    public RoomType Type { get; set; }
    public List<IClass>? Classes { get; set; }

    public override string ToString()
    {
        return $"{Type} {Number}";
    }
}