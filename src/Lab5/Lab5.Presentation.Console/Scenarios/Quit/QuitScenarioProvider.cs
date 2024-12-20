using System.Diagnostics.CodeAnalysis;

namespace Lab5.Presentation.Console.Scenarios.Quit;

public class QuitScenarioProvider : IScenarioProvider
{
    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        scenario = new QuitScenario();
        return true;
    }
}