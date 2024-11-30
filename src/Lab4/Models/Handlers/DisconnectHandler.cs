using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.Handlers;

public class DisconnectHandler : BaseCommandHandler
{
    public IFileSystem FileSystem { get; }

    public DisconnectHandler(IFileSystem fileSystem)
    {
        FileSystem = fileSystem;
    }

    public override ICommand? Handle(string[] args)
    {
        if (args[0] == "disconnect")
        {
            return new DisconnectCommand(FileSystem);
        }

        return base.Handle(args);
    }
}