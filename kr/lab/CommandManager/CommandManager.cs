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

            if(UserSession.currentUser == null)
            {
                if(command == "login" || command == "create" || command == "exit")
                {
                    _commands[command].Execute();
                }else{
                    Console.WriteLine("Треба спочатку створити акаунт");
                }
                
            }
            else
            {
                if(command != "login" && command != "create")
                {
                    _commands[command].Execute();
                }else
                {
                    Console.WriteLine("Ви вже в акаунті");
                }
            }
            
        }
        else
        {
            Console.WriteLine("\nТаку команду не знайдено");
        }
    }

    public void ShowCommands()
    {
        Console.WriteLine("Виберіть команду:");
        foreach (var command in _commands)
        {
            if(UserSession.currentUser == null)
            {
                if(command.Key == "login" || command.Key == "create" || command.Key == "exit")
                {
                    Console.WriteLine($"{command.Key}. {command.Value.GetDescription()}");
                }
                
            }
            else
            {
                if(command.Key != "login" && command.Key != "create")
                {
                    Console.WriteLine($"{command.Key}. {command.Value.GetDescription()}");
                }
            }
        }
    }
}
