using Project_School.Enums;
using Project_School.FirstRepresentation.Adapters;
using Project_School.Interfaces.Common;
using Project_School.Lists;

namespace Project_School.FirstRepresentation;

public class TeacherString
{
    public TeacherString()
    {
        Names = new List<string>();
        Surname = string.Empty;
        Rank = default;
        Code = string.Empty;
        Classes = default;
    }

    public TeacherString(List<string> names, string surname, TeacherRank rank,
        string code, List<IClass>? classes = null)
    {
        Names = names;
        Surname = surname;
        Rank = rank;
        Code = code;
        Classes = classes?.Select(ClassList.GetId).ToList();
        TeacherList.AddToList(new TeacherStringAdapter(this));
    }

    public TeacherRank Rank { get; set; }
    public string Code { get; set; }

    public List<string> Names { get; set; }
    public string Surname { get; set; }
    public List<string>? Classes { get; set; }
}