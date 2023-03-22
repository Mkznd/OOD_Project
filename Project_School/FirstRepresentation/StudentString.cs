namespace Project_School.FirstRepresentation;

public class StudentString
{
    public uint Semester { get; set; }
    public StudentString(List<string> names, string surname, uint semester, List<IClass>? classes = null)
    {
        Names = names;
        Surname = surname;
        Semester = semester;
        var studentAdapter = new StudentAdapter(this);
        StudentList.Students.Add(StudentList.GetId(studentAdapter), studentAdapter);
        Classes = classes?.Select(ClassList.GetId).ToList();
    }
    public List<string> Names { get; set; }
    public string Surname { get; set; }
    public List<string>? Classes { get; set; }
}