using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assignment
{
    public class Input
    {
        private string inputText;
        public string fetchedText => inputText;

        /// <summary>
        /// Searches for an asterisk, and if found, returns its index
        /// </summary
        /// <returns>
        /// int: Index asterisk found at.
        /// </returns>
        private int searchForEndIndex(string text) {
            char ASTERISK = '*';
            int currentIndex = 0;
            // For each character in the given text parameter.
            foreach (char c in text) {
                // If it's an asterisk, stop searching.
                if (c == ASTERISK)
                {
                    break;
                }
                // Otherwise increment the search index.
                else {
                    currentIndex++;
                }
            }
            // If no asterisk is found, return -1
            if (currentIndex == text.Length) {
                currentIndex = -1;
            }
            // Return the index at which the search stopped.
            return currentIndex;
        }
        /// <summary>
        /// Handles and saves the keyboard input.
        /// </summary>
        public void manualTextInput()
        {
            char SPACE = ' ';
            char FULLSTOP = '.';
            string sentence = "  ";
            string text = " ";
            int endIndex = -1;
            bool entryClosed = false;


            while (entryClosed == false) { 
                // Check the current text for an asterisk.
                endIndex = searchForEndIndex(text);
                // If no asterisk was found in the text:
                if (endIndex == -1) { 

                    Console.Write(" : ");
                    sentence = Console.ReadLine();

                    // If the given input doesn't end with a fullstop or asterisk:
                    // Add a full-stop before concatenation.
                    if (!sentence.EndsWith(FULLSTOP) && !sentence.EndsWith("*"))
                    {
                        sentence = string.Concat(sentence, FULLSTOP);
                    }
                    // Concatenate the new sentence(s) with the previously entered sentences.
                    text = string.Concat(text, sentence, SPACE);
                }
                // If an asterisk was found, stop allowing inputs.
                else { 
                    entryClosed = true;       
                }
                
            }
            // Save the concatenation to the private text variable.
            inputText = text.Substring(0, endIndex);
            return;
        }

        /// <summary>
        ///     Method used to open, a file based on the given path.
        /// </summary>
        /// <returns>
        ///     void.
        /// </returns>
        public void fileTextInput(string fileName)
        { 
            // Parses the given path to the current working directory
            string localFileDir = Environment.CurrentDirectory;
            string[] subs = localFileDir.Split(@"\bin");
            string fileDir = Path.Combine(subs[0], fileName + ".txt");


            try
            {   
                // If no filename is given, throw a null exception.
                if (fileName == " ") {
                    throw new ArgumentNullException();
                }
                // Read all of the text in the file into a string.
                string text = File.ReadAllText(fileDir);

                // If some text is read from the file:
                if (text != null)
                {
                    // Find the end index for analysis.
                    int endIndex = searchForEndIndex(text);
                    // Save to private variable.
                    inputText = text.Substring(0, endIndex);
                    
                    return;
                }
                // If no text is found, assume that the file could not be found.
                else {
                    throw new FileNotFoundException();
                }
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("No file-name provided, exiting program.");
                Console.ReadKey();
                Environment.Exit(1);
            }
            catch (FileNotFoundException) {
                Console.WriteLine("Could not find file with name given. \n Press a key to exit");
                Console.ReadKey();
                Environment.Exit(1);
            }


        }

    }
}
