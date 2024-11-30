using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.Handlers;

public class FileShowHandler : BaseCommandHandler
{
    public IFileSystem FileSystem { get; }

    public FileShowHandler(IFileSystem fileSystem)
    {
        FileSystem = fileSystem;
    }

    public override ICommand? Handle(string[] args)
    {
        if (args[0] == "file" && args[1] == "show" && args.Length > 2)
        {
            return new FileShowCommand(FileSystem, args[2]);
        }

        return base.Handle(args);
    }
}