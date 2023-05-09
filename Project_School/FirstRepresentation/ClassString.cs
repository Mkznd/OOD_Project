using Project_School.FirstRepresentation.Adapters;
using Project_School.Interfaces.Common;
using Project_School.Lists;

namespace Project_School.FirstRepresentation;

public class ClassString
{
    public ClassString()
    {
        Name = string.Empty;
        Code = string.Empty;
        Duration = 0;
        Teachers = new List<string>();
        Students = new List<string>();
        ClassList.AddToList(new ClassStringAdapter(this));
    }
    public ClassString(string name, string code, uint duration, IEnumerable<ITeacher> teachers,
        IEnumerable<IHuman> students)
    {
        Name = name;
        Code = code;
        Duration = duration;
        Teachers = teachers.Select(TeacherList.GetId).ToList();
        Students = students.Select(StudentList.GetId).ToList();
        ClassList.AddToList(new ClassStringAdapter(this));
    }

    public string Name { get; set; }
    public string Code { get; set; }
    public uint Duration { get; set; }
    public List<string> Teachers { get; set; }
    public List<string> Students { get; set; }
}