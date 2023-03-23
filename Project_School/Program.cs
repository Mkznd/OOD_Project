using Project_School.BaseRepresentation;
using Project_School.Enums;
using Project_School.FirstRepresentation;
using Project_School.FirstRepresentation.Adapters;
using Project_School.Interfaces;
using Project_School.SecondRepresentation;
using Project_School.SecondRepresentation.Adapters;

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
        var b = new ClassTuple(
            new List<Tuple<string, object>>
            {
                new("Name", "TUPLE_CLASS"),
                new("Code", "CODE_TUPLE"),
                new("Duration", 3),
                new("Teachers", teachers),
                new("Students", students)
            }
        );
        var classes = new List<IClass>()
        {
            new Class("c_nameA", "codeA", 3, teachers, students),
            new ClassStringAdapter(a),
            new ClassTupleAdapter(b),
        };
        students.ForEach(Console.WriteLine);
        teachers.ForEach(Console.WriteLine);
        classes.ForEach(Console.WriteLine);
    }
}

