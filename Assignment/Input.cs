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

        private int searchForEndIndex(string text) {
            char ASTERISK = '*';
            int currentIndex = 0;
            foreach (char c in text) {
                if (c == ASTERISK)
                {
                    break;
                }
                else {
                    currentIndex++;
                }
            }
            if (currentIndex == text.Length) {
                currentIndex = -1;
            }
            return currentIndex;
        }
        //Handles the text input for Assessment         
        //Method: manualTextInput
        //Arguments: none
        //Returns: string
        //Gets text input from the keyboard
        public string manualTextInput()
        {
            char SPACE = ' ';
            char FULLSTOP = '.';
            string sentence = "  ";
            string text = default;
            int endIndex = -1;
            bool entryClosed = false;


            while (entryClosed == false) { 
                endIndex = searchForEndIndex(sentence);
                if (endIndex == -1) { 
                    Console.Write(" : ");
                    sentence = Console.ReadLine();
                    if (!sentence.EndsWith(FULLSTOP) && !sentence.EndsWith("*"))
                    {
                        sentence = string.Concat(sentence, FULLSTOP);
                    }
                    
                    text = string.Concat(text, sentence, SPACE);
                }
                else { 
                    entryClosed = true;       
                }
                
            }
            
            return text.Substring(0, endIndex);
        }

        //Method: fileTextInput
        //Arguments: string (the file path)
        //Returns: string
        //Gets text input from a .txt file
        public string fileTextInput(string fileName)
        { 
            string localFileDir = Environment.CurrentDirectory;
            string[] subs = localFileDir.Split(@"\bin");
            string fileDir = Path.Combine(subs[0], fileName + ".txt");
            string text = File.ReadAllText(fileDir);
            int endIndex = searchForEndIndex(text);
            Console.WriteLine(text.Substring(0, endIndex));

            return text.Substring(0, endIndex);
        }

    }
}
