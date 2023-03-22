using Project_School.Enums;

namespace Project_School.Interfaces;

public interface IRoom
{
    public uint Number { get; set; }
    public RoomType Type { get; set; }
    public List<IClass>? Classes { get; set; }
}