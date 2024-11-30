using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.Commands;

public class TreeListCommand : ICommand
{
    public IFileSystem FileSystem { get; }

    public int Depth { get; }

    public TreeListCommand(IFileSystem fileSystem, int depth)
    {
        FileSystem = fileSystem;
        Depth = depth;
    }

    public void Execute()
    {
        FileSystem.TreeList(Depth, 0);
    }
}