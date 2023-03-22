using Project_School.Enums;

namespace Project_School.Interfaces;

public interface ITeacher : IHuman
{
    public TeacherRank Rank { get; set; }
    public string Code { get; set; }
    public List<IClass>? Classes { get; set; }

}