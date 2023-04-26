using Project_School.Enums;
using Project_School.Interfaces.Visitor;

namespace Project_School.Interfaces.Common;

public interface IRoom : ICanBeVisited
{
    public uint Number { get; set; }
    public RoomType Type { get; set; }
    public List<IClass>? Classes { get; set; }
    
    void ICanBeVisited.Accept(IVisitor visitor)
    {
        visitor.VisitRoom(this);
    }
}