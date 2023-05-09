using Project_School.Interfaces.CLI;

namespace Project_School.Interfaces.Common;

public interface IClass : ICanBeVisited
{
    public string Name { get; set; }
    public string Code { get; set; }
    public uint Duration { get; set; }
    public List<ITeacher> Teachers { get; set; }
    public List<IHuman> Students { get; set; }

    void ICanBeVisited.Accept(IVisitor visitor)
    {
        visitor.VisitClass(this);
    }

    public string GetString()
    {
        return $"{Code} {Name}\nTeachers: {string.Join(' ', Teachers)}\nStudents: {string.Join(' ', Students)}";
    }
}