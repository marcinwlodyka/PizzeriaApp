using System;
using System.Windows.Input;

namespace PizzeriaApp.Commands;

public class GenericCommand : CommandBase
{
    private readonly Action? _callback;
    private readonly Action<Object?>? _callbackParam;

    public GenericCommand(Action<Object?> callback)
    {
        _callbackParam = callback;
    }

    public GenericCommand(Action callback)
    {
        _callback = callback;
    }

    public override void Execute(object? parameter)
    {
        _callback?.Invoke();
        _callbackParam?.Invoke(parameter);
    }
}