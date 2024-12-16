public class Login : ICommand
{
    static public GameManager _gameManager;

     public Login(GameManager gameManager)
     {
         _gameManager = gameManager;
     }

     public void Execute()
     {
         Console.WriteLine("Вкажіть ваш логін");
         string username = Console.ReadLine();
         Console.WriteLine("Вказіть ваш пароль");
         string password = Console.ReadLine();
         _gameManager.Login(username, password);
         
     }

     public string GetDescription() => "Увійти в акаунт";
}