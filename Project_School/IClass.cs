
namespace Project_School;

public interface IClass
{
    public string Name { get; set; }
    public string Code { get; set; }
    public uint Duration { get; set; }
    public List<ITeacher> Teachers { get; set; }
    public List<IHuman> Students { get; set; }
}