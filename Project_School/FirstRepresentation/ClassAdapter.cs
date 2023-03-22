namespace Project_School.FirstRepresentation;

public class ClassAdapter : IClass
{
    private List<ITeacher> GetTeachers()
    {
        return TeacherList.Teachers
            .Where(kvp=> _classString.Teachers.Contains(kvp.Key))
            .Select(kvp => kvp.Value).ToList();
    }
    
    private List<IHuman> GetStudents()
    {
        return StudentList.Students
            .Where(kvp=> _classString.Students.Contains(kvp.Key))
            .Select(kvp => kvp.Value).Select(s => (IHuman)s).ToList();
    }
    public ClassAdapter(ClassString classString)
    {
        _classString = classString;
    }

    public string Name {
        get => _classString.Name;
        set => _classString.Name = value;
    }
    public string Code {
        get => _classString.Code;
        set => _classString.Code = value;
    }
    public uint Duration
    {
        get => _classString.Duration;
        set => _classString.Duration = value;
    }

    public List<ITeacher> Teachers
    {
        get => GetTeachers();
        set => _classString.Teachers = value.Select(TeacherList.GetId).ToList();
    }

    public List<IHuman> Students
    {
        get => GetStudents();
        set => _classString.Students = value.Select(StudentList.GetId).ToList();
    }
    public override string ToString()
    {
        return $"{Code} {Name}\nTeachers: {string.Join(' ', Teachers)}\nStudents: {string.Join(' ', Students)}";
    }

    private readonly ClassString _classString;
}