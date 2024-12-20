using Lab5.Application.Contracts.Users;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.User;

public class ShowBalanceScenario : IScenario
{
    private readonly ICurrentUserService _currentUser;

    public ShowBalanceScenario(
        ICurrentUserService userService)
    {
        _currentUser = userService;
    }

    public string Name => "Show balance";

    public void Run()
    {
        if (_currentUser.User is null)
        {
            throw new ArgumentNullException();
        }

        AnsiConsole.WriteLine(_currentUser.User.Balance);
        AnsiConsole.Ask<string>("Ok");
        AnsiConsole.Clear();
    }
}