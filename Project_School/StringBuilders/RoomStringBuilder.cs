using Project_School.Interfaces;
using Project_School.Interfaces.Common;

namespace Project_School.StringBuilders;

public static class RoomStringBuilder
{
    public static string GetString(IRoom room)
    {
        return $"{room.Type} {room.Number}";
    }
}