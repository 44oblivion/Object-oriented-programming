class CreatePlayer : ICommand
{
    public GameManager _gameManager;
    
    public CreatePlayer(GameManager gameManager)
    {
        _gameManager = gameManager;
    }
    public void Execute()
    {
        Console.WriteLine("Введіть username:");
        string name = Console.ReadLine();
        Console.WriteLine("Введить тип акаунту(standart, winstreak, losestreak):");
        string type;
        while (true)
        {
            type = Console.ReadLine();
            if (type == "standart" || type == "winstreak" || type == "losestreak")
            {
            break;
            }
            else
            {
            Console.WriteLine("Неправильний тип. Будь ласка, введіть правильний тип гравця (standart, winstreak, losestreak):");
            }
        }
        Console.WriteLine("Введіть пароль:");
        string password = Console.ReadLine();
        _gameManager.CreateAccount(name, type, password);

    }

    public string GetDescription()
    {
        return "Створти гравця";
    }
}