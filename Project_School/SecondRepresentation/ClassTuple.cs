using Project_School.Lists;
using Project_School.SecondRepresentation.Adapters;

namespace Project_School.SecondRepresentation;

public class ClassTuple
{
    public readonly List<Tuple<string, object>> Fields;

    public ClassTuple(List<Tuple<string, object>> fields)
    {
        Fields = fields;
        ClassList.AddToList(new ClassTupleAdapter(this));
    }
}