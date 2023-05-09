using Project_School.Interfaces.Common;

namespace Project_School.Interfaces.CLI;

public interface IVisitor
{
    void VisitClass(IClass element);
    void VisitRoom(IRoom element);
    void VisitStudent(IStudent element);
    void VisitTeacher(ITeacher element);
}