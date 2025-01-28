namespace OpgaverMedMetoderOpg4
{
    internal class ProgramOpg4
    {
        // "Navn og alder med gruppeinddeling" author: Mikkel Kaa.
        static void Main(string[] args)
        {
            // theInName <=> ('the' 'prefix to prevent using reserved names')('In' 'user input')('Name' 'descriptor for the variables content').
            string theInName;
            int theInAge;
            Console.Write("Indtast dit navn og afslut med enter: ");
            // The '??' funktion: use the value of left side if it isn't null, if its null use the value of right side.
            // The '.Trim()' removes white-space characters from the front and back of the string, until it encounters a non white-space character.
            theInName = (Console.ReadLine() ?? "").Trim();
            Console.Write("Indtast din alder som heltal og afslut med enter: ");
            if (int.TryParse(Console.ReadLine(), out theInAge)) {
                Console.WriteLine(AgeCategoriser(theInName, theInAge));
            } else Console.WriteLine("Den indtastede alder kunne ikke forstås som et heltal, afslutter denne opgave.");
            // Wating for the user.
            Console.ReadKey(true);
        }

        static string AgeCategoriser(string theName, int theAge)
        {
            string theResponce = "Hej ";
            if (theName == "") {
                // Writes a message in case the user didnt provide a name, or only used the spacebar(example).
                theName = "*Intet navn angivet*";
            }
            theResponce += theName + " ";
            if (theAge < 0) {
                return "Den indtastede alder er negativ, dette er ikke tilladt, afslutter denne opgave.";
            } else if (theAge < 2) {
                // 0 or 1.
                theResponce += $"du er en nyfødt på {theAge} år.";
            } else if (theAge < 4) {
                // 2 or 3.
                theResponce += $"du er i aldersgruppen for dagpleje eller vuggestue, med en alder på {theAge} år.";
            } else if (theAge < 6) {
                // 4 or 5.
                theResponce += $"du er i aldersgruppen for børnehave, med en alder på {theAge} år.";
            } else if (theAge < 19) {
                // From 6 to 18.
                theResponce += $"du er i aldersgruppen for at gå i skole, med en alder på {theAge} år.";
            } else {
                // 19 or above.
                theResponce += $"du er {theAge} år og nu begynder livet at blive alvor.";
            }
            return theResponce;
        }
    }
}
