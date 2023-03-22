namespace Project_School.FirstRepresentation;

public class StudentString : IStudent
{
    public uint Semester { get; set; }
    public StudentString(List<string> names, string surname, uint semester, List<IClass>? classes = null)
    {
        Names = names;
        Surname = surname;
        Semester = semester;
        StudentList.Students.Add(StudentList.GetId(this), this);
        Classes = classes?.Select(ClassList.GetId).ToList();
    }

    public override string ToString()
    {
        return $"{string.Join(" ", Names)} {Surname} {Semester}";
    }

    public List<string> Names { get; set; }
    public string Surname { get; set; }
    public List<string>? Classes { get; set; }
}