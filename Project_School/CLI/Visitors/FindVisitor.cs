using System.Reflection;
using Project_School.Interfaces.CLI;
using Project_School.Interfaces.Common;
using Project_School.Misc;

namespace Project_School.CLI.Visitors;

public class FindVisitor : IVisitor
{
    public Queue<Queue<string>> Args { get; set; }

    public FindVisitor(string args)
    {
        Args = Utils.GetTokensFromArgsString(args);
    }
    
    public void VisitClass(IClass element)
    {
        if (IsCompliantToArgs(element))
            Console.WriteLine($"{element.Name} {element.Code} {element.Duration}");
    }

    public void VisitRoom(IRoom element)
    {
        if (IsCompliantToArgs(element))
            Console.WriteLine($"{element.Number} {element.Type}");
    }

    public void VisitStudent(IStudent element)
    {
        if (IsCompliantToArgs(element))
            Console.WriteLine($"{string.Join(" ", element.Names)} {element.Surname} {element.Semester}");
    }

    public void VisitTeacher(ITeacher element)
    {
        if (IsCompliantToArgs(element))
            Console.WriteLine($"{string.Join(" ", element.Names)} {element.Surname} {element.Code} {element.Rank}");
    }

    public static bool Operator<T>(string logic, T x, T y) where T : IComparable<T>
    {
        return logic switch
        {
            ">" => x.CompareTo(y) < 0,
            "<" => x.CompareTo(y) > 0,
            "=" => x.CompareTo(y) == 0,
            _ => throw new Exception("invalid logic")
        };
    }

    public static bool OperatorEquals<T>(T x, T y) where T : IEquatable<T>
    {
        return x.Equals(y);
    }

    private bool IsCompliantToArgs<T>(T element)
    {
        var argsMock = new Queue<Queue<string>>(Args.Select(queue => new Queue<string>(queue)).ToList());
        while (argsMock.Count > 0)
        {
            var arg = argsMock.Dequeue();
            if (arg.Count < 2) return true;

            Utils.DecomposeArgument(element, arg, out var operand, out var @operator, out var strVal);

            var result = IsCompliantToArgument(element, operand, strVal, @operator);

            if (!result) return false;
        }

        return true;
    }

    private static bool IsCompliantToArgument<T>(T element, PropertyInfo operand, string strVal, string @operator)
    {
        bool result;
        if (operand.PropertyType == typeof(int))
        {
            var valueToCompare = int.Parse(strVal);
            var operandValue = (int) operand.GetValue(element);
            result = Operator(@operator, operandValue, valueToCompare);
        }
        else if (operand.PropertyType == typeof(float))
        {
            var valueToCompare = float.Parse(strVal);
            var operandValue = (float) operand.GetValue(element);
            result = Operator(@operator, operandValue, valueToCompare);
        }
        else if (operand.PropertyType == typeof(double))
        {
            var valueToCompare = double.Parse(strVal);
            var operandValue = (double) operand.GetValue(element);
            result = Operator(@operator, operandValue, valueToCompare);
        }
        else if (operand.PropertyType == typeof(string))
        {
            var operandValue = operand.GetValue(element).ToString();
            result = Operator(@operator, operandValue, strVal);
        }
        else
        {
            var operandValue = operand.GetValue(element).ToString();
            result = OperatorEquals(operandValue, strVal);
        }

        return result;
    }

    
}