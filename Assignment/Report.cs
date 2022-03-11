using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    class Report
    {
        //Handles the reporting of the analysis
        //Maybe have different methods for different formats of output?
        //eg.   public void outputConsole(List<int>)
        public void outputConsole(List<int> analysis) {
            List<string> analysisTypes = new()
            {
                "Sentences",
                "Vowels",
                "Consonants",
                "Upper Case",
                "Lower Case"
            };
            Console.WriteLine("\n| Analysis of Sentences |");
            for(int i = 0; i < analysis.Count; i++) {
                Console.WriteLine($"[O]: {analysisTypes.ElementAt(i)} : {analysis.ElementAt(i)}");
            }
        }
    }
}
