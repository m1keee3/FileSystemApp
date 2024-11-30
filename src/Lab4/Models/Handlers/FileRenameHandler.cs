using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.Handlers;

public class FileRenameHandler : BaseCommandHandler
{
    public IFileSystem FileSystem { get; }

    public FileRenameHandler(IFileSystem fileSystem)
    {
        FileSystem = fileSystem;
    }

    public override ICommand? Handle(string[] args)
    {
        if (args[0] == "file" && args[1] == "rename" && args.Length > 3)
        {
            return new FileRenameCommand(FileSystem, args[2], args[3]);
        }

        return base.Handle(args);
    }
}