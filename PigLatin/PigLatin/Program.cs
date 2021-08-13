using System;

namespace PigLatin
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the IDIGIT Gibberish translator");
            Console.WriteLine("The following menu choices are available:");
            Console.WriteLine();
            while (true)
            {
                string selection = MenuSelector();

                if (selection == "1")
                {
                    Console.WriteLine();
                    Console.WriteLine("Enter your word or phrase to be translated into Gibberish:");
                    Console.WriteLine();
                    string toBeRead = Console.ReadLine();
                    Console.WriteLine(Gibberish(toBeRead));
                }
                else if (selection == "2")
                {
                    Console.Clear();
                }
                else if (selection == "3")
                {
                    break;
                }
            }
        }


        

        public static string MenuSelector()    
        {
            string selection = "";
            while (selection != "1" && selection != "2" && selection != "3")
            {
                Console.WriteLine();
                Console.WriteLine("1) Enter a word or phrase to be translated into Gibberish");
                Console.WriteLine("2) To clear the screen");
                Console.WriteLine("3) Exit the application");
                selection = Console.ReadLine();
            }
            return selection;
                


            Console.WriteLine();
            Console.WriteLine("Pressing \"0\" at any time will end the program.");
            Console.WriteLine("Enter your word or phrase to be translated into Gibberish:");
            Console.WriteLine();

        }

        /* TO BE FIXED -->  - main menu
         *                  
         */

        static string Gibberish(string toBeRead)
        {
            toBeRead.ToLower();
            string toBeWritten = "";
            Console.WriteLine();
            for (int i = 0; i < toBeRead.Length; i++)
            {

                if (i != toBeRead.Length - 1)
                {
                    if (((toBeRead.Substring(i, 1) == "e" && toBeRead.Substring(i + 1, 1) == " ") || (toBeRead.Substring(i, 1) == "e" && (toBeRead.Substring(i + 1, 1) == "s" || toBeRead.Substring(i + 1, 1) == "d"))))
                    {   //eliminates "idiga" showing up before silent "e" at the end of the word, or "-es" or "-ed"
                        toBeWritten += (toBeRead.Substring(i, 1));
                    }   //first line cycles through the string, looking for vowels,
                    else if ((toBeRead.Substring(i, 1) == "a" || toBeRead.Substring(i, 1) == "e" || toBeRead.Substring(i, 1) == "i" || toBeRead.Substring(i, 1) == "o" || toBeRead.Substring(i, 1) == "u")
                        //and if the letter after the vowel is a vowel
                        && (toBeRead.Substring(i + 1, 1) == "a" || toBeRead.Substring(i + 1, 1) == "e" || toBeRead.Substring(i + 1, 1) == "i" || toBeRead.Substring(i + 1, 1) == "o" || toBeRead.Substring(i + 1, 1) == "u"))
                    {   //writes "idig" + pair of vowels and continues the string
                        toBeWritten += ($"idig{toBeRead.Substring(i, 1)}");
                    }
                    else if ((toBeRead.Substring(i, 1) == "a" || toBeRead.Substring(i, 1) == "e" || toBeRead.Substring(i, 1) == "i" || toBeRead.Substring(i, 1) == "o" || toBeRead.Substring(i, 1) == "u")
                        //if the vowel is not the first letter in the string,
                        && (i != 0)
                        //looks for pairs of vowels again, and prevents inserting "idig" in front of the second vowel in pair
                        && (toBeRead.Substring(i - 1, 1) == "a" || toBeRead.Substring(i - 1, 1) == "e" || toBeRead.Substring(i - 1, 1) == "i" || toBeRead.Substring(i - 1, 1) == "o" || toBeRead.Substring(i - 1, 1) == "u"))
                    {   //writes the second vowel in a pair of vowels, and continues the string:
                        toBeWritten += (toBeRead.Substring(i, 1));
                    }
                    else if ((toBeRead.Substring(i, 1) == "a" || toBeRead.Substring(i, 1) == "e" || toBeRead.Substring(i, 1) == "i" || toBeRead.Substring(i, 1) == "o" || toBeRead.Substring(i, 1) == "u") && (i != toBeRead.Length - 1))
                    {   //if neither of the previous conditions are met, it is a lone vowel, and "idig" is written in front of it
                        toBeWritten += ($"idig{toBeRead.Substring(i, 1)}");
                    }   //otherwise it is a consonant, and is written as is:
                    else toBeWritten += (toBeRead.Substring(i, 1));
                }
                else toBeWritten += (toBeRead.Substring(i, 1));
            }
            return toBeWritten;
        }
    }
}

