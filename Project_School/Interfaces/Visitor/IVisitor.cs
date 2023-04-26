using Project_School.Interfaces.Common;

namespace Project_School.Interfaces.Visitor;

public interface IVisitor
{
    void VisitClass(IClass element, string args = "");
    void VisitRoom(IRoom element, string args = "");
    void VisitStudent(IStudent element, string args = "");
    void VisitTeacher(ITeacher element, string args = "");
}