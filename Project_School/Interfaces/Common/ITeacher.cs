using Project_School.Enums;
using Project_School.Interfaces.CLI;

namespace Project_School.Interfaces.Common;

public interface ITeacher : IHuman
{
    public TeacherRank Rank { get; set; }
    public string Code { get; set; }
    public List<IClass>? Classes { get; set; }

    void ICanBeVisited.Accept(IVisitor visitor)
    {
        visitor.VisitTeacher(this);
    }
}