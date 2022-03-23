using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace Assignment
{
    public class Analyse
    {
        //Handles the analysis of text

        //Method: analyseText
        //Arguments: string
        //Returns: list of integers
        //Calculates and returns an analysis of the text
        public List<int> analyseText(string input)
        {
            //List of integers to hold the first five measurements:
            //1. Number of sentences
            //2. Number of vowels
            //3. Number of consonants
            //4. Number of upper case letters
            //5. Number of lower case letters
            List<int> values = new List<int>();
            //Initialise all the values in the list to '0'
            for(int i = 0; i<5; i++)
            {
                values.Add(0);
            }

            // Finds the amount of sentences.

            // Defines the regex filter.
            string sentences = @"[.]\s{1}|[.*]+";
            // Creates a regex object, passing in the filter.
            Regex rgSentences = new Regex(sentences);
            // Creates a matchCollection object from the matches method of the regex object.
            MatchCollection matchSentences = rgSentences.Matches(input);
            // Stores the value in the first index of the analysis list.
            values[0] = matchSentences.Count;

            // Finds the amount of vowels.
            string vowels = @"([AEIOUaeiou]){1}";
            Regex rgVowels = new Regex(vowels);
            MatchCollection matchVowels = rgVowels.Matches(input);
            values[1] = matchVowels.Count;

            // Finds the amount of consonants.
            string consonants = @"([bcdfghjklmnpqrstvwxyzBCDFGHJKLMNPQRSTVWXYZ]){1}";
            Regex rgConsonants = new Regex(consonants);
            MatchCollection matchConsonants = rgConsonants.Matches(input);
            values[2] = matchConsonants.Count;

            // Finds the amount of upper case letters.
            string upperCase = @"([ABCDEFGHIJKLMNOPQRSTUVWXYZ]){1}";
            Regex rgUpperCase = new Regex(upperCase);
            MatchCollection matchUpperCase = rgUpperCase.Matches(input);
            values[3] = matchUpperCase.Count;

            // Finds the amount of lower case letters.
            string lowerCase = @"([abcdefghijklmnopqrstuvwxyz]){1}";
            Regex rgLowerCase = new Regex(lowerCase);
            MatchCollection matchLowerCase = rgLowerCase.Matches(input);
            values[4] = matchLowerCase.Count;

            // Finds occurences of long words
            string longWords = @"\b\w{7,}\b";
            Regex rgLongWords = new Regex(longWords);
            MatchCollection matchLongWords = rgLongWords.Matches(input);

            WriteFile(matchLongWords);

            return values;
        }

        // Unique Method
        private void WriteFile(MatchCollection longWordCollection) {
            try
            {
                string localFileDir = Environment.CurrentDirectory;
                string[] subs = localFileDir.Split(@"\bin");
                string fileDir = Path.Combine(subs[0], "longWords.txt");
                if (File.Exists(fileDir))
                {
                    File.Delete(fileDir);
                }
                using (FileStream fs = File.Create(fileDir))
                {
                    foreach (Match match in longWordCollection)
                    {
                        Console.WriteLine($"{match.Value} at position {match.Index}");
                        Byte[] word = new UTF8Encoding(true).GetBytes(match.Value + "\n");
                        fs.Write(word, 0, word.Length);
                    }
                }
            }
            catch(Exception ex) {
                Console.WriteLine(ex.ToString());

            }


        }
    }
}
