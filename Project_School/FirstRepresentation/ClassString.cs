﻿using Project_School.FirstRepresentation.Adapters;
using Project_School.Interfaces;
using Project_School.Lists;

namespace Project_School.FirstRepresentation;


public class ClassString
{

    public ClassString(string name, string code, uint duration, List<ITeacher> teachers,
        List<IHuman> students) 
    {
        Name = name;
        Code = code;
        Duration = duration;
        Teachers = teachers.Select(TeacherList.GetId).ToList();
        Students = students.Select(StudentList.GetId).ToList();
        ClassList.AddToList(new ClassAdapter(this));
    }

    public string Name { get; set; }
    public string Code { get; set; }
    public uint Duration { get; set; }
    public List<string> Teachers { get; set; }
    public List<string> Students { get; set; }
}