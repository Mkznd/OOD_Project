﻿namespace Project_School.FirstRepresentation;

public class TeacherAdapter : ITeacher
{
    private List<IClass> GetClasses()
    {
        if (_teacherString.Classes == null) return new List<IClass>();
        return ClassList.Classes
            .Where(kvp=> _teacherString.Classes.Contains(kvp.Key))
            .Select(kvp => kvp.Value).ToList();
    }
    
    private readonly TeacherString _teacherString;
    public TeacherAdapter(TeacherString teacherString)
    {
        _teacherString = teacherString;
    }

    public List<string> Names
    {
        get => _teacherString.Names;
        set => _teacherString.Names = value;
    }
    public string Surname
    {
        get => _teacherString.Surname;
        set => _teacherString.Surname = value;
    }

    public TeacherRank Rank
    {
        get => _teacherString.Rank;
        set => _teacherString.Rank = value;
    }

    public string Code
    {
        get => _teacherString.Code;
        set => _teacherString.Code = value;
    }

    public List<IClass>? Classes
    {
        get => GetClasses();
        set => _teacherString.Classes = value?.Select(ClassList.GetId).ToList();
    }
    public override string ToString()
    {
        return $"{string.Join(" ", Names)} {Surname}";
    }
}