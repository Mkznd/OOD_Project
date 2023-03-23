using Project_School.Interfaces;

namespace Project_School.SecondRepresentation.Adapters;

public class StudentTupleAdapter : IStudent
{
    private const string NamesString = "Names";
    private const string SurnameString = "Surname";
    private const string SemesterString = "Semester";
    private const string ClassesString = "Classes";
    
    private readonly StudentTuple _studentTuple;
    public StudentTupleAdapter(StudentTuple studentTuple)
    {
        _studentTuple = studentTuple;
    }

    public List<string> Names {
        get => _studentTuple.Fileds.Where(f => f.Item1 == NamesString)
            .Select(f => (List<string>) f.Item2).FirstOrDefault() ?? new List<string>();
        set => throw new NotImplementedException();
    }
    public string Surname{
        get =>
            _studentTuple.Fileds.Where(f => f.Item1 == SurnameString)
                .Select(f => (string) f.Item2).FirstOrDefault() ?? string.Empty;
        set => throw new NotImplementedException();
    }
    public uint Semester
    {
        get =>
            _studentTuple.Fileds.Where(f => f.Item1 == SemesterString)
                .Select(f => (uint) (int) f.Item2).FirstOrDefault();
        set => throw new NotImplementedException();
    }
    public List<IClass>? Classes {
        get => _studentTuple.Fileds.Where(f => f.Item1 == ClassesString)
            .Select(f => (List<IClass>?) f.Item2).FirstOrDefault();
        set => throw new NotImplementedException();
    }
}