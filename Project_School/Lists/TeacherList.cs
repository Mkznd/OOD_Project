using Project_School.Interfaces;

namespace Project_School;

public static class TeacherList
{
    public static readonly Dictionary<string, ITeacher> Teachers = new();
    
    public static string GetId(ITeacher teacherString)
    {
        return $"{teacherString.Rank}{string.Join(' ', teacherString.Names)}" +
               $"{teacherString.Surname}{teacherString.Code}";
    }
}