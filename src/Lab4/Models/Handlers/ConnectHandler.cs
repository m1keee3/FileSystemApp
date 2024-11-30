using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.Handlers;

public class ConnectHandler : BaseCommandHandler
{
    public IFileSystem FileSystem { get; }

    public ConnectHandler(IFileSystem fileSystem)
    {
        FileSystem = fileSystem;
    }

    public override ICommand? Handle(string[] args)
    {
        if (args[0] == "connect" && args.Length > 1)
        {
            return new ConnectCommand(FileSystem, args[1]);
        }

        return base.Handle(args);
    }
}