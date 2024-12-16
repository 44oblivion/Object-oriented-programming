public class GetPlayerByUserName : ICommand
{
    public GameManager _gameManager;
    
    public GetPlayerByUserName(GameManager gameManager)
    {
        _gameManager = gameManager;
    }
    public void Execute()
    {
        Console.WriteLine("Введіть ім'я гравця:");
        string username = Console.ReadLine();
        _gameManager.FindAccountByUserName(username);
    }

    public string GetDescription()
    {
        return "Отримати гравця за ім'ям";
    }
}