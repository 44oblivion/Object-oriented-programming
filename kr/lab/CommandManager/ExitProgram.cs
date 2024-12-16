class ExitProgram : ICommand
{

    public void Execute()
    {
        // Ensure there is no break or continue statement outside of a loop
        Environment.Exit(0);
    }

    public string GetDescription()
    {
        return "Вихід з програми";
    }
}