//Base code project for CMP1903M Assessment 1
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assignment
{
    class Program
    {
        static void Main()
        {
            bool testResult = testAnalysis();
            if (testResult == false)
            {
                //Local list of integers to hold the first five measurements of the text
                List<int> parameters = new List<int>();

                //Create 'Input' object
                //Get either manually entered text, or text from a file
                Input textInput = new();
                string userInput = " ";
                string text = "";
                Console.Write("1. Do you want to enter text via the keyboard? \n2. Do you want to read in text from the file?");
                while (userInput != "1" && userInput != "2")
                {
                    Console.Write("\n : ");
                    userInput = Console.ReadLine();
                }
                if (userInput == "1")
                {
                    Console.WriteLine("\n [I] Input Sentences  (* to end)");
                    textInput.manualTextInput();
                }
                else
                {
                    // Switches the static attribute in the Report class to true.
                    Report.option2 = true;
                    Console.Write("\n [I] Input File Name  (ends in .txt)\n : ");
                    string fileName = Console.ReadLine();
                    textInput.fileTextInput(fileName);
                }
                text = textInput.fetchedText;
                //Create an 'Analyse' object
                //Pass the text input to the 'analyseText' method
                //Receive a list of integers back
                Analyse analyser = new();

                List<int> results = analyser.analyseText(text);
                IDictionary<char, int> frequencies = analyser.getFrequencies(text);




                //Report the results of the analysis
                Report reportConsole = new();
                reportConsole.outputConsole(results);

                //TO ADD: Get the frequency of individual letters?
                reportConsole.outputFrequencies(frequencies);



                Console.ReadKey();
            }
            else {
                Console.WriteLine("An error has occured within the program data, and therefore cannot read properly.");
                Console.ReadKey();
            }
        }

        public static bool testAnalysis() { 
            List<int> constParameters = new List<int>() { 506, 6, 189, 317, 9, 497 };

            string localFileDir = Environment.CurrentDirectory;
            string[] subs = localFileDir.Split(@"\bin");
            string fileDir = Path.Combine(subs[0], "readfile.txt");
            string text = File.ReadAllText(fileDir);
            
            Analyse testAnalyse = new();
            List<int> testResults = testAnalyse.analyseText(text);

            bool error = false;
            for (int index = 0; index < testResults.Count; index++) {
                if (testResults[index] != constParameters[index]) {
                    Console.WriteLine($"{testResults[index]}, {constParameters[index]}");
                    error = true;
                    break;
                }
            }
            return error;
        }
        
        
    
    }
}
