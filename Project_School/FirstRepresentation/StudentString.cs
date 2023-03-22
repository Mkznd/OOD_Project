namespace Project_School.FirstRepresentation;

public class StudentString : IStudent
{
    public static readonly Dictionary<string, IStudent> Students = new();
    
    public uint Semester { get; set; }
    public StudentString(List<string> names, string surname, uint semester, List<ClassString>? classes = null)
    {
        Names = names;
        Surname = surname;
        Semester = semester;
        Students.Add(GetId(this), this);
        Classes = classes?.Select(ClassString.GetId).ToList();
    }

    public override string ToString()
    {
        return $"{string.Join(" ", Names)} {Surname} {Semester}";
    }

    public static string GetId(IHuman studentString)
    {
        return $"{string.Join(' ', studentString.Names)}{studentString.Surname}";
    }

    public List<string> Names { get; set; }
    public string Surname { get; set; }
    public List<string>? Classes { get; set; }
}