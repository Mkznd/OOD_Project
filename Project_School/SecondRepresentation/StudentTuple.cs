using Project_School.Lists;
using Project_School.SecondRepresentation.Adapters;

namespace Project_School.SecondRepresentation;

public class StudentTuple
{
    public List<Tuple<string, object>> Fileds;
    public StudentTuple(List<Tuple<string, object>> fileds)
    {
        this.Fileds = fileds;
        StudentList.AddToList(new StudentTupleAdapter(this));
    }
}