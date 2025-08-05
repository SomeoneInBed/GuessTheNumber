// See https://aka.ms/new-console-template for more information

using System.Drawing;

GetAppInfo();

//ask for user name
GreetUser(); 


while (true)
{
    //create a random number
    Random random = new Random();

    //correct number
    int correctNumber = random.Next(0, 11);

    //initial guess
    int guess = 0;
    Console.WriteLine("Guess a number between 1 and 10: ");

    while (guess != correctNumber)
    {
        //get user input
        string? input = Console.ReadLine();

        //check if user entered a number
        if (!int.TryParse(input, out guess) || guess < 0 || guess > 10)
        {
            PrintColorMessage(ConsoleColor.Red, "Please enter a valid number between 1 and 10.");
            continue; //skip to the next iteration of the loop
        }

        //convert input to number
        guess = Int32.Parse(input);

        if (guess != correctNumber)
        {
            PrintColorMessage(ConsoleColor.Red, "Wrong number, please guess again...");
        }
    }

    //success message
    PrintColorMessage(ConsoleColor.Yellow, "Congratulations!! You guess the number!");

    //ask to play again
    Console.WriteLine("Play again? [Y or N]: ");

    string? answer = Console.ReadLine()?.ToUpper();

    if(answer == "Y")
    {
        continue;
    }
    else if (answer == "N")
    {
        return;
    }
    else
    {
        Console.WriteLine("You are a troll... Leave...");
        return;
    }
}

static void GetAppInfo()
{
    string appName = "Number Guesser";
    string appVersion = "1.0.0";
    string appAuthor = "Traversy Media";

    //header text color
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"{appName} by {appAuthor} Version {appVersion}");

    //reset text color
    Console.ResetColor();
}

static void GreetUser()
{
    string? userName = string.Empty;
    //if user won't enter a name
    do
    {
        Console.WriteLine("What is your name?: ");

        userName = Console.ReadLine();
        if (string.IsNullOrEmpty(userName))
        {
            Console.WriteLine("You must enter a name.");
        }
    } while (string.IsNullOrEmpty(userName));

    Console.WriteLine($"Hello {userName}, let's play a game...");

}

static void PrintColorMessage(ConsoleColor color, string message)
{
    Console.ForegroundColor = color;
    Console.WriteLine(message);

    //reset text color
    Console.ResetColor();
}