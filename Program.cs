//Hello, if you will try other methods that I presented down below, please do not forget to put some brackets for the fuction

using System;
using System.Globalization; // for Title Case
using System.Numerics;

namespace FortechTask
{
    class Program
    {
        static void Main(string[] args)
        {
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
            }
        }
        private static bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("This is the menu");
            Console.WriteLine("Choose one option :");
            Console.WriteLine("1. Uppercase");
            Console.WriteLine("2. Reverse");
            Console.WriteLine("3. Number of vowels");
            Console.WriteLine("4. Number of words");
            Console.WriteLine("5. Title case");
            Console.WriteLine("6. Palindrom");
            Console.WriteLine("7. Exit");
            Console.Write("\nSelect an option : ");

            switch (Console.ReadLine())
            {
                case "1":
                    Uppercase();
                    return true;

                case "2":
                    Reverse();
                    return true;

                case "3":
                    Vowels();
                    return true;

                case "4":
                    Words();
                    return true;

                case "5":
                    titleCase();
                    return true;
                
                case "6":
                    palindrom();
                    return true;

                case "7":
                    return false;

                default:
                    return true;

            }
        }


        private static string PlayerInput()
        {
            Console.Write("Enter the string : ");
            return Console.ReadLine();
        }

        private static void Uppercase()
        {
            Console.Clear();
            Console.WriteLine("Uppercase");

            char[] charArray = PlayerInput().ToCharArray();
            string result = new string(charArray);
            result = result.ToUpper();
            DisplayResult(String.Concat(result));
        }
        private static void Reverse()
        {
            Console.Clear();
            Console.WriteLine("Reverse String");

            char[] charArray = PlayerInput().ToCharArray();
            //----------------------------------------------------------------------------------//

            //Method I for reverse, this method is how I was taught in highschool (sort of)
            //For loop that start from the last letter to the first letter
            //Our empty string reverse get's the letters and then we display it 😃

            string reverse = String.Empty;
            for (int i = charArray.Length - 1; i > -1; i--)
            {
                reverse += charArray[i];
            }
            DisplayResult(String.Concat(reverse));

            //----------------------------------------------------------------------------------

            //Method II for reverse, with my special assistant Google Search I found this method() to use it so the program it's shorter and maybe better

            /*  
             
            Array.Reverse(charArray);
            DisplayResult(String.Concat(charArray));
            
             */

            //----------------------------------------------------------------------------------//
        }

        private static void Vowels()
        {
            Console.Clear();
            Console.WriteLine("Number of Vowels");
            int numVowels = 0;

            //char[] vowels = { 'a', 'e', 'i', 'o', 'u'};
            //----------------------------------------------------------------------------------//
            char[] charArray = PlayerInput().ToCharArray();

            var vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };

            for (int i = 0; i < charArray.Length; i++)
            {
                if (vowels.Contains(charArray[i]))   //there are more ways to do it but I liked this one because it's simplier. other one should check if(result[i] == vowels) kinda, or the one below (Method II)
                    numVowels++;
            }
            DisplayNumVowels(String.Concat(numVowels));

        }

        //----------------------------------------------------------------------------------//

        //Method II, this one is pretty obvious, the braindead method but efficent
        /*
        string lower = new string(charArray);
        lower = lower.ToLower();

        for (int i = 0; i < lower.Length; i++)
        {
            if (lower[i] == 'a' || lower[i] == 'e' || lower[i] == 'i' || lower[i] == 'o' || lower[i] == 'u')
            {
                numVowels++;
            }
        }
        DisplayNumVowels(String.Concat(numVowels));
    } 
        */
        //----------------------------------------------------------------------------------//


        private static void Words()
        {
            Console.Clear();
            Console.WriteLine("Number of words");

            char[] charArray = PlayerInput().ToCharArray();

            int letters = 0, words = 1;

            
            while (letters <= charArray.Length - 1) // repeats until the string ends
            {
                if (charArray[letters] == ' ' || charArray[letters] == '\n') // checks if the current character is a white space or a new line. press ctrl + z for a new line to enter
                {
                    words++; // counts a number
                }

                letters++; // increasing the variable so we will exit the loop
            }

            // a little check if there are any words in the string

            if (letters == 0 && words == 1)
            {
                words = 0;
                Console.WriteLine("\nTry again and insert a string\n");
            }

            DisplayNumWords(String.Concat(words));
        }
        //----------------------------------------------------------------------------------//

        // The method for titleCase, a little help from Google/StackOverFlow
        private static void titleCase()
        {
            Console.Clear();
            Console.WriteLine("Title Case");

            char[] charArray = PlayerInput().ToCharArray();
            string title = new string(charArray).ToLower();

            TextInfo textinfo = new CultureInfo("en-US", false).TextInfo;
            title = textinfo.ToTitleCase(title);
            DisplayResult(String.Concat(title));
        }

        //----------------------------------------------------------------------------------//
        private static void palindrom()
        {
            Console.Clear();
            Console.WriteLine("Palindrom");

            char[] charArray = PlayerInput().ToCharArray();
            int left = 0, right = charArray.Length - 1;
            int ok = 1;

            while(left < right)
            {
                if (charArray[left] != charArray[right])
                {
                    ok = 0;
                }
                left++;
                right--;
            }
            
            
            DisplayPalindrom(String.Concat(ok));
        
        
            //( Reverse(charArray) == charArray )
        }
        //----------------------------------------------------------------------------------//

        private static void Long_Short()
        {
            Console.Clear();
            Console.WriteLine("Longest and Shortest word");

            char[] charArray = PlayerInput().ToCharArray();
            string test = new string(charArray).ToLower() + " "; // lowering the string and adding a space to get the last word
            string word = string.Empty; // an 
            char[] words = new char[200]; //


            for (int i = 0; i < test.Length - 1; i++)
            {
                // splits the string into words
                if (test[i] != ' ')
                {
                    word = word + test[i];
                }
                // when space found, adds the word to a vector word
                else
                {
                    words = word.ToCharArray();
                    word = string.Empty;
                }
            }

            char long = new char(words[0]);
            char[] short = words[0];

            DisplayResult(String.Concat(long_SHort));
        }   
        //----------------------------------------------------------------------------------//
        // Function for displaying the result of the option selected
        private static void DisplayResult(string message)
        {
            Console.WriteLine($"\nYour modified string is: {message}");
            Console.Write("\nPress Enter to return to Main Menu");
            Console.ReadLine();
        }

        //----------------------------------------------------------------------------------//
        // Function for displaying the number of vowels
        private static void DisplayNumVowels(string message)
        {
            Console.WriteLine($"\nThe number of vowels is: {message}");
            Console.Write("\nPress Enter to return to Main Menu");
            Console.ReadLine();
        }

        //----------------------------------------------------------------------------------//
        // Function for displaying the number of words
        private static void DisplayNumWords(string message)
        {
            Console.WriteLine($"\nThe number of words is: {message}");
            Console.Write("\nPress Enter to return to Main Menu");
            Console.ReadLine();
        }

        //----------------------------------------------------------------------------------//

        // Function for checking if the string is palindrom or not
        private static void DisplayPalindrom(string message)
        {
            int check = Int32.Parse(message); // "Int32.Parse(input)"  ty Google :*
            // A simple check if the string is palindrom or not
            if (check == 1)
            {
                Console.WriteLine("\nIs palindrom");
            }
            else
            {
                Console.WriteLine("\nNot palindrom");
            }
            Console.Write("\nPress Enter to return to Main Menu");
            Console.ReadLine();
        }
    
    
    }
}