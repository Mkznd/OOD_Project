using Project_School.Interfaces.Common;
using Project_School.Interfaces.Visitor;

namespace Project_School.Visitor.Visitors;

public class ListVisitor : IVisitor
{
    public void VisitClass(IClass element)
    {
        Console.WriteLine($"{element.Name} {element.Code} {element.Duration}");
    }

    public void VisitRoom(IRoom element)
    {
        Console.WriteLine($"{element.Number} {element.Type}");
    }

    public void VisitStudent(IStudent element)
    {
        Console.WriteLine($"{string.Join(" ", element.Names)} {element.Surname} {element.Semester}");
    }

    public void VisitTeacher(ITeacher element)
    {
        Console.WriteLine($"{string.Join(" ", element.Names)} {element.Surname} {element.Code} {element.Rank}");
    }
}