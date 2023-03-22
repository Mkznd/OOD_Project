namespace Project_School;

public static class ClassList
{
    public static readonly Dictionary<string, IClass> Classes = new();

    public static string GetId(IClass classString)
    {
        return $"{classString.Name}{classString.Code}{classString.Duration}";
    }
}