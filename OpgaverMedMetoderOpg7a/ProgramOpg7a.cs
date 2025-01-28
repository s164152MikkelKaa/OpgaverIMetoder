namespace OpgaverMedMetoderOpg7a
{
    internal class ProgramOpg7a
    {
        // "Opgave 7a" author: Mikkel Kaa.
        static void Main(string[] args)
        {
            double theInTemperatur;
            Console.WriteLine("Indtast din temperatur og afslut med enter.");
            if (double.TryParse(Console.ReadLine(), out theInTemperatur)) {
                Console.WriteLine("Er den angivede temperatur i Celsius eller Fahrenheit?");
                Console.WriteLine("(indtast C/F og afslut med enter)");
            } else {
                Console.WriteLine("Kunne ikke læse tallet, afslutter opgaven.");
            }
            // Wating for the user.
            Console.ReadKey(true);
        }
    }
}
