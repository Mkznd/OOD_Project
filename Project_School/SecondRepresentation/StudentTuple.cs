using Project_School.Lists;
using Project_School.SecondRepresentation.Adapters;

namespace Project_School.SecondRepresentation;

public class StudentTuple
{
    // ReSharper disable once FieldCanBeMadeReadOnly.Global
    public List<Tuple<string, object>> Fields;

    public StudentTuple(List<Tuple<string, object>> fields)
    {
        Fields = fields;
        StudentList.AddToList(new StudentTupleAdapter(this));
    }
}