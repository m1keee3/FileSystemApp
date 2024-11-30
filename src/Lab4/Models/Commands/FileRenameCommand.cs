using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.Commands;

public class FileRenameCommand : ICommand
{
    public IFileSystem FileSystem { get; }

    public string Path { get; }

    public string Name { get; }

    public FileRenameCommand(IFileSystem fileSystem, string path, string name)
    {
        FileSystem = fileSystem;
        Path = path;
        Name = name;
    }

    public void Execute()
    {
        FileSystem.RenameFile(Path, Name);
        Console.WriteLine($"File {Path} renamed to {Name}");
    }
}