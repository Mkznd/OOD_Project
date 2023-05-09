using Project_School.Interfaces.Common;

namespace Project_School.Lists;

public static class StudentList
{
    public static readonly Dictionary<string, IStudent> Students = new();

    public static string GetId(IHuman studentString)
    {
        return $"{string.Join(' ', studentString.Names)}{studentString.Surname}";
    }

    public static void AddToList(IStudent student)
    {
        Students.Add(GetId(student), student);
    }
}