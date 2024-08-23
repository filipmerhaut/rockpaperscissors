namespace rockpaperscissors;

public class GameManager
{

    public void PlayGame()
    {        
        while (true)
        {
            PlayRound();
            Console.WriteLine("Play again? (Y/N): ");
            string input = Console.ReadLine();
            if (input != "Y" && input != "y")
            {
                break;
            }
        }
    }

    private void PlayRound()
    {
        Choice playerChoice = GetPlayerChoice();
        Choice computerChoice = GetComputerChoice();
        RoundResult result = GetRoundResult(playerChoice, computerChoice);
        Console.WriteLine($"Player chose {playerChoice}");
        Console.WriteLine($"Computer chose {computerChoice}");
        if (result == RoundResult.Player1Winner)
        {
            Console.WriteLine("You win!");
        }
        else if (result == RoundResult.Player2Winner)
        {
            Console.WriteLine("Computer wins!");
        }
        else
        {
            Console.WriteLine("It's a draw!");
        }
        Console.WriteLine("");
    }

    private Choice GetComputerChoice()
    {
        Random random = new Random();
        int choice = random.Next(0, 3);
        return (Choice)choice;
    }

    private Choice GetPlayerChoice()
    {
        Console.WriteLine("Enter your choice (R)ock, (P)aper, (S)cissors: ");
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "R" || input == "r")
            {
                return Choice.Rock;
            }
            else if (input == "P" || input == "p")
            {
                return Choice.Paper;
            }
            else if (input == "S" || input == "s")
            {
                return Choice.Scissors;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }                
    }

    private RoundResult GetRoundResult(Choice player1Choice, Choice player2Choice)
    {
        if (player1Choice == player2Choice)
        {
            return RoundResult.Draw;
        }
        else if (player1Choice == Choice.Rock && player2Choice == Choice.Scissors ||
                 player1Choice == Choice.Paper && player2Choice == Choice.Rock ||
                 player1Choice == Choice.Scissors && player2Choice == Choice.Paper)
        {
            return RoundResult.Player1Winner;
        }
        else
        {
            return RoundResult.Player2Winner;
        }
    }

    public enum Choice
    {
        Rock,
        Paper,
        Scissors
    }

    public enum RoundResult
    {
        Player1Winner,
        Player2Winner,
        Draw
    }
}