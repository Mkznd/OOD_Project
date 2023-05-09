using Project_School.Interfaces.Common;

namespace Project_School.Lists;

public static class RoomList
{
    public static readonly Dictionary<string, IRoom> Rooms = new();

    public static string GetId(IRoom room)
    {
        return $"{room.Type}{room.Number}";
    }

    public static void AddToList(IRoom room)
    {
        Rooms.Add(GetId(room), room);
    }
}