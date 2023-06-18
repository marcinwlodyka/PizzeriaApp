using System;
using System.Windows.Input;

namespace PizzeriaApp.Commands;

public class GenericCommand : CommandBase
{
    private readonly Action _callback;

    public GenericCommand(Action callback)
    {
        _callback = callback;
    }

    public override void Execute(object? parameter)
    {
        _callback();
    }
}