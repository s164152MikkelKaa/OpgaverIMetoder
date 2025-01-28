using System.Runtime.CompilerServices;

namespace OpgaverMedMetoderOpg7c
{
    internal class ProgramOpg7c
    {
        // "Opgave 7c" author: Mikkel Kaa.
        /* A game where 2 players takes turnes to subtragt a number from 1 to 10 from the count (starts at 100)
         * and the winner is the player that hits 0, if they want to quit midway through either player can quit by typing "q" or "Q".
        // */
        static void Main(string[] args)
        {
            int theCount = 100, userInputIndicatorValue;
            bool gameContinue = true, theIsP1Turn = true;
            Console.WriteLine("Velkommen til spillet.");
            Console.WriteLine();
            Console.WriteLine("Reglerne:");
            Console.WriteLine("Der er 2 spillere.");
            Console.WriteLine("Vinderen er den der får tælleren til at ramme 0.");
            Console.WriteLine($"Tælleren starter på {theCount}.");
            Console.WriteLine("Hver spiller skiftes til at trække en værdi fre tælleren.");
            Console.WriteLine("Værdien er mellem 1 og 10, begge tal inkluderet.");
            Console.WriteLine("Spiller 1 starter.");
            Console.WriteLine();
            Console.WriteLine("Tryk på en tast for at starte.");
            Console.ReadKey(true);
            while (gameContinue)
            {
                Console.Clear();
                Console.WriteLine("Det er spiller " + GetPlayerTurn(theIsP1Turn) + $"s tur, tælleren er på {theCount}.");
                Console.WriteLine("Indtast et tal mellem 1 og 10 for at trække det fra tælleren.");
                Console.WriteLine("(indtast \"Q\" for at afslutte tidligt, alle indtastninger afsluttes med enter)");
                // Gathers the user input into one variable that a decition can be made from (["q"||"Q"=-1],["3"=3],["fJ6"=0]).
                userInputIndicatorValue = GetActionFromUserInput();
                if (userInputIndicatorValue == -1) {
                    // End the game.
                    Console.WriteLine("Spillet afsluttes.");
                    gameContinue = false;
                } else if (userInputIndicatorValue == 0) {
                    Console.WriteLine("Ugyldigt input, tryk på en tast for at prøve igen.");
                    Console.ReadKey(true);
                } else {
                    // 'userInputIndicatorValue's value have to be from 1 to 10 here.
                    theCount -= userInputIndicatorValue;
                    // Test if the game have ben won.
                    if (theCount <= 0) {
                        // Game have ben won by one of the players.
                        Console.WriteLine();
                        Console.WriteLine("Tillykke spiller " + GetPlayerTurn(theIsP1Turn) + " du har vundet, tælleren er 0.");
                        Console.WriteLine("(spillet afsluttes)");
                        gameContinue = false;
                    } else {
                        // Game continues.
                        theIsP1Turn = !theIsP1Turn;
                    }
                }
            }
            // Wating for the user.
            Console.ReadKey(true);
            // "Return to main menue" or "end the program" choice is implemented in the main menue assignment.
        }

        static int GetActionFromUserInput()
        {
            string theStrIn = Console.ReadLine() ?? "";
            if (theStrIn == "q" || theStrIn == "Q") {
                // "End the game" request by a player, return the "end the game" indicator value.
                return -1;
            } else if (int.TryParse(theStrIn, out int theNumIn) && theNumIn > 0 && theNumIn < 11) {
                // A valid number have ben entered, return the number.
                return theNumIn;
            } else {
                // Invalid input, request new input by returning "invalid input" indicator value.
                return 0;
            }
        }

        static string GetPlayerTurn(bool itIsPlayer1sTurn)
        {
            if (itIsPlayer1sTurn) {
                return "1";
            }
            return "2";
        }
    }
}
