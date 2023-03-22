﻿using Project_School.Interfaces;
using Project_School.StringBuilders;

namespace Project_School.BaseRepresentation;

public class Student : IStudent
{
    public Student(List<string> names, string surname, uint semester, List<IClass>? classes = null)
    {
        Names = names;
        Surname = surname;
        Semester = semester;
        Classes = classes;
        StudentList.Students.Add(StudentList.GetId(this), this);
    }
    public uint Semester { get; set; }
    public List<string> Names { get; set; }
    public string Surname { get; set; }
    public List<IClass>? Classes { get; set; }
    public override string ToString()
    {
        return StudentStringBuilder.GetString(this);
    }
}