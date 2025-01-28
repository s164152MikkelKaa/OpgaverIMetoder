namespace OpgaverMedMetoderOpg1
{
    internal class ProgramOpg1
    {
        // "Returnering af en streng" author: Mikkel Kaa.
        static void Main(string[] args)
        {
            // Got nothing to comment on.
            Console.WriteLine(MyFirstMethod());
            // Addet the following to prevent emideatly closing the console window.
            Console.ReadKey(true);
        }

        static string MyFirstMethod()
        {
            return "Hello World!";
        }
    }
}
