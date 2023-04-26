using Project_School.Interfaces.Visitor;

namespace Project_School.Interfaces.Common;

public interface ICanBeVisited
{
    void Accept(IVisitor visitor);
}