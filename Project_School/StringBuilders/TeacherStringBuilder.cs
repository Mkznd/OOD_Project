using Project_School.Interfaces;
using Project_School.Interfaces.Common;

namespace Project_School.StringBuilders;

public static class TeacherStringBuilder
{
    public static string GetString(ITeacher teacher)
    {
        return $"{teacher.Rank} {string.Join(" ", teacher.Names)} {teacher.Surname} {teacher.Code}";
    }
}