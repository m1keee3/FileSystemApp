using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.Handlers;

public class TreeGotoHandler : BaseCommandHandler
{
    public IFileSystem FileSystem { get; }

    public TreeGotoHandler(IFileSystem fileSystem)
    {
        FileSystem = fileSystem;
    }

    public override ICommand? Handle(string[] args)
    {
        if (args[0] == "tree" && args[1] == "goto" && args.Length > 2)
        {
            return new TreeGotoCommand(FileSystem, args[2]);
        }

        return base.Handle(args);
    }
}