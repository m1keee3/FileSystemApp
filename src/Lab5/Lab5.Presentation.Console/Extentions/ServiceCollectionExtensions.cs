using Lab5.Presentation.Console.Scenarios.AdminAbilities;
using Lab5.Presentation.Console.Scenarios.Login;
using Lab5.Presentation.Console.Scenarios.Logout;
using Lab5.Presentation.Console.Scenarios.Quit;
using Lab5.Presentation.Console.Scenarios.User;
using Microsoft.Extensions.DependencyInjection;

namespace Lab5.Presentation.Console.Extentions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentationConsole(this IServiceCollection collection)
    {
        collection.AddScoped<ScenarioRunner>();

        collection.AddScoped<IScenarioProvider, AddUserScenarioProvider>();
        collection.AddScoped<IScenarioProvider, AdminLoginScenarioProvider>();
        collection.AddScoped<IScenarioProvider, LogoutScenarioProvider>();
        collection.AddScoped<IScenarioProvider, UserLoginScenarioProvider>();
        collection.AddScoped<IScenarioProvider, QuitScenarioProvider>();
        collection.AddScoped<IScenarioProvider, PutMoneyScenarioProvider>();
        collection.AddScoped<IScenarioProvider, RemoveMoneyScenarioProvider>();
        collection.AddScoped<IScenarioProvider, ShowBalanceScenarioProvider>();
        collection.AddScoped<IScenarioProvider, ShowHistoryScenarioProvider>();

        return collection;
    }
}