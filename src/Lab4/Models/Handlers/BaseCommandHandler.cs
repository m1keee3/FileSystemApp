using Itmo.ObjectOrientedProgramming.Lab4.Models.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.Handlers;

public abstract class BaseCommandHandler : ICommandHandler
{
    private ICommandHandler? _nextHandler;

    public ICommandHandler SetNext(ICommandHandler handler)
    {
        _nextHandler = handler;
        return handler;
    }

    public virtual ICommand? Handle(string[] args)
    {
        if (_nextHandler != null)
        {
            return _nextHandler.Handle(args);
        }

        return null;
    }
}