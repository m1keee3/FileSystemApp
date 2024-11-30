using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.Handlers;

public class FileMoveHandler : BaseCommandHandler
{
    public IFileSystem FileSystem { get; }

    public FileMoveHandler(IFileSystem fileSystem)
    {
        FileSystem = fileSystem;
    }

    public override ICommand? Handle(string[] args)
    {
        if (args[0] == "file" && args[1] == "move" && args.Length > 3)
        {
            return new FileMoveCommand(FileSystem, args[2], args[3]);
        }

        return base.Handle(args);
    }
}