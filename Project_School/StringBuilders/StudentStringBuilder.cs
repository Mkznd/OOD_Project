using Project_School.Interfaces.Common;

namespace Project_School.StringBuilders;

public static class StudentStringBuilder
{
    public static string GetString(IStudent student)
    {
        return $"{string.Join(" ", student.Names)} {student.Surname} {student.Semester}";
    }
}