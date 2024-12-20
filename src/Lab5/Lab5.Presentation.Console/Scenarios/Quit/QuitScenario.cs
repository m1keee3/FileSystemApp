namespace Lab5.Presentation.Console.Scenarios.Quit;

public class QuitScenario : IScenario
{
    public string Name => "Quit";

    public void Run()
    {
        Environment.Exit(0);
    }
}