using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.Handlers;

public class FileCopyHandler : BaseCommandHandler
{
    public IFileSystem FileSystem { get; }

    public FileCopyHandler(IFileSystem fileSystem)
    {
        FileSystem = fileSystem;
    }

    public override ICommand? Handle(string[] args)
    {
        if (args[0] == "file" && args[1] == "copy" && args.Length > 3)
        {
            return new FileCopyCommand(FileSystem, args[2], args[3]);
        }

        return base.Handle(args);
    }
}