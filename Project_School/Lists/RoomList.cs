using Project_School.Interfaces;

namespace Project_School;

public static class RoomList
{
    public static readonly Dictionary<string, IRoom> Rooms = new();
    public static string GetId(IRoom room)
    {
        return $"{room.Type}{room.Number}";
    }
    public static void AddToList(IRoom room)
    {
        //TODO MORE ABSTRACTION TO EVERY CLASS
        Rooms.Add(GetId(room), room);
    }
}