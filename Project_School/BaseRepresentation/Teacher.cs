﻿using Project_School.Enums;
using Project_School.Interfaces.Common;
using Project_School.Lists;
using Project_School.StringBuilders;

namespace Project_School.BaseRepresentation;

public class Teacher : ITeacher
{
    public Teacher()
    {
        Names = new List<string>();
        Surname = string.Empty;
        Rank = default;
        Code = string.Empty;
        Classes = default;
    }

    public Teacher(List<string> names, string surname, TeacherRank rank, string code, List<IClass>? classes = null)
    {
        Names = names;
        Surname = surname;
        Rank = rank;
        Code = code;
        Classes = classes;
        TeacherList.AddToList(this);
    }

    public TeacherRank Rank { get; set; }
    public string Code { get; set; }
    public List<string> Names { get; set; }
    public string Surname { get; set; }
    public List<IClass>? Classes { get; set; }

    public override string ToString()
    {
        return TeacherStringBuilder.GetString(this);
    }
}