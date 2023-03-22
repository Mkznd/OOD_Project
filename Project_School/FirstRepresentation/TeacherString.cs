namespace Project_School.FirstRepresentation;

public class TeacherString: ITeacher
{
    public static readonly Dictionary<string, ITeacher> Teachers = new();

    public TeacherRank Rank { get; set; }
    public string Code { get; set; }
    public TeacherString(List<string> names, string surname, TeacherRank rank,
        string code, List<ClassString>? classes = null)
    {
        Names = names;
        Surname = surname;
        Rank = rank;
        Code = code;
        Teachers.Add(GetId(this), this);
        Classes = classes?.Select(ClassString.GetId).ToList();
    }

    public override string ToString()
    {
        return $"{Rank}{string.Join(" ", Names)} {Surname} {Code}";
    }

    public static string GetId(ITeacher teacherString)
    {
        return $"{teacherString.Rank}{string.Join(' ', teacherString.Names)}" +
               $"{teacherString.Surname}{teacherString.Code}";
    }

    public List<string> Names { get; set; }
    public string Surname { get; set; }
    public List<string>? Classes { get; set; }
}