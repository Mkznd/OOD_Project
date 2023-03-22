namespace Project_School.BaseRepresentation;

public class Teacher: IHuman, ITeacher
{
   
    public Teacher(List<string> names, string surname, TeacherRank rank, string code, List<IClass>? classes = null)
    {
        Names = names;
        Surname = surname;
        Rank = rank;
        Code = code;
        Classes = classes;
    }
    public TeacherRank Rank { get; set; }
    public string Code { get; set; }
    public List<string> Names { get; set; }
    public string Surname { get; set; }
    public List<IClass>? Classes { get; set; }
    
    public override string ToString()
    {
        return $"{string.Join(" ", Names)} {Surname} {Code}";
    }
}