namespace Project_School.FirstRepresentation;

public class TeacherString: ITeacher
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
        TeacherList.Teachers.Add(TeacherList.GetId(this), this);
        Classes = classes?.Select(ClassList.GetId).ToList();
    }

    public override string ToString()
    {
        return $"{Rank}{string.Join(" ", Names)} {Surname} {Code}";
    }

    public List<string> Names { get; set; }
    public string Surname { get; set; }
    public List<string>? Classes { get; set; }
}