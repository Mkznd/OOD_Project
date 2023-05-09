using Project_School.Lists;
using Project_School.SecondRepresentation.Adapters;

namespace Project_School.SecondRepresentation;

public class RoomTuple
{
    // ReSharper disable once FieldCanBeMadeReadOnly.Global
    public List<Tuple<string, object>> Fields;

    public RoomTuple(List<Tuple<string, object>> fields)
    {
        Fields = fields;
        RoomList.AddToList(new RoomTupleAdaptor(this));
    }
}