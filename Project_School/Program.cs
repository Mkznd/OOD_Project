using Project_School.BaseRepresentation;
using Project_School.Enums;
using Project_School.FirstRepresentation;
using Project_School.FirstRepresentation.Adapters;
using Project_School.Interfaces;
using Project_School.Interfaces.Common;
using Project_School.Iterator;
using Project_School.Iterator.Algorithms;
using Project_School.Iterator.Collections;
using Project_School.SecondRepresentation;
using Project_School.SecondRepresentation.Adapters;
using Project_School.Visitor.Visitors;
using static System.Enum;

namespace Project_School;

internal static class Program
{
    public static void Main()
    {
        var rooms = new List<IRoom>()
        {
            new Room(1, RoomType.Lecture, new List<IClass>()),
            new Room(2, RoomType.Laboratory, new List<IClass>()),
            new Room(3, RoomType.Training, new List<IClass>())
        };
        
        var ns = new List<string>
        {
            "A",
            "B",
            "C"
        };
        var nt = new List<string>
        {
            "tA",
            "tB",
            "tC"
        };

        var students = new List<IHuman>
        {
            new Student(ns, "sur1", 3),
            new Student(ns, "sur2", 2),
            new Student(ns, "sur3", 1)
        };
        var teachers = new List<ITeacher>
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
        var classes = new List<IClass>
        {
            new Class("c_nameA", "codeA", 3, teachers, students),
            new ClassStringAdapter(a),
            new ClassTupleAdapter(b)
        };
        students.ForEach(Console.WriteLine);
        teachers.ForEach(Console.WriteLine);
        classes.ForEach(Console.WriteLine);

        // Iterator test
        var list = new DoubleLinkedList<int>();
        var array = new ResizableArray<int>();
        var even = (Func<int, bool?>)(x => x % 2 == 0);
        for (var i = -10; i < 10; i++)
        {
            list.PushBack(i);
            array.PushBack(i);
        }

        Console.WriteLine("PRINT //////////////////////////////////////////////");

        Console.WriteLine("LIST //////////////////////////////////////////////");
        Console.WriteLine("Reverse = false");
        PrintAlgorithm<int>.Print(list, even, false);
        Console.WriteLine("Reverse = true");
        PrintAlgorithm<int>.Print(list, even, true);

        Console.WriteLine("ARRAY //////////////////////////////////////////////");
        Console.WriteLine("Reverse = false");
        PrintAlgorithm<int>.Print(array, even, false);
        Console.WriteLine("Reverse = true");
        PrintAlgorithm<int>.Print(array, even, true);

        Console.WriteLine("FIND //////////////////////////////////////////////");

        Console.WriteLine("LIST //////////////////////////////////////////////");
        Console.WriteLine("Reverse = false");
        Console.WriteLine(FindAlgorithm<int>.FindFirst(list, even, false));
        Console.WriteLine("Reverse = true");
        Console.WriteLine(FindAlgorithm<int>.FindFirst(list, even, true));

        Console.WriteLine("ARRAY //////////////////////////////////////////////");
        Console.WriteLine("Reverse = false");
        Console.WriteLine(FindAlgorithm<int>.FindFirst(array, even, false));
        Console.WriteLine("Reverse = true");
        Console.WriteLine(FindAlgorithm<int>.FindFirst(array, even, true));
        
        Console.WriteLine("TASK 3//////////////////////////////////////////////");
        var listVisitor = new ListVisitor();
        var input = Console.ReadLine();
        if (input == null) return;
        var tryParse = TryParse(input, out Types type);
        if (!tryParse) return;
        switch (type)
        {
            case Types.Class:
                classes.ForEach(c => c.Accept(listVisitor));
                break;
            case Types.Teacher:
                teachers.ForEach(c => c.Accept(listVisitor));
                break;
            case Types.Student:
                students.ForEach(c => c.Accept(listVisitor));
                break;
            case Types.Room:
                rooms.ForEach(c => c.Accept(listVisitor));
                break;
            default:
                throw new InvalidOperationException();
        }
    }
}