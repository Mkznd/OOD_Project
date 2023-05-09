using Project_School.Interfaces.Common;
using Project_School.Lists;
using Project_School.StringBuilders;

namespace Project_School.BaseRepresentation;

public class Class : IClass
{
    public Class(string name, string code, uint duration, List<ITeacher> teachers, List<IHuman> students)
    {
        Name = name;
        Code = code;
        Duration = duration;
        Teachers = teachers;
        Students = students;
        ClassList.AddToList(this);
    }

    public string Name { get; set; }
    public string Code { get; set; }
    public uint Duration { get; set; }
    public List<ITeacher> Teachers { get; set; }
    public List<IHuman> Students { get; set; }

    public override string ToString()
    {
        return ClassStringBuilder.GetString(this);
    }
}