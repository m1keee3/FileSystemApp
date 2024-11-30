using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.Commands;

public class ConnectCommand : ICommand
{
    public IFileSystem FileSystem { get; }

    public string Path { get; }

    public ConnectCommand(IFileSystem fileSystem, string path)
    {
        FileSystem = fileSystem;
        Path = path;
    }

    public void Execute()
    {
        FileSystem.Connect(Path);
        Console.WriteLine($"Connected to {Path}");
    }
}