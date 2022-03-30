using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace Assignment
{
    class Report
    {
        public static bool option2 = false;
        /// <summary>
        /// Outputs the analysis results to the console in the form of a table.
        /// </summary>
        /// <returns>
        /// void.
        /// </returns>
        public void outputConsole(List<int> analysis) {
            // List of each analysis title
            List<string> analysisTypes = new()
            {
                "Characters",
                "Sentences",
                "Vowels",
                "Consonants",
                "Upper Case",
                "Lower Case"
            };
            // Creates an array to hold the length of the longest title and value
            int[] keyValueLength = { 0, 0 };
            for (int width = 0; width < analysis.Count; width++) {
                // Determines the longest title
                if (analysisTypes[width].Length > keyValueLength[0]) { 
                    keyValueLength[0] = analysisTypes[width].Length;
                }
                // Determines the longest value
                string value = analysis[width].ToString();
                if (value.Length > keyValueLength[1]) { 
                    keyValueLength[1] = value.Length;
                }
            }
            // Creates a string of 'bars' long enough to account for the longest title and value
            string headerBars = new string('─', (keyValueLength[0] + keyValueLength[1]));
            // Writes the header, using the appropriate amount of bars on either side of the title.
            Console.WriteLine($"┌{headerBars[..((headerBars.Length / 2) - 2)]} Analysis {headerBars[((headerBars.Length / 2) + 3)..]}┐");

            // For each value of analyis
            for (int i = 0; i < analysis.Count; i++) {
                // Determines the amount of spaces needed for this title
                string titleSpaces = new string(' ', keyValueLength[0] - analysisTypes[i].Length);
                // Determines the amount of spaces needed for this value
                string occurenceSpaces = new string(' ', keyValueLength[1] - analysis[i].ToString().Length);
                // Writes a row of the table, centering the values in the space using the determined amount of spaces needed.
                Console.WriteLine($"│ {titleSpaces[..(titleSpaces.Length /2)]}{analysisTypes.ElementAt(i)}{titleSpaces[(titleSpaces.Length / 2)..]} │ {occurenceSpaces[..(occurenceSpaces.Length / 2)]}{analysis.ElementAt(i)}{occurenceSpaces[(occurenceSpaces.Length / 2)..]} │");

            }
            // Writes the footer, using the appropriate amount of bars.
            //Console.WriteLine($"└{headerBars[..(keyValueLength[0] + 2)]}┴{headerBars[(keyValueLength[0] - 2)..]}┘");
        }
        /// <summary>
        /// Outputs the character frequencies to the console in the form of a table.
        /// </summary>
        /// <returns>
        /// void.
        /// </returns>
        public void outputFrequencies(IDictionary<char, int> frequencies) {
            // Writes the header, and column titles.
            Console.WriteLine("┌─── Frequencies ───┐");
            Console.WriteLine("│ Char │ Occurences │");
            Console.WriteLine("├──────┼────────────┤");
            // Sorts the frequencies dictionary into descending order based on each key's value
            // Then iterates over each keyvalue pair in the dictionary
            foreach (KeyValuePair<char, int> kvp in frequencies.OrderByDescending(key => key.Value))
            {
                string value = kvp.Value.ToString();
                // Determines the amount of spaces needed for the value
                string occurenceSpaces = new string(' ', 10 - value.Length);
                // Writes a row of the table, centering the value using the determined spaces.
                Console.WriteLine($"│  {kvp.Key}   │ {occurenceSpaces[..(occurenceSpaces.Length / 2)]}{kvp.Value}{occurenceSpaces[(occurenceSpaces.Length / 2)..]} │");
            }
            // Writes the footer
            Console.WriteLine("└──────┴────────────┘");
        }
        /// <summary>
        /// Writes the collection of long words to a text file.
        /// </summary>
        /// <returns>
        /// void.
        /// </returns>
        public void WriteFile(MatchCollection longWordCollection)
        {
            if (option2 == true)
            {
                try
                {
                    // Gets a parses the current working directory.
                    string localFileDir = Environment.CurrentDirectory;
                    string[] subs = localFileDir.Split(@"\bin");
                    string fileDir = Path.Combine(subs[0], "longWords.txt");


                    // Creates a new file and opens it:
                    using (FileStream fs = File.Create(fileDir))
                    {
                        foreach (Match match in longWordCollection)
                        {
                            // For each word, parse it into bytes, and then write it to the file.
                            Byte[] word = new UTF8Encoding(true).GetBytes(match.Value + "\n");
                            fs.Write(word, 0, word.Length);
                        }
                    }
                }
                catch (IOException ex)
                {
                    Console.WriteLine($"Error occured during IO stream: \n {ex}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());

                }
            }


        }

    }
}
