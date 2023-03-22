namespace Project_School.Interfaces;

public interface IClass
{
    public string Name { get; set; }
    public string Code { get; set; }
    public uint Duration { get; set; }
    public List<ITeacher> Teachers { get; set; }
    public List<IHuman> Students { get; set; }
    public string GetString()
    {
        return $"{Code} {Name}\nTeachers: {string.Join(' ', Teachers)}\nStudents: {string.Join(' ', Students)}";
    }
}