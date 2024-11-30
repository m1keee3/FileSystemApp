using Itmo.ObjectOrientedProgramming.Lab4.Models.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.Handlers;

public interface ICommandHandler
{
    ICommandHandler SetNext(ICommandHandler handler);

    ICommand? Handle(string[] args);
}