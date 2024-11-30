namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;

public interface IFileSystem
{
    string? CurrentPath { get; }

    void Connect(string path);

    void Disconnect();

    void TreeList(int depth, int currentDepth);

    void ReadFile(string path);

    void MoveFile(string sourcePath, string destinationPath);

    void CopyFile(string sourcePath, string destinationPath);

    void DeleteFile(string path);

    void RenameFile(string path, string newName);

    void ChangeDirectory(string path);
}