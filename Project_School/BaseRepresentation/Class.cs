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
        ClassList.Classes.Add(ClassList.GetId(this), this);
    }

    public string Name { get; set; }
    public string Code { get; set; }
    public uint Duration { get; set; }
    public List<ITeacher> Teachers { get; set; }
    public List<IHuman> Students { get; set; }

    public override string ToString()
    {
        return $"{Code} {Name}\nTeachers: {string.Join(' ', Teachers)}\nStudents: {string.Join(' ', Students)}";
    }
}