using Project_School.Interfaces.CLI;

namespace Project_School.Interfaces.Common;

public interface IHuman : ICanBeVisited
{
    public List<string> Names { get; set; }
    public string Surname { get; set; }
}