using Project_School.Enums;

namespace Project_School.Interfaces.CLI;

public interface ICommand
{
    void Execute();
    void Initialize(Types type, string args);
}