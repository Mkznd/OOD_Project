namespace Project_School.BaseRepresentation;

public class Student : IHuman, IStudent
{
    public Student(List<string> names, string surname, uint semester, List<IClass>? classes = null)
    {
        Names = names;
        Surname = surname;
        Semester = semester;
        Classes = classes;
    }
    public uint Semester { get; set; }
    public override string ToString()
    {
        return $"{string.Join(" ", Names)} {Surname} {Semester}";
    }

    public List<string> Names { get; set; }
    public string Surname { get; set; }
    public List<IClass>? Classes { get; set; }
}