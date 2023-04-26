using Project_School.Interfaces;
using Project_School.Interfaces.Common;
using Project_School.Lists;
using Project_School.StringBuilders;

namespace Project_School.FirstRepresentation.Adapters;

public class StudentStringAdapter : IStudent
{
    private List<IClass> GetClasses()
    {
        if (_studentString.Classes == null) return new List<IClass>();
        return ClassList.Classes
            .Where(kvp=> _studentString.Classes.Contains(kvp.Key))
            .Select(kvp => kvp.Value).ToList();
    }
    
    private readonly StudentString _studentString;
    public StudentStringAdapter(StudentString studentString)
    {
        _studentString = studentString;
    }

    public List<string> Names
    {
        get => _studentString.Names;
        set => _studentString.Names = value;
    }
    public string Surname
    {
        get => _studentString.Surname;
        set => _studentString.Surname = value;
    }

    public uint Semester
    {
        get => _studentString.Semester;
        set => _studentString.Semester = value;
    }

    public List<IClass>? Classes
    {
        get => GetClasses();
        set => _studentString.Classes = value?.Select(ClassList.GetId).ToList();
    }
    public override string ToString()
    {
        return StudentStringBuilder.GetString(this);
    }
}