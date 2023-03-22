namespace Project_School;

public interface IStudent : IHuman
{
    public uint Semester { get; set; }
    public List<IClass>? Classes { get; set; }

}