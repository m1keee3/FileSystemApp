using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.Commands;

public class FileMoveCommand : ICommand
{
    public IFileSystem FileSystem { get; }

    public string SourcePath { get; }

    public string DestinationPath { get; }

    public FileMoveCommand(IFileSystem fileSystem, string sourcePath, string destinationPath)
    {
        FileSystem = fileSystem;
        SourcePath = sourcePath;
        DestinationPath = destinationPath;
    }

    public void Execute()
    {
        FileSystem.MoveFile(SourcePath, DestinationPath);
        Console.WriteLine($"File {SourcePath} moved to {DestinationPath}");
    }
}