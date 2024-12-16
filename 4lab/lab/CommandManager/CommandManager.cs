class CommandManager
{
    public Dictionary<string, ICommand> _commands = new();

    public void RegisterCommand(string commandName, ICommand command)
    {
        _commands[commandName] = command;
    }

    

    public void ExecuteCommand(string command)
    {
        if(_commands.ContainsKey(command))
        {
            _commands[command].Execute();
        }
        else
        {
            Console.WriteLine("Command not found");
        }
    }

    public void ShowCommands()
    {
        Console.WriteLine("Commands:");
        foreach (var command in _commands)
        {
        
            Console.WriteLine($"{command.Key}. {command.Value.GetDescription()}");
        }
    }

}