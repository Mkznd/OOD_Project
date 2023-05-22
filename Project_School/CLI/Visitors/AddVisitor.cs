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
    private readonly string _inputResult;
    private readonly Dictionary<string, object> _inputObjects;
    private readonly Representation _representation;

    public AddVisitor()
    {
    }

    public AddVisitor(Representation rep, Dictionary<string, object> inputObjects, string inputResult)
    {
        _representation = rep;
        this._inputObjects = inputObjects;
        this._inputResult = inputResult;
    }

    public void VisitClass(IClass element)
    {
        if (_inputResult.Equals(Done, StringComparison.InvariantCultureIgnoreCase))
        {
            IClass @class;
            if (_representation == Representation.Base)
            {
                @class = new Class();
                InputCommandsFunctions.FillObjectWithInputs(_inputObjects, @class, typeof(uint));
            }
            else
            {
                var classString = new ClassString();
                InputCommandsFunctions.FillObjectWithInputs(_inputObjects, classString, typeof(uint));
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
        if (_inputResult.Equals(Done, StringComparison.InvariantCultureIgnoreCase))
        {
            IRoom room;
            if (_representation == Representation.Base)
            {
                room = new Room();
                InputCommandsFunctions.FillObjectWithInputs(_inputObjects, room, typeof(uint));
            }
            else
            {
                var roomString = new RoomString();
                InputCommandsFunctions.FillObjectWithInputs(_inputObjects, roomString, typeof(uint));
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
        if (_inputResult.Equals(Done, StringComparison.InvariantCultureIgnoreCase))
        {
            IStudent student;
            if (_representation == Representation.Base)
            {
                student = new Student();
                InputCommandsFunctions.FillObjectWithInputs(_inputObjects, student, typeof(uint));
            }
            else
            {
                var studentString = new StudentString();
                InputCommandsFunctions.FillObjectWithInputs(_inputObjects, studentString, typeof(uint));
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
        if (_inputResult.Equals(Done, StringComparison.InvariantCultureIgnoreCase))
        {
            ITeacher teacher;
            if (_representation == Representation.Base)
            {
                teacher = new Teacher();
                InputCommandsFunctions.FillObjectWithInputs(_inputObjects, teacher, typeof(TeacherRank));
            }
            else
            {
                var teacherString = new TeacherString();
                InputCommandsFunctions.FillObjectWithInputs(_inputObjects, teacherString, typeof(TeacherRank));
                teacher = new TeacherStringAdapter(teacherString);
            }

            TeacherList.AddToList(teacher);
        }
        else
        {
            Environment.Exit(0);
        }
    }
}