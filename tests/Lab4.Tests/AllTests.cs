using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Commands;
using Moq;
using Xunit;

namespace Lab4.Tests;

public class AllTests
{
    [Fact]
    public void EnterNotCorrectCommandInParser_ShouldReturnNullReference()
    {
        var mockFileSystem = new Mock<FileSystem>();
        mockFileSystem.SetupAllProperties();
        mockFileSystem.Setup(fs => fs.Connect(It.IsAny<string>()))
            .Callback<string>(path => mockFileSystem.Object.CurrentPath = path);
        var parser = new Parser(mockFileSystem.Object);

        string input = "some command";
        ICommand? command = parser.TestParse(input);

        Assert.True(command is null);
    }

    [Fact]
    public void EnterConnectCommandInParser_ShouldReturnConnectCommandWithActualPath()
    {
        var mockFileSystem = new Mock<FileSystem>();
        mockFileSystem.SetupAllProperties();
        mockFileSystem.Setup(fs => fs.Connect(It.IsAny<string>()))
            .Callback<string>(path => mockFileSystem.Object.CurrentPath = path);
        var parser = new Parser(mockFileSystem.Object);

        string input = "connect C:\\Users\\skird\\RiderProjects";
        string expectedPath = "C:\\Users\\skird\\RiderProjects";
        ICommand? command = parser.TestParse(input);

        Assert.IsType<ConnectCommand>(command);

        var connectCommand = (ConnectCommand)command;
        Assert.Equal(expectedPath, connectCommand.Path);
    }

    [Fact]
    public void EnterDisconectCommandAfterConnectCommandInParser_ShouldReturnDisconnectCommandAndFileSystemPathShouldBeNull()
    {
        var mockFileSystem = new Mock<FileSystem>();
        mockFileSystem.SetupAllProperties();
        mockFileSystem.Setup(fs => fs.Connect(It.IsAny<string>()))
            .Callback<string>(path => mockFileSystem.Object.CurrentPath = path);
        var parser = new Parser(mockFileSystem.Object);

        string input1 = "connect C:\\Users\\skird\\RiderProjects";
        string input2 = "disconnect";
        parser.Parse(input1);

        ICommand? command = parser.TestParse(input2);
        parser.Parse(input2);

        Assert.IsType<DisconnectCommand>(command);
        Assert.True(parser.FileSystem.CurrentPath is null);
    }
}