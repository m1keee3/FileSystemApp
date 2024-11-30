using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.Handlers;

public class FileDeleteHandler : BaseCommandHandler
{
    public IFileSystem FileSystem { get; }

    public FileDeleteHandler(IFileSystem fileSystem)
    {
        FileSystem = fileSystem;
    }

    public override ICommand? Handle(string[] args)
    {
        if (args[0] == "file" && args[1] == "delete" && args.Length > 2)
        {
            return new FileDeleteCommand(FileSystem, args[2]);
        }

        return base.Handle(args);
    }
}