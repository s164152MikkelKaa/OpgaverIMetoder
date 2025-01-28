using System.Diagnostics;
using System.Drawing;

namespace OpgaverMedMetoderOpg7
{
    internal class ProgramOpg7
    {
        // "Opgave 7" author: Mikkel Kaa.
        static void Main(string[] args)
        {
            // Assuming its run in debug VisualStudio debug mode, wont run if not.
            // Gets the other assignments from the file structure.
            string thisAssignmentsName = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Name;
            DirectoryInfo theVSWorkspace = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent;
            string curVSWorkspaceDir = theVSWorkspace.FullName;
            DirectoryInfo[] theAssignments = theVSWorkspace.GetDirectories("OpgaverMedMetoderOpg*");
            // Adds names of all assignments to theAssignmentsName, except this assignment itself.
            string[] theAssignmentsName = new string[theAssignments.Length - 1];
            for (int i = 0, ii = 0; i < theAssignments.Length; i++)
            {
                if (theAssignments[i].Name != thisAssignmentsName) {
                    theAssignmentsName[ii] = theAssignments[i].Name;
                    ii++;
                }
            }
            string subDirStructure = "\\bin\\Debug\\net8.0";
            // stageControlMain: -1 for main menue, 0 and above for index in theAssignmentsName, -2 for end program.
            int stageControlMain = -1;

            // Main program loop.
            while (stageControlMain > -2)
            {
                Console.Clear();
                if (stageControlMain == -1) {
                    // Runs main menue.
                    stageControlMain = MainMenu(theAssignmentsName);
                } else if (stageControlMain > -1 && stageControlMain < theAssignmentsName.Length) {
                    // Runs another assignment.
                    stageControlMain = RunAssignment(theAssignmentsName[stageControlMain], curVSWorkspaceDir, subDirStructure);
                } else if (stageControlMain >= theAssignmentsName.Length) {
                    // Error handeling, just to cover all bases.
                    stageControlMain = -1;
                }
            }
        }

        static int RunAssignment(string asignDesegnation, string workspacePath, string subDirPath)
        {
            // Creates the files path name.
            string filePath = workspacePath + "\\" + asignDesegnation + subDirPath + "\\" + asignDesegnation + ".exe";
            if (File.Exists(filePath)) {
                // Runs the assignment and waits for it to exit.
                Process theAssignment = Process.Start(filePath);
                theAssignment.WaitForExit();
                // Asking if the user will end the program or back to the main menue.
                if (EndAfterAssignmentRun()) {
                    return -2;
                }
            } else {
                Console.WriteLine($"Kan ikke finde exe filen for opgave {asignDesegnation}.");
                Console.ReadKey(true);
            }
            return -1;
        }

        static bool EndAfterAssignmentRun()
        {
            Console.Clear();
            Console.WriteLine("Ønsker du at afslutte programmet helt? (eller gå tilbage til hovedmenuen).");
            Console.WriteLine("Indtast Y for at afslute, alt andet for hovedmenuen.");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.Y:
                    return true;
                default:
                    return false;
            }
        }

        static int MainMenu(string[] theMenueChoices)
        {
            // Adding all entries from theMenueChoices, adds an exit item to the end.
            Point[] coorForMenueItems = new Point[theMenueChoices.Length + 1];
            int[] coorespondingReturn = new int[theMenueChoices.Length + 1];
            Console.WriteLine("Hovedmenu, vælg en opgave at køre.");
            Console.WriteLine("Skift menuenhed med piletasterne og vælg med enter.");
            /* The assignment asks for main menue input to be writing assignment numbers,
             * but as its also requested the main menue is to be dynamic and capable of having assignments addet to it
             * and I want to split assignments 7a, 7b and 7c into their owne menue entries, i deem
             * the stated numbers only input to be unfeasable, therefore opted to change the main menue input method.
            // */
            Console.WriteLine(); // Empty line for astheathics.
            for (int i = 0; i < theMenueChoices.Length; i++)
            {
                // Sets the place the cursor is to be placed when this menue item is selected.
                coorForMenueItems[i] = new Point(Console.CursorLeft, Console.CursorTop);
                // Sets the value to be returned to the main loop if this menue item is selected.
                coorespondingReturn[i] = i;
                Console.WriteLine(" " + theMenueChoices[i]);
            }
            Console.WriteLine(); // Empty line for astheathics.
            // Adds an exit program from main menue.
            coorForMenueItems[coorForMenueItems.Length - 1] = new Point(Console.CursorLeft, Console.CursorTop);
            coorespondingReturn[coorespondingReturn.Length - 1] = -2;
            Console.WriteLine(" " + "Luk programmet.");
            return MainMenuInputHandeler(coorForMenueItems, coorespondingReturn);
        }

        static int MainMenuInputHandeler(Point[] coorMenueItem, int[] responseValues)
        {
            int selectedItem = 0;
            bool readNextInput = true;
            while (readNextInput)
            {
                // Sets curson on current menue item.
                Console.SetCursorPosition(coorMenueItem[selectedItem].X, coorMenueItem[selectedItem].Y);
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        // Go a menue item up, by decremeanting the selectedItem var.
                        if (selectedItem <= 0) {
                            // If at the top, goes to the bottom.
                            selectedItem = coorMenueItem.Length;
                        }
                        selectedItem--;
                        break;
                    case ConsoleKey.DownArrow:
                        // Go a menue item down, by incremeanting the selectedItem var.
                        selectedItem++;
                        // If at bottom, go to top.
                        selectedItem %= coorMenueItem.Length;
                        break;
                    case ConsoleKey.Enter:
                        // Confirm choice of currently selected menue item.
                        readNextInput = false;
                        break;
                    default:
                        break;
                }
            }
            return responseValues[selectedItem];
        }
    }
}
