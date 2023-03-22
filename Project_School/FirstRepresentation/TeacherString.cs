using Project_School.Enums;
using Project_School.FirstRepresentation.Adapters;
using Project_School.Interfaces;

namespace Project_School.FirstRepresentation;

public class TeacherString
{
    public TeacherRank Rank { get; set; }
    public string Code { get; set; }
    public TeacherString(List<string> names, string surname, TeacherRank rank,
        string code, List<IClass>? classes = null)
    {
        Names = names;
        Surname = surname;
        Rank = rank;
        Code = code;
        var teacherAdapter = new TeacherAdapter(this);
        TeacherList.Teachers.Add(TeacherList.GetId(teacherAdapter), teacherAdapter);
        Classes = classes?.Select(ClassList.GetId).ToList();
    }

    public List<string> Names { get; set; }
    public string Surname { get; set; }
    public List<string>? Classes { get; set; }
}