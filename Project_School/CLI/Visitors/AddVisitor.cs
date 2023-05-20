using System.Collections;
using System.Reflection;
using Project_School.BaseRepresentation;
using Project_School.Enums;
using Project_School.FirstRepresentation;
using Project_School.FirstRepresentation.Adapters;
using Project_School.Interfaces.CLI;
using Project_School.Interfaces.Common;
using Project_School.Lists;
using Project_School.Misc;

namespace Project_School.CLI.Visitors;

public class AddVisitor : IVisitor
{
    private const string Done = "done";
    private readonly Representation _representation;

    public AddVisitor()
    {
    }

    public AddVisitor(Representation rep)
    {
        _representation = rep;
    }

    public void VisitClass(IClass element)
    {
        OutputAvailableFields(typeof(Class));
        var inputObjects = InputCommandsFunctions.GetInputs(element, typeof(IClass), out var input);
        Console.WriteLine("Input finished!");
        if (input.Equals(Done, StringComparison.InvariantCultureIgnoreCase))
        {
            IClass @class;
            if (_representation == Representation.Base)
            {
                @class = new Class();
                InputCommandsFunctions.FillObjectWithInputs(inputObjects, @class, typeof(uint));
            }
            else
            {
                var classString = new ClassString();
                InputCommandsFunctions.FillObjectWithInputs(inputObjects, classString, typeof(uint));
                @class = new ClassStringAdapter(classString);
            }

            ClassList.AddToList(@class);
        }
        else
        {
            Environment.Exit(0);
        }
    }

    public void VisitRoom(IRoom element)
    {
        OutputAvailableFields(typeof(Room));
        var inputObjects =  InputCommandsFunctions.GetInputs(element, typeof(IRoom), out var input);
        Console.WriteLine("Input finished!");
        if (input.Equals(Done, StringComparison.InvariantCultureIgnoreCase))
        {
            IRoom room;
            if (_representation == Representation.Base)
            {
                room = new Room();
                InputCommandsFunctions.FillObjectWithInputs(inputObjects, room, typeof(uint));
            }
            else
            {
                var roomString = new RoomString();
                InputCommandsFunctions.FillObjectWithInputs(inputObjects, roomString, typeof(uint));
                room = new RoomStringAdapter(roomString);
            }

            RoomList.AddToList(room);
        }
        else
        {
            Environment.Exit(0);
        }
    }

    public void VisitStudent(IStudent element)
    {
        OutputAvailableFields(typeof(Student));
        var inputObjects =  InputCommandsFunctions.GetInputs(element, typeof(IStudent), out var input);
        Console.WriteLine("Input finished!");
        if (input.Equals(Done, StringComparison.InvariantCultureIgnoreCase))
        {
            IStudent student;
            if (_representation == Representation.Base)
            {
                student = new Student();
                InputCommandsFunctions.FillObjectWithInputs(inputObjects, student, typeof(uint));
            }
            else
            {
                var studentString = new StudentString();
                InputCommandsFunctions.FillObjectWithInputs(inputObjects, studentString, typeof(uint));
                student = new StudentStringAdapter(studentString);
            }

            StudentList.AddToList(student);
        }
        else
        {
            Environment.Exit(0);
        }
    }

    public void VisitTeacher(ITeacher element)
    {
        OutputAvailableFields(typeof(Teacher));
        var inputObjects =  InputCommandsFunctions.GetInputs(element, typeof(ITeacher), out var input);
        Console.WriteLine("Input finished!");
        if (input.Equals(Done, StringComparison.InvariantCultureIgnoreCase))
        {
            ITeacher teacher;
            if (_representation == Representation.Base)
            {
                teacher = new Teacher();
                InputCommandsFunctions.FillObjectWithInputs(inputObjects, teacher, typeof(TeacherRank));
            }
            else
            {
                var teacherString = new TeacherString();
                InputCommandsFunctions.FillObjectWithInputs(inputObjects, teacherString, typeof(TeacherRank));
                teacher = new TeacherStringAdapter(teacherString);
            }

            TeacherList.AddToList(teacher);
        }
        else
        {
            Environment.Exit(0);
        }
    }

    private static void OutputAvailableFields(Type type)
    {
        var props = type.GetProperties().Where(InputCommandsFunctions.IsValueType).Select(p => p.Name);
        Console.WriteLine($"Available fields: [{string.Join(',', props)}]");
    }
}