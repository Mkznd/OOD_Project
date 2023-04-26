using Project_School.FirstRepresentation;
using Project_School.Interfaces;
using Project_School.Interfaces.Common;
using Project_School.Lists;
using Project_School.StringBuilders;

namespace Project_School.SecondRepresentation.Adapters;

public class ClassTupleAdapter : IClass
{
    private const string NameString = "Name";
    private const string CodeString = "Code";
    private const string DurationString = "Duration";
    private const string TeachersString = "Teachers";
    private const string StudentsString = "Students";
    public ClassTupleAdapter(ClassTuple classTuple)
    {
        _classTuple = classTuple;
    }

    public string Name
    {
        get =>
            _classTuple.Fields.Where(f => f.Item1 == NameString)
                .Select(f => (string) f.Item2).FirstOrDefault() ?? string.Empty;
        set => throw new NotImplementedException();
    }

    public string Code
    {
        get =>
            _classTuple.Fields.Where(f => f.Item1 == CodeString)
                .Select(f => (string) f.Item2).FirstOrDefault() ?? string.Empty;
        set => throw new NotImplementedException();
    }

    public uint Duration
    {
        get =>
            _classTuple.Fields.Where(f => f.Item1 == DurationString)
                .Select(f =>  (uint) (int) f.Item2).FirstOrDefault();
        set => throw new NotImplementedException();
    }

    public List<ITeacher> Teachers
    {
        get =>
            _classTuple.Fields.Where(f => f.Item1 == TeachersString)
                .Select(f => (List<ITeacher>) f.Item2).FirstOrDefault() ?? new List<ITeacher>();
        set => throw new NotImplementedException();
    }

    public List<IHuman> Students
    {
        get =>
            _classTuple.Fields.Where(f => f.Item1 == StudentsString)
                .Select(f => (List<IHuman>) f.Item2).FirstOrDefault() ?? new List<IHuman>();
        set => throw new NotImplementedException();
    }

    public override string ToString()
    {
        return ClassStringBuilder.GetString(this);
    }

    private readonly ClassTuple _classTuple;
}