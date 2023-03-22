namespace Project_School;

public interface IHuman
{
    public List<string> Names { get; set; }
    public string Surname { get; set; }
    public List<IClass>? Classes { get; set; }
}