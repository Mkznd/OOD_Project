namespace Project_School.FirstRepresentation;


public class ClassString : IStringClass
{
    public static readonly Dictionary<string, ClassString> Classes = new();

    public ClassString(string name, string code, uint duration, List<TeacherString> teachers,
        List<StudentString> students) 
    {
        Name = name;
        Code = code;
        Duration = duration;
        Teachers = teachers.Select(TeacherString.GetId).ToList();
        Students = students.Select(StudentString.GetId).ToList();
        Classes.Add(GetId(this), this);
    }

    public string Name { get; set; }
    public string Code { get; set; }
    public uint Duration { get; set; }
    public List<string> Teachers { get; set; }
    public List<string> Students { get; set; }

    public override string ToString()
    {
        return $"{Code} {Name} {string.Join(' ', Students)} {string.Join(' ', Students)}";
    }

    public static string GetId(ClassString classString)
    {
        return $"{classString.Name}{classString.Code}{classString.Duration}";
    }
}