using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.Commands;

public class FileShowCommand : ICommand
{
    public IFileSystem FileSystem { get; }

    private readonly string _filePath;

    public FileShowCommand(IFileSystem fileSystem, string filePath)
    {
        FileSystem = fileSystem;
        _filePath = filePath;
    }

    public void Execute()
    {
        Console.WriteLine($"File {_filePath}:");
        FileSystem.ReadFile(_filePath);
    }
}