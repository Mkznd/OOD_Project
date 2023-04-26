namespace Project_School.Interfaces.Visitor;

public interface ICanBeVisited
{
    void Accept(IVisitor visitor);
}