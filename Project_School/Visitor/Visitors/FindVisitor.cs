using Project_School.Interfaces.Common;
using Project_School.Interfaces.Visitor;

namespace Project_School.Visitor.Visitors;

public class FindVisitor : IVisitor
{
    public string Args { private get; set; }

    public FindVisitor(string _args)
    {
        Args = _args;
    }
    
    

    public void VisitClass(IClass element)
    {
        throw new NotImplementedException();
    }

    public void VisitRoom(IRoom element)
    {
        throw new NotImplementedException();
    }

    public void VisitStudent(IStudent element)
    {
        throw new NotImplementedException();
    }

    public void VisitTeacher(ITeacher element)
    {
        throw new NotImplementedException();
    }
}