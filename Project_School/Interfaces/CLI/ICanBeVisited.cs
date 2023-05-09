namespace Project_School.Interfaces.CLI;

public interface ICanBeVisited
{
    void Accept(IVisitor visitor);
}