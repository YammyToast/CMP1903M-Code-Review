using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Assignment
{
    public class rgMatcher
    {
        // Encapsulated variables.
        private string _pattern;
        private string _input;
        public rgMatcher(string pattern, string input)
        {
            _pattern = pattern;
            _input = input;

        }
        /// <summary>
        /// Passes object input value through the object pattern.
        /// </summary>
        /// <returns>
        /// <int>: Number of matches found.
        /// </returns>
        public int rgCount()
        {
            // Creates a new regex object using the private pattern.
            Regex regex = new Regex(_pattern);
            // Creates a matchCollection of all occurences from the filter.
            MatchCollection regexCollection = regex.Matches(_input);
            // Return the amount of occurences.
            return regexCollection.Count;
        }


        /// <summary>
        /// Finds frequency of each letter included in the input value using the pattern as an object.
        /// </summary>
        /// <returns>
        /// Dictionary<character (char), count (int)>
        /// </returns>
        public IDictionary<char, int> rgFrequency()
        {
            // Creates a new regex object to function as a filter (given the pattern).
            Regex filter = new Regex(_pattern);
            // Creates a new dictionary object, with a character key, and integer value.
            IDictionary<char, int> frequencyDictionary = new Dictionary<char, int>();
            // Splits the input into an array of characters.
            char[] stringChars = _input.ToCharArray();
            // For each character in the split input:
            foreach (char c in stringChars)
            {
                // If the character passes through the filter:
                if (filter.IsMatch($"{c}") == true) {
                    // Check whether the character is already in the dictionary:
                    if (frequencyDictionary.ContainsKey(c))
                    {
                        // If already in dictionary, increment its count.
                        frequencyDictionary[c] += 1;
                    }
                    else
                    {
                        // If not already in dictionary, add it with a count of 1.
                        frequencyDictionary.Add(c, 1);
                    }
                }
                
            }
            // Return the dictionary of frequencies.
            return frequencyDictionary;
        }
    }
}
