using Project_School.Interfaces.Visitor;

namespace Project_School.Interfaces.Common;

public interface IStudent : IHuman
{
    public uint Semester { get; set; }
    public List<IClass>? Classes { get; set; }

    void ICanBeVisited.Accept(IVisitor visitor)
    {
        visitor.VisitStudent(this);
    }
}