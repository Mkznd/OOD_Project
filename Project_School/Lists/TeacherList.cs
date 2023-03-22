using Project_School.Interfaces;

namespace Project_School.Lists;

public static class TeacherList
{
    public static readonly Dictionary<string, ITeacher> Teachers = new();
    
    public static string GetId(ITeacher teacherString)
    {
        return $"{teacherString.Rank}{string.Join(' ', teacherString.Names)}" +
               $"{teacherString.Surname}{teacherString.Code}";
    }
    public static void AddToList(ITeacher teacher)
    {
        Teachers.Add(GetId(teacher), teacher);
    }
}