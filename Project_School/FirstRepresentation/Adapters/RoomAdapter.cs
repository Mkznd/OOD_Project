using Project_School.Enums;
using Project_School.Interfaces;
using Project_School.Lists;
using Project_School.StringBuilders;

namespace Project_School.FirstRepresentation.Adapters;

public class RoomAdapter : IRoom
{
    private readonly RoomString _roomString;
    private List<IClass> GetClasses()
    {
        if (_roomString.Classes == null) return new List<IClass>();
        return ClassList.Classes
            .Where(kvp=> _roomString.Classes.Contains(kvp.Key))
            .Select(kvp => kvp.Value).ToList();
    }
    public RoomAdapter(RoomString roomString)
    {
        _roomString = roomString;
    }

    public uint Number
    {
        get => _roomString.Number;
        set => _roomString.Number = value;
    }

    public RoomType Type
    {
        get => _roomString.Type;
        set => _roomString.Type = value;
    }

    public List<IClass>? Classes
    {
        get => GetClasses();
        set => _roomString.Classes = value?.Select(ClassList.GetId).ToList();
    }
    public override string ToString()
    {
        return RoomStringBuilder.GetString(this);
    }
}