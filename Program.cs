namespace rockpaperscissors;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Rock Paper Scissors");
        GameManager gameManager = new GameManager();
        gameManager.PlayGame();
    }    
}
