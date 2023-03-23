using Project_School.FirstRepresentation.Adapters;
using Project_School.Interfaces;
using Project_School.Lists;

namespace Project_School.FirstRepresentation;

public class StudentString
{
    public uint Semester { get; set; }
    public StudentString(List<string> names, string surname, uint semester, List<IClass>? classes = null)
    {
        Names = names;
        Surname = surname;
        Semester = semester;
        Classes = classes?.Select(ClassList.GetId).ToList();
        StudentList.AddToList(new StudentStringAdapter(this));
    }
    public List<string> Names { get; set; }
    public string Surname { get; set; }
    public List<string>? Classes { get; set; }
}