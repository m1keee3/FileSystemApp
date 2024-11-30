using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.Commands;

public class FileDeleteCommand : ICommand
{
    public IFileSystem FileSystem { get; }

    public string Path { get; }

    public FileDeleteCommand(IFileSystem fileSystem, string path)
    {
        FileSystem = fileSystem;
        Path = path;
    }

    public void Execute()
    {
        FileSystem.DeleteFile(Path);
        Console.WriteLine($"File {Path} deleted");
    }
}