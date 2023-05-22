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

public class EditVisitor : IVisitor
{
    private const string Done = "done";
    private readonly string? _inputResult;
    private readonly Dictionary<string, object>? _inputObjects;
    public Queue<Queue<string>>? Args { get; set; }


    public EditVisitor(string args, Dictionary<string, object> inputObjects, string inputResult)
    {
        Args = Utils.GetTokensFromArgsString(args);
        this._inputObjects = inputObjects;
        this._inputResult = inputResult;
    }

    public EditVisitor()
    {
        this._inputResult = default;
        this._inputObjects = default;
        Args = default;
    }


    public void VisitClass(IClass element)
    {
        if (_inputObjects is null || _inputResult is null ||
            !_inputResult.Equals(Done, StringComparison.InvariantCultureIgnoreCase)) return;
        InputCommandsFunctions.FillObjectWithInputs(_inputObjects, element, typeof(uint));
    }

    public void VisitRoom(IRoom element)
    {
        // OutputAvailableFields(typeof(Room));
        // var inputObjects = GetInputs(element, typeof(IRoom), out var input);
        // Console.WriteLine("Input finished!");
        // if (input.Equals(Done, StringComparison.InvariantCultureIgnoreCase))
        // {
        //     IRoom room;
        //     if (_representation == Representation.Base)
        //     {
        //         room = new Room();
        //         FillObjectWithInputs(inputObjects, room, typeof(uint));
        //     }
        //     else
        //     {
        //         var roomString = new RoomString();
        //         FillObjectWithInputs(inputObjects, roomString, typeof(uint));
        //         room = new RoomStringAdapter(roomString);
        //     }
        //
        //     RoomList.AddToList(room);
        // }
        // else
        // {
        //     Environment.Exit(0);
        // }
    }

    public void VisitStudent(IStudent element)
    {
        // OutputAvailableFields(typeof(Student));
        // var inputObjects = GetInputs(element, typeof(IStudent), out var input);
        // Console.WriteLine("Input finished!");
        // if (input.Equals(Done, StringComparison.InvariantCultureIgnoreCase))
        // {
        //     IStudent student;
        //     if (_representation == Representation.Base)
        //     {
        //         student = new Student();
        //         FillObjectWithInputs(inputObjects, student, typeof(uint));
        //     }
        //     else
        //     {
        //         var studentString = new StudentString();
        //         FillObjectWithInputs(inputObjects, studentString, typeof(uint));
        //         student = new StudentStringAdapter(studentString);
        //     }
        //
        //     StudentList.AddToList(student);
        // }
        // else
        // {
        //     Environment.Exit(0);
        // }
    }

    public void VisitTeacher(ITeacher element)
    {
        // OutputAvailableFields(typeof(Teacher));
        // var inputObjects = GetInputs(element, typeof(ITeacher), out var input);
        // Console.WriteLine("Input finished!");
        // if (input.Equals(Done, StringComparison.InvariantCultureIgnoreCase))
        // {
        //     ITeacher teacher;
        //     if (_representation == Representation.Base)
        //     {
        //         teacher = new Teacher();
        //         FillObjectWithInputs(inputObjects, teacher, typeof(TeacherRank));
        //     }
        //     else
        //     {
        //         var teacherString = new TeacherString();
        //         FillObjectWithInputs(inputObjects, teacherString, typeof(TeacherRank));
        //         teacher = new TeacherStringAdapter(teacherString);
        //     }
        //
        //     TeacherList.AddToList(teacher);
        // }
        // else
        // {
        //     Environment.Exit(0);
        // }
    }
}