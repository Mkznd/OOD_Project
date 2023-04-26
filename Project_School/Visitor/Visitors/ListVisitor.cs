using Project_School.Interfaces.Common;
using Project_School.Interfaces.Visitor;

namespace Project_School.Visitor.Visitors;

public class ListVisitor : IVisitor
{
    public void VisitClass(IClass element, string args)
    {
        Console.WriteLine($"{element.Name} {element.Code} {element.Duration}");
    }

    public void VisitRoom(IRoom element, string args)
    {
        Console.WriteLine($"{element.Number} {element.Type}");
    }

    public void VisitStudent(IStudent element, string args)
    {
        Console.WriteLine($"{string.Join(" ", element.Names)} {element.Surname} {element.Semester}");
    }

    public void VisitTeacher(ITeacher element, string args)
    {
        Console.WriteLine($"{string.Join(" ", element.Names)} {element.Surname} {element.Code} {element.Rank}");
    }
}