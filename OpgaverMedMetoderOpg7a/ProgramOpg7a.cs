using System.Globalization;

namespace OpgaverMedMetoderOpg7a
{
    internal class ProgramOpg7a
    {
        // "Opgave 7a" author: Mikkel Kaa.
        static void Main(string[] args)
        {
            string theInTemperaturStr, theInputedType;
            double theInTemperatur;
            Console.WriteLine("Indtast din temperatur og afslut med enter.");
            theInTemperaturStr = Console.ReadLine();
            // Convert all "." and "," to the current system number decimal seperator.
            theInTemperaturStr = theInTemperaturStr.Replace(".", ",").Replace(",", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
            if (double.TryParse(theInTemperaturStr, out theInTemperatur)) {
                Console.WriteLine("Er den angivede temperatur i Celsius eller Fahrenheit?");
                Console.Write("(indtast C/F og afslut med enter) ");
                theInputedType = Console.ReadLine();
                Console.WriteLine(); // Empty line for astheadiks (looks better).
                switch (theInputedType)
                {
                    case "C":
                    case "c":
                        FromCelsius(theInTemperatur);
                        break;
                    case "F":
                    case "f":
                        FromFahrenheit(theInTemperatur);
                        break;
                    default:
                        Console.WriteLine("Det indtastede blev ikke genkendt, afslutter opgaven.");
                        break;
                }
            } else {
                Console.WriteLine("Kunne ikke læse tallet, afslutter opgaven.");
            }
            // Wating for the user.
            Console.ReadKey(true);
            // "Return to main menue" or "end the program" choice is implemented in the main menue assignment.
        }

        static void PrintAResult(string theUnit, double theValue)
        {
            theUnit += ":";
            Console.WriteLine($"{theUnit,-12}{theValue:N2}");
        }

        static void FromFahrenheit(double theInFahr)
        {
            double theInCels = (theInFahr - 32.0) * 5.0 / 9.0;
            if (theInCels >= -273.15) {
                // The temperatur exists, prints the temperatures.
                PrintAResult("Fahrenheit", theInFahr);
                PrintAResult("Celsius", theInCels);
                PrintAResult("Kelvin", theInCels + 273.15);
                PrintAResult("Réaumur", theInCels * 4.0 / 5.0);
            } else {
                // The temperatur is below 0 Kelvin, and is impossible.
                Console.WriteLine("Den givende temperatur er under det abdolute nulpunkt, afslutter opgaven.");
            }
        }

        static void FromCelsius(double theInCels)
        {
            if (theInCels >= -273.15) {
                // The temperatur exists, prints the temperatures.
                PrintAResult("Celsius", theInCels);
                PrintAResult("Fahrenheit", theInCels * 9.0 / 5.0 + 32.0);
                PrintAResult("Kelvin", theInCels + 273.15);
                PrintAResult("Réaumur", theInCels * 4.0 / 5.0);
            } else {
                // The temperatur is below 0 Kelvin, and is impossible.
                Console.WriteLine("Den givende temperatur er under det abdolute nulpunkt, afslutter opgaven.");
            }
        }
    }
}
