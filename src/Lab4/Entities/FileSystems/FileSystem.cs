namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;

public class FileSystem : IFileSystem
{
    public virtual string? CurrentPath { get; set; }

    public virtual void Connect(string path)
    {
        if (Directory.Exists(path))
        {
            CurrentPath = path;
        }
        else
        {
            throw new DirectoryNotFoundException($"Path '{path}' does not exist");
        }
    }

    public void Disconnect()
    {
        CurrentPath = null;
    }

    public void TreeList(int depth, int currentDepth)
    {
        {
            if (currentDepth > depth)
                return;

            if (!Directory.Exists(CurrentPath))
            {
                Console.WriteLine($"Каталог {CurrentPath} не существует.");
                return;
            }

            string[] directories = Directory.GetDirectories(CurrentPath);
            string[] files = Directory.GetFiles(CurrentPath);

            foreach (string directory in directories)
            {
                Console.WriteLine($"{Path.GetFileName(directory)}");
                TreeList(depth, currentDepth + 1);
            }

            foreach (string file in files)
            {
                Console.WriteLine($"{Path.GetFileName(file)}");
            }
        }
    }

    public void ReadFile(string path)
    {
        if (!File.Exists(path))
        {
            throw new FileNotFoundException($"File {path} does not exist");
        }

        Console.WriteLine(File.ReadAllText(path));
    }

    public void MoveFile(string sourcePath, string destinationPath)
    {
        File.Move(sourcePath, destinationPath);
    }

    public void CopyFile(string sourcePath, string destinationPath)
    {
        File.Copy(sourcePath, destinationPath);
    }

    public void DeleteFile(string path)
    {
        File.Delete(path);
    }

    public void RenameFile(string path, string newName)
    {
        var fileInfo = new FileInfo(path);

        string newFilePath = Path.Combine(fileInfo.Directory?.FullName ?? throw new InvalidOperationException("Directory does not exist"));

        fileInfo.MoveTo(newFilePath);
    }

    public void ChangeDirectory(string path)
    {
        if (Directory.Exists(path))
        {
            CurrentPath = Path.GetFullPath(path);
        }
        else
        {
            throw new DirectoryNotFoundException($"Directory {path} does not exist");
        }
    }
}