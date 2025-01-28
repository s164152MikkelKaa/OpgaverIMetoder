namespace OpgaverMedMetoderOpg5
{
    internal class ProgramOpg5
    {
        // "Opdeling af komma-separeret streng" author: Mikkel Kaa.
        static void Main(string[] args)
        {
            string theInFull;
            string[] theInSeperated;
            Console.WriteLine("Indtast de ønskede tekststykker, anvend \",\" tegnet til at adskilde tekststykkerne, afslut med enter.");
            theInFull = (Console.ReadLine() ?? "");
            /* Build in method doing the same.
            theInSeperated = theInFull.Split(','); // */
            theInSeperated = TheStringSplitter(theInFull);
            Console.WriteLine($"Du har indtastet {theInSeperated.Length} tekststykker, tekststykkerne er:");
            for (int i = 0; i < theInSeperated.Length; i++)
            {
                Console.WriteLine(theInSeperated[i]);
            }
            // Wating for the user.
            Console.ReadKey(true);
        }

        static string[] TheStringSplitter(string theString)
        {
            string[] theSplitString;
            // 'currentStringIndex' represents the current chars index when iterating through 'theString', in bouth loops.
            int numOfSeperators = 0, indexOfStartSplit = 0, currentStringSection = 0, currentStringIndex;
            // Counts the number of seperation characters.
            for (currentStringIndex = 0; currentStringIndex < theString.Length; currentStringIndex++)
                if (theString[currentStringIndex] == ',')
                    numOfSeperators++;
            theSplitString = new string[numOfSeperators + 1];
            // The following loop runs for eatch of the seperator characters, and sets the string sections except the last one.
            // Can be done as a for-loop, it iterates through 'theString' but the termination criteria is unrelated to the iterator, therefore used while.
            currentStringIndex = 0;
            while (currentStringSection < numOfSeperators)
            {
                if (theString[currentStringIndex] == ',') {
                    // Simplifikation from '= theString.Substring(indexOfStartSplit, currentStringIndex - indexOfStartSplit)'.
                    theSplitString[currentStringSection] = theString[indexOfStartSplit..currentStringIndex];
                    indexOfStartSplit = currentStringIndex + 1;
                    currentStringSection++;
                }
                currentStringIndex++;
            }
            // Sets the last string section, to the rest of 'theString'.
            // Simplifikation from '= theString.Substring(indexOfStartSplit)'.
            // If there are no seperators in 'theString' then 'indexOfStartSplit' is 0, otherwise its 'index of last occurence of ","' + 1.
            theSplitString[theSplitString.Length - 1] = theString[indexOfStartSplit..];

            // Iterates through 'theString' twice due to avoiding changing array size.
            // Can be simplified by using List or similare dynamic size types, didnt seem like it was in the assignments spirit to do so.
            return theSplitString;
        }
    }
}
