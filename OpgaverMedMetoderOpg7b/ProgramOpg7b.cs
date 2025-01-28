using System.Globalization;

namespace OpgaverMedMetoderOpg7b
{
    internal class ProgramOpg7b
    {
        // "Opgave 7b" author: Mikkel Kaa.
        static void Main(string[] args)
        {
            int theInNum;
            string theStrInNum;
            Console.WriteLine("Indtast det ønskede tal som heltal og afslut med enter.");
            Console.WriteLine("(Tilføj før tallet \"0x\" for hexadecimal og \"0b\" for binær, decimaltal indtastes uden tilføjelser)");
            // Code editor complained about 'Console.ReadLine()' returns type string? (nullable), addet '?? ""' so an empty string replaces a null.
            theStrInNum = Console.ReadLine() ?? "";
            if (theStrInNum.StartsWith("0x") || theStrInNum.StartsWith("0X")) {
                // The user input is supposed to be a hexadecimal number.
                if (TheInStringToIntValue(theStrInNum.Substring(2), NumberStyles.HexNumber, out theInNum)) {
                    // The given number is a valid hexadecimal number.
                    Console.WriteLine();
                    Console.WriteLine(" " + TheToDecimal(theInNum));
                    Console.WriteLine("*" + TheToHex(theInNum));
                    Console.WriteLine(" " + TheToBin(theInNum));
                }
            } else if (theStrInNum.StartsWith("0b") || theStrInNum.StartsWith("0B")) {
                // The user input is supposed to be a binary number.
                if (TheInStringToIntValue(theStrInNum.Substring(2), NumberStyles.BinaryNumber, out theInNum)) {
                    Console.WriteLine();
                    Console.WriteLine(" " + TheToDecimal(theInNum));
                    Console.WriteLine(" " + TheToHex(theInNum));
                    Console.WriteLine("*" + TheToBin(theInNum));
                }
            } else if (TheInStringToIntValue(theStrInNum, NumberStyles.Number, out theInNum)) {
                // The final test, there are no prefix, atempts to convert to a decimal number.
                Console.WriteLine();
                Console.WriteLine("*" + TheToDecimal(theInNum));
                Console.WriteLine(" " + TheToHex(theInNum));
                Console.WriteLine(" " + TheToBin(theInNum));
            }
            // Wating for the user.
            Console.ReadKey(true);
            // "Return to main menue" or "end the program" choice is implemented in the main menue assignment.
        }

        static bool TheInStringToIntValue(string theStrNumIn, NumberStyles theTargetStyle, out int theResult)
        {
            // Atempts conversion of the number, assuming the number is of the type 'theTargetStyle'.
            // Culture can be invariant as the input is supposed to be a howle number so no ","/"." confusion.
            if (int.TryParse(theStrNumIn, theTargetStyle, CultureInfo.InvariantCulture, out theResult)) {
                return true;
            }
            // Adding the user error message here, so only one is needet regardless of witch conversion fails.
            Console.WriteLine("Det indtastede kunne ikke læses som et tal af den specificerede type, afslutter opgaven.");
            return false;
        }

        static string TheToDecimal(int theNumIn)
        {
            return "Decimal:     " + theNumIn.ToString();
        }

        static string TheToHex(int theNumIn)
        {
            return "Hexadecimal: " + theNumIn.ToString("X");
        }

        static string TheToBin(int theNumIn)
        {
            return "Binær:       " + Convert.ToString(theNumIn, 2);
        }
    }
}
