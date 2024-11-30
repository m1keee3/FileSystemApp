using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.Handlers;

public class TreeListHandler : BaseCommandHandler
{
    public IFileSystem FileSystem { get; }

    public TreeListHandler(IFileSystem fileSystem)
    {
        FileSystem = fileSystem;
    }

    public override ICommand? Handle(string[] args)
    {
        if (args[0] == "tree" && args[1] == "list")
        {
            if (args[2] == "-d")
            {
                return new TreeListCommand(FileSystem, Convert.ToInt32(args[3]));
            }
        }

        return base.Handle(args);
    }
}
