using Project_School.BaseRepresentation;
using Project_School.FirstRepresentation;

namespace Project_School;

internal static class Program
{
    public static void Main()
    {
        var ns = new List<string>()
        {
            "A",
            "B",
            "C"
        };
        var nt = new List<string>()
        {
            "tA",
            "tB",
            "tC"
        };
      
        var students = new List<IHuman>()
        {
            new Student(ns, "sur1", 3),
            new Student(ns, "sur2", 2),
            new Student(ns, "sur3", 1)
        };
        var teachers = new List<ITeacher>()
        {
            new Teacher(nt, "sur1", TeacherRank.GiB, "code1"),
            new Teacher(nt, "sur2", TeacherRank.MiB, "code2"),
            new Teacher(nt, "sur3", TeacherRank.KiB, "code3 ")
        };
        var a = new ClassString("c_nameAaaaa", "codeAaaa", 3, teachers, students);
        var classes = new List<IClass>()
        {
            new Class("c_nameA", "codeA", 3, teachers, students),
            new ClassAdapter(a),
        };
        students.ForEach(Console.WriteLine);
        teachers.ForEach(Console.WriteLine);
        classes.ForEach(Console.WriteLine);
    }
}

