using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.Commands;

public class TreeGotoCommand : ICommand
{
    private readonly IFileSystem _fileSystem;
    private readonly string _path;

    public TreeGotoCommand(IFileSystem fileSystem, string path)
    {
        _fileSystem = fileSystem;
        _path = path;
    }

    public void Execute()
    {
        _fileSystem.ChangeDirectory(_path);
        Console.WriteLine($"Switch to {_fileSystem.CurrentPath}");
    }
}