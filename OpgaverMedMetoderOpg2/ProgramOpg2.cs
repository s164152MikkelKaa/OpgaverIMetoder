namespace OpgaverMedMetoderOpg2
{
    internal class ProgramOpg2
    {
        // "Udskrivning af brugerinput" author: Mikkel Kaa.
        static void Main(string[] args)
        {
            // Got nothing to add.
            Console.Write("Skriv noget tekst ind og afslut med enter: ");
            WriteToConsole(Console.ReadLine());
            // Addet the following to prevent emideatly closing the console window.
            Console.ReadKey(true);
        }

        static void WriteToConsole(string theToWrite)
        {
            Console.WriteLine(theToWrite);
        }
    }
}
