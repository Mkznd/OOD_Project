namespace Project_School;

public interface ITeacher : IHuman
{
    public TeacherRank Rank { get; set; }
    public string Code { get; set; }
    public List<IClass>? Classes { get; set; }

}