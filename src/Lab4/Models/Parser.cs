using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Handlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models;

public class Parser
{
    public FileSystem FileSystem { get; }

    public ConnectHandler ConnectHandler { get; }

    public Parser(FileSystem fileSystem)
    {
        FileSystem = fileSystem;
        ConnectHandler = new ConnectHandler(fileSystem);
        var disconnectHandler = new DisconnectHandler(fileSystem);
        var treeGotoHandler = new TreeGotoHandler(fileSystem);
        var treeListHandler = new TreeListHandler(fileSystem);
        var fileShowHandler = new FileShowHandler(fileSystem);
        var fileMoveHandler = new FileMoveHandler(fileSystem);
        var fileCopyHandler = new FileCopyHandler(fileSystem);
        var fileDeleteHandler = new FileDeleteHandler(fileSystem);
        var fileRenameHandler = new FileRenameHandler(fileSystem);
        ConnectHandler
            .SetNext(disconnectHandler)
            .SetNext(treeGotoHandler)
            .SetNext(treeListHandler)
            .SetNext(fileShowHandler)
            .SetNext(fileMoveHandler)
            .SetNext(fileCopyHandler)
            .SetNext(fileDeleteHandler)
            .SetNext(fileRenameHandler);
    }

    public void Parse(string input)
    {
        ICommand? command = ConnectHandler.Handle(input.Split(' '));
        if (command is not null)
        {
            command.Execute();
        }
        else
        {
            Console.WriteLine("There is no such command");
        }
    }

    public void ConsoleParse()
    {
        while (true)
        {
            Console.Write("> ");
            string? input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                continue;
            }

            ICommand? command = ConnectHandler.Handle(input.Split(' '));
            if (command is not null)
            {
                command.Execute();
            }
            else
            {
                Console.WriteLine("There is no such command");
            }
        }
    }

    public ICommand? TestParse(string input)
    {
        return ConnectHandler.Handle(input.Split(' '));
    }
}