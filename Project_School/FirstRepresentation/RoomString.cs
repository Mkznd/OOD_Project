namespace Project_School.FirstRepresentation;

public enum RoomType
{
    Laboratory,
    Training,
    Lecture,
    Other
    
}

public class RoomString
{
    public RoomString(uint number, RoomType type, List<string> classes)
    {
        Number = number;
        Type = type;
        Classes = classes;
    }

    public uint Number { get; set; }
    public RoomType Type { get; set; }
    public List<string> Classes { get; set; }
}