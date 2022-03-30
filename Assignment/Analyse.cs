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

        /// <summary>
        /// Analyses the given text, and records the required measurements.
        /// </summary>
        /// <returns>
        /// A list of measurements.
        /// </returns>
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
            for (int i = 0; i < 6; i++)
            {
                values.Add(0);
            }

            // DRY iterative implementation to find each measurement.

            // Holds all of the regex patterns needed as filters.
            string[] patterns = new string[] { @"(?![ ,.*]).", @"[.]\s{1}|[.*]+", @"([AEIOUaeiou]){1}", @"([bcdfghjklmnpqrstvwxyzBCDFGHJKLMNPQRSTVWXYZ]){1}", @"([ABCDEFGHIJKLMNOPQRSTUVWXYZ]){1}", @"([abcdefghijklmnopqrstuvwxyz]){1}" };
            int index = 0;

            foreach (string pattern in patterns) {
                // Create a new rgMatcher object, passing in the current pattern, and the text to analyse.
                rgMatcher rgObject = new rgMatcher(pattern, input);
                // Get the amount of matches, and store in values array.
                values[index] = rgObject.rgCount();
                // Increment to save in the next values array index.
                index++;
            }

            // Finds occurences of long words
            string longWords = @"\b\w{7,}\b";
            // Creates a one-time use regex object using the longWords pattern.
            Regex rgLongWords = new Regex(longWords);
            // Gets a matchCollection containing all occurences of longWords.
            MatchCollection matchLongWords = rgLongWords.Matches(input);

            // Create a new report object, and call the writeToFile method with the matchCollection.
            Report reportObj = new Report();
            reportObj.WriteFile(matchLongWords);

            // Return the measurements.
            return values;
        }
        /// <summary>
        /// Gets the frequency of individual characters in the given input.
        /// </summary
        /// <returns>
        /// IDictionary<character, frequency>
        /// </returns>
        public IDictionary<char, int> getFrequencies(string input) {
            // Creates a new rgMatcher object, passing in the required pattern and input parameter.
            rgMatcher rgFrequencies = new rgMatcher(@"([a-zA-Z1-9]){1}", input);
            // Calls the rgFrequency method, which finds each character's frequency.
            IDictionary<char, int> frequencies = rgFrequencies.rgFrequency();
            // Return the dictionary of frequencies.
            return frequencies;
        }
    
        
        
    }

    
}
