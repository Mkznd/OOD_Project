using Project_School.Enums;
using Project_School.Interfaces;
using Project_School.Interfaces.Common;

namespace Project_School.SecondRepresentation.Adapters;

public class RoomTupleAdaptor : IRoom
{
    private readonly RoomTuple _roomTuple;
    private readonly string NumberString = "Number";
    private readonly string RoomTypeString = "Number";
    private const string ClassesString = "Classes";

    public RoomTupleAdaptor(RoomTuple roomTuple)
    {
        _roomTuple = roomTuple;
    }

    public uint Number
    {
        get => _roomTuple.Fields.Where(f => f.Item1 == NumberString)
            .Select(f => (uint) (int) f.Item2).FirstOrDefault();
        set => throw new NotImplementedException();
    }

    public RoomType Type
    {
        get => _roomTuple.Fields.Where(f => f.Item1 == RoomTypeString)
            .Select(f => (RoomType) f.Item2).FirstOrDefault();
        set => throw new NotImplementedException();
    }
    public List<IClass>? Classes
    {
        get => _roomTuple.Fields.Where(f => f.Item1 == ClassesString)
            .Select(f => (List<IClass>?) f.Item2).FirstOrDefault();
        set => throw new NotImplementedException();
    }
}