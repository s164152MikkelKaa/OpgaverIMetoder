namespace OpgaverMedMetoderOpg3
{
    internal class ProgramOpg3
    {
        /* This solution contains the following assignments, author: Mikkel Kaa.
         * Assignment 3  "Summen af tre tal".
         * Assignment 3a "Subtraktion af tre tal".
         * Assignment 3b "Multiplikation af tre tal".
         * Assignment 3c "Summen af to tal divideret med et tredje".
        // */
        static void Main(string[] args)
        {
            // Decidet to run the 4 assignments in sequence, as they are mutch the same.
            // Comments mark the start and end of eatch assignment.

            // *** start Assignment 3 ***
            // numIn1_3 == ('num' 'a number')('In' 'a user input')('1' 'the first')('_3' 'for assignment 3').
            double numIn1_3, numIn2_3, numIn3_3, outputOfSum;
            Console.WriteLine("Opgave 3 \"Summering\": Indtast tre tal efter hinanden og afslut hvert med enter.");
            // By doing all the ReadLine and TryParse in this manner, if the first or second TryParse returns false,
            // the remaining TryParse, and thereby ReadLine, is skiped, so the user dont have to write irrelevant input.
            if (double.TryParse(Console.ReadLine(), out numIn1_3) 
                && double.TryParse(Console.ReadLine(), out numIn2_3)
                && double.TryParse(Console.ReadLine(), out numIn3_3))
            {
                // Will only run this if all the TryParse returned true (succedet in parsing the string to double).
                outputOfSum = MethodSum(numIn1_3, numIn2_3, numIn3_3);
                Console.WriteLine($"Summen af tallende er: {outputOfSum}");
            } else Console.WriteLine("Det indtastede kunne ikke forstås som et tal, afslutter denne opgave.");
            // Wating for the user to read before continuing,
            // '(true)' prevents the keypress being written in the console, a random "j"(example) disturbing the design.
            Console.ReadKey(true);
            // *** end Assignment 3 ***

            // Empty line for seperation of assignments.
            Console.WriteLine();

            // *** start Assignment 3a ***
            // numIn1_3a == ('num' 'a number')('In' 'a user input')('1' 'the first')('_3a' 'for assignment 3a').
            double numIn1_3a, numIn2_3a, numIn3_3a, outputOfSubtrakt;
            Console.WriteLine("Opgave 3a \"Subtraktion\": Indtast tre tal efter hinanden og afslut hvert med enter.");
            // Testing user input, if Parse fails, writes the error message and ends the assignment section,
            // skiping any remaining ReadLine calls.
            if (double.TryParse(Console.ReadLine(), out numIn1_3a)
                && double.TryParse(Console.ReadLine(), out numIn2_3a)
                && double.TryParse(Console.ReadLine(), out numIn3_3a))
            {
                // All TryParse were success.
                outputOfSubtrakt = MethodSubtrakt(numIn1_3a, numIn2_3a, numIn3_3a);
                Console.WriteLine($"Resultatet af subtraktionen er: {outputOfSubtrakt}");
            } else Console.WriteLine("Det indtastede kunne ikke forstås som et tal, afslutter denne opgave.");
            // Wating for the user.
            Console.ReadKey(true);
            // *** end Assignment 3a ***

            Console.WriteLine();

            // *** start Assignment 3b ***
            // numIn1_3b == ('num' 'a number')('In' 'a user input')('1' 'the first')('_3b' 'for assignment 3b').
            double numIn1_3b, numIn2_3b, numIn3_3b, outputOfMultiplikation;
            Console.WriteLine("Opgave 3b \"Multiplikation\": Indtast tre tal efter hinanden og afslut hvert med enter.");
            // Testing user input.
            if (double.TryParse(Console.ReadLine(), out numIn1_3b)
                && double.TryParse(Console.ReadLine(), out numIn2_3b)
                && double.TryParse(Console.ReadLine(), out numIn3_3b))
            {
                // All TryParse were success.
                outputOfMultiplikation = MethodMultiplikation(numIn1_3b, numIn2_3b, numIn3_3b);
                Console.WriteLine($"Resultatet af multiplikationen er: {outputOfMultiplikation}");
            } else Console.WriteLine("Det indtastede kunne ikke forstås som et tal, afslutter denne opgave.");
            // Wating for the user.
            Console.ReadKey(true);
            // *** end Assignment 3b ***

            Console.WriteLine();

            // *** start Assignment 3c ***
            // numIn1_3c == ('num' 'a number')('In' 'a user input')('1' 'the first')('_3c' 'for assignment 3c').
            double numIn1_3c, numIn2_3c, numIn3_3c, outputOfDivisionOfSum;
            Console.WriteLine("Opgave 3c \"Division på en summering\" Indtast tre tal, summen af de første to divideres med det tredje.");
            Console.WriteLine("Indtast tallende efter hinanden og afslut hvert tal med enter.");
            // Testing user input.
            if (double.TryParse(Console.ReadLine(), out numIn1_3c)
                && double.TryParse(Console.ReadLine(), out numIn2_3c)
                && double.TryParse(Console.ReadLine(), out numIn3_3c))
            {
                // All TryParse were success, performs extra test to prevent devide by 0.
                if (numIn3_3c != 0.0) {
                    outputOfDivisionOfSum = MethodDevisionOfASum(numIn1_3c, numIn2_3c, numIn3_3c);
                    Console.WriteLine($"Resultatet af beregningen er: {outputOfDivisionOfSum}");
                } else Console.WriteLine("Det sidst indtastede tal må ikke være 0, afslutter denne opgave.");
            } else Console.WriteLine("Det indtastede kunne ikke forstås som et tal, afslutter denne opgave.");
            // Wating for the user.
            Console.ReadKey(true);
            // *** end Assignment 3c ***
        }

        static double MethodSum(double theNum1, double theNum2, double theNum3)
        {
            // Part of Assignment 3.
            return theNum1 + theNum2 + theNum3;
        }

        static double MethodSubtrakt(double theNum1, double theNum2, double theNum3)
        {
            // Part of Assignment 3a.
            // Performs subtraktion, i assumed the second number needet to be subtrakted from the first
            // and the third number was to be subtracted from the result of the first two.
            return theNum1 - theNum2 - theNum3;
        }

        static double MethodMultiplikation(double theNum1, double theNum2, double theNum3)
        {
            // Part of Assignment 3b.
            return theNum1 * theNum2 * theNum3;
        }

        static double MethodDevisionOfASum(double theNum1, double theNum2, double theNum3)
        {
            // Part of Assignment 3c.
            // Expects theNum3 != 0.0 is ensured externally (externally to this method).
            return (theNum1 + theNum2) / theNum3;
        }
    }
}
