namespace OpgaverMedMetoderOpg6
{
    internal class ProgramOpg6
    {
        // "Gæt et tal-spil" author: Mikkel Kaa.
        static void Main(string[] args)
        {
            // For ease of changing the games parameters they are gathered here.
            // 'theCorNumMin' <=> ('the' 'avoid reserved names')('CorNum' 'correct number')('Min' 'min').
            int theCorNumMin = 1, theCorNumMax = 25, remainGuess = 5;
            string theGuessStr;
            int theGuessedValue;
            int theCorNum = GetRandomNumber(theCorNumMin, theCorNumMax);
            Console.WriteLine("Velkommen til \"Gæt et tal\"");
            while (remainGuess > 0)
            {
                Console.WriteLine($"Du har {remainGuess} gæt tilbage, gæt på et tal mellem {theCorNumMin} og {theCorNumMax}, tallende selv inkluderet, afslut med enter.");
                theGuessStr = (Console.ReadLine() ?? "");
                // If TryParse fails the remaining part of the isn't run so 'theGuessedValue' don't need to be defined.
                if (int.TryParse(theGuessStr, out theGuessedValue) && theGuessedValue >= theCorNumMin && theGuessedValue <= theCorNumMax) {
                    // A valid guess have ben made.
                    if (GuessIsCorrect(theGuessedValue, theCorNum)) {
                        Console.WriteLine();
                        Console.WriteLine($"Du har gættet korrekt, tallet var {theCorNum}, du har vundet, afslutter opgaven.");
                        // End loop, prevents printing 'user lost' message.
                        remainGuess = -1;
                    } else {
                        GuessIsIncorect(theGuessedValue, theCorNum);
                        remainGuess--;
                    }
                } else {
                    // The user input wasn't a number or the number isn't a valid guess value.
                    // Deleates the users input from the console and don't use up a guess.
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    for (int i = 0; i < theGuessStr.Length; i++)
                        Console.Write(" ");
                    // Owerrites the previous "remaining guesses" line.
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                }
            }
            if (remainGuess != -1) {
                // The loop ending on -1 is 'guess was correct', all other is ran out of guesses (user lost).
                Console.WriteLine();
                Console.WriteLine("Du har ikke flere gæt tilbage, du har tabt, afslutter opgaven.");
            }
            // Wating for the user.
            Console.ReadKey(true);
        }

        static int GetRandomNumber(int minValue, int maxValue)
        {
            // Generates a random number from 'minValue' to 'maxValue', unlike 'Random.Next' the 'maxValue' is includet.
            Random theRNG = new();
            return theRNG.Next(minValue, maxValue + 1);
        }

        static bool GuessIsCorrect(int theGuess, int theCorNum)
        {
            return theGuess == theCorNum;
        }

        static void GuessIsIncorect(int theGuess, int theCorNum)
        {
            // Decition for if guess is larger or smaller, can't be the same it's already ben checked.
            if (theGuess > theCorNum) {
                Console.WriteLine("Det korrekte tal er lavere.");
            } else {
                // If the guess isn't larger then it must be lower.
                Console.WriteLine("Det korrekte tal er højere.");
            }
        }
    }
}
