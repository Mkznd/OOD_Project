﻿using Project_School.Enums;
using Project_School.FirstRepresentation.Adapters;
using Project_School.Lists;

namespace Project_School.FirstRepresentation;

public class RoomString
{
    public RoomString()
    {
        Number = 0;
        Type = default;
        Classes = new List<string>();
    }

    public RoomString(uint number, RoomType type, List<string>? classes)
    {
        Number = number;
        Type = type;
        Classes = classes;
        RoomList.AddToList(new RoomStringAdapter(this));
    }

    public uint Number { get; set; }
    public RoomType Type { get; set; }
    public List<string>? Classes { get; set; }
}