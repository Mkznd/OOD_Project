namespace Project_School.Interfaces;

public interface IStudent : IHuman
{
    public uint Semester { get; set; }
    public List<IClass>? Classes { get; set; }

}