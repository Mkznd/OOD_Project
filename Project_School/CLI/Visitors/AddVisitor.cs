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
    private const string Exit = "exit";
    private readonly Representation _representation;

    public AddVisitor()
    {
    }

    public AddVisitor(Representation rep)
    {
        _representation = rep;
    }

    private static bool IsValueType(PropertyInfo p)
    {
        return !typeof(IEnumerable).IsAssignableFrom(p.PropertyType)
               || p.PropertyType == typeof(string);
    }

    
    private static void FillObjectWithInputs(Dictionary<string, object> inputObjects, object obj, Type type)
    {
        foreach (var kvp in inputObjects)
        {
            var prop = obj.GetType().GetProperty(kvp.Key);
            if (prop is null)
            {
                throw new ArgumentException("Wrong parameter detected!");
            }

            if (type.IsEnum && prop.PropertyType == type)
            {
                if (Enum.TryParse(kvp.Value.ToString(), ignoreCase: true, out TeacherRank result))
                {
                    prop.SetValue(obj, result);
                }
            }
            else
            {
                prop.SetValue(obj,
                    prop.PropertyType == type ? Convert.ChangeType(kvp.Value.ToString() ?? "0", type) : kvp.Value);
            }
            
        }
    }

    private static Dictionary<string, object> GetInputs(object element, Type type, out string input)
    {
        var availableProps = type.GetProperties().Where(IsValueType).Select(p => p.Name);
        var inputObjects = new Dictionary<string, object>();
        foreach (var e in availableProps)
        {
            inputObjects[e] = new object();
        }

        input = Console.ReadLine();
        while (!input.Equals(Done, StringComparison.InvariantCultureIgnoreCase)
               && !input.Equals(Exit, StringComparison.InvariantCultureIgnoreCase))
        {
            var argsQueue = Utils.BreakArgumentIntoQueue(input);
            Utils.DecomposeArgument(element, argsQueue,
                out var operand, out var @operator, out var strVal);
            inputObjects[operand.Name] = strVal;
            input = Console.ReadLine();
        }

        return inputObjects;
    }
    
    public void VisitClass(IClass element)
    {
        OutputAvailableFields(typeof(Class));
        var inputObjects = GetInputs(element, typeof(IClass), out var input);
        Console.WriteLine("Input finished!");
        if (input.Equals(Done, StringComparison.InvariantCultureIgnoreCase))
        {
            IClass @class;
            if (_representation == Representation.Base)
            {
                @class = new Class();
                FillObjectWithInputs(inputObjects, @class, typeof(uint));
            }
            else
            {
                var classString = new ClassString();
                FillObjectWithInputs(inputObjects, classString, typeof(uint));
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
        var inputObjects = GetInputs(element, typeof(IRoom), out var input);
        Console.WriteLine("Input finished!");
        if (input.Equals(Done, StringComparison.InvariantCultureIgnoreCase))
        {
            IRoom room;
            if (_representation == Representation.Base)
            {
                room = new Room();
                FillObjectWithInputs(inputObjects, room, typeof(uint));
            }
            else
            {
                var roomString = new RoomString();
                FillObjectWithInputs(inputObjects, roomString, typeof(uint));
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
        var inputObjects = GetInputs(element, typeof(IStudent), out var input);
        Console.WriteLine("Input finished!");
        if (input.Equals(Done, StringComparison.InvariantCultureIgnoreCase))
        {
            IStudent student;
            if (_representation == Representation.Base)
            {
                student = new Student();
                FillObjectWithInputs(inputObjects, student, typeof(uint));
            }
            else
            {
                var studentString = new StudentString();
                FillObjectWithInputs(inputObjects, studentString, typeof(uint));
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
        var inputObjects = GetInputs(element, typeof(ITeacher), out var input);
        Console.WriteLine("Input finished!");
        if (input.Equals(Done, StringComparison.InvariantCultureIgnoreCase))
        {
            ITeacher teacher;
            if (_representation == Representation.Base)
            {
                teacher = new Teacher();
                FillObjectWithInputs(inputObjects, teacher, typeof(TeacherRank));
            }
            else
            {
                var teacherString = new TeacherString();
                FillObjectWithInputs(inputObjects, teacherString, typeof(TeacherRank));
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
        var props = type.GetProperties().Where(IsValueType).Select(p => p.Name);
        Console.WriteLine($"Available fields: [{string.Join(',', props)}]");
    }
}