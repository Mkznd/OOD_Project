using Project_School.Enums;
using Project_School.Interfaces.Common;

namespace Project_School.SecondRepresentation.Adapters;

public class TeacherTupleAdapter : ITeacher
{
    private const string NamesString = "Names";
    private const string SurnameString = "Surname";
    private const string RankString = "Rank";
    private const string CodeString = "Code";
    private const string ClassesString = "Classes";

    private readonly TeacherTuple _teacherTuple;

    public TeacherTupleAdapter(TeacherTuple teacherTuple)
    {
        _teacherTuple = teacherTuple;
    }

    public List<string> Names
    {
        get => _teacherTuple.Fields.Where(f => f.Item1 == NamesString)
            .Select(f => (List<string>) f.Item2).FirstOrDefault() ?? new List<string>();
        set => throw new NotImplementedException();
    }

    public string Surname
    {
        get =>
            _teacherTuple.Fields.Where(f => f.Item1 == SurnameString)
                .Select(f => (string) f.Item2).FirstOrDefault() ?? string.Empty;
        set => throw new NotImplementedException();
    }

    public TeacherRank Rank
    {
        get =>
            _teacherTuple.Fields.Where(f => f.Item1 == RankString)
                .Select(f => (TeacherRank) f.Item2).FirstOrDefault();
        set => throw new NotImplementedException();
    }

    public string Code
    {
        get =>
            _teacherTuple.Fields.Where(f => f.Item1 == CodeString)
                .Select(f => (string) f.Item2).FirstOrDefault() ?? string.Empty;
        set => throw new NotImplementedException();
    }

    public List<IClass>? Classes
    {
        get => _teacherTuple.Fields.Where(f => f.Item1 == ClassesString)
            .Select(f => (List<IClass>?) f.Item2).FirstOrDefault();
        set => throw new NotImplementedException();
    }
}