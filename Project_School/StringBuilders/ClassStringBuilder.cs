using Project_School.Interfaces;

namespace Project_School.StringBuilders;

public static class ClassStringBuilder
{
    public static string GetString(IClass @class)
    {
        return $"{@class.Code} {@class.Name}" +
               $"\nTeachers: {string.Join(", ", @class.Teachers)}" +
               $"\nStudents: {string.Join(", ", @class.Students)}";
    }
}