﻿using Project_School.Lists;
using Project_School.SecondRepresentation.Adapters;

namespace Project_School.SecondRepresentation;

public class TeacherTuple
{
    // ReSharper disable once FieldCanBeMadeReadOnly.Global
    public List<Tuple<string, object>> Fields;

    public TeacherTuple(List<Tuple<string, object>> fields)
    {
        Fields = fields;
        TeacherList.AddToList(new TeacherTupleAdapter(this));
    }
}