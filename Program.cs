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
            Console.WriteLine("7. Shortest and Longest Word");
            Console.WriteLine("8. Try me O_o");
            Console.WriteLine("9. Exit");
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
                    Long_Short();
                    return true;
                case "8":
                    tryMe();
                    return true;

                case "9":
                    return false;

                default:
                    return true;

            }
        }
        //----------------------------------------------------------------------------------//


        private static string PlayerInput()
        {
            Console.Write("Enter the string : ");
            return Console.ReadLine();
        }
        //----------------------------------------------------------------------------------//

        private static void Uppercase()
        {
            Console.Clear();
            Console.WriteLine("Uppercase");

            char[] charArray = PlayerInput().ToCharArray();
            string result = new string(charArray);
            result = result.ToUpper();
            DisplayResult(String.Concat(result));
        }
        //----------------------------------------------------------------------------------//

        private static void Reverse()
        {
            Console.Clear();
            Console.WriteLine("Reverse String");

            char[] charArray = PlayerInput().ToCharArray();
            //----------------------------------------------------------------------------------//

            //Method I for reverse | this method is how I was taught in highschool (sort of)
            //For loop that start from the last letter to the first letter
            //Our empty string reverse get's the letters and then we display it 😃

            string reverse = String.Empty;
            for (int i = charArray.Length - 1; i > -1; i--)
            {
                reverse += charArray[i];
            }
            DisplayResult(String.Concat(reverse));

            //----------------------------------------------------------------------------------

            //Method II for reverse | with my special assistant Google Search I found this method() to use it so the program it's shorter and maybe better

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

        //Method II, this one is pretty obvious
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

            while (left < right)
            {
                if (charArray[left] != charArray[right])
                {
                    ok = 0;
                }
                left++;
                right--;
            }


            DisplayPalindrom(String.Concat(ok));


            // if( Reverse(charArray) == charArray )
        }
        //----------------------------------------------------------------------------------//

        private static void Long_Short()
        {
            Console.Clear();
            Console.WriteLine("Longest and Shortest word");

            char[] charArray = PlayerInput().ToCharArray();
            string sentence = new string(charArray) + " "; // getting the input from the user and adding an extra space
            string word = string.Empty, shortest = string.Empty, longest = string.Empty;
            string[] words = new string[200]; //
            int length = 0;

            for (int i = 0; i < sentence.Length; i++)
            {
                // Spliting the string into words
                if (sentence[i] != ' ')
                {
                    word = word + sentence[i];
                }
                else
                {
                    // Addind the words into a array | Incrementing the length | Emptying the string word
                    words[length] = word;
                    length++;
                    word = string.Empty;
                }
            }
            // Initialize short and long as the first word
            shortest = longest = words[0];

            // A little check because I had an error I guess. I don't remember...
            if (words[0] == null)
            {
                Console.WriteLine(words[0]);
            }

            for (int j = 0; j < length; j++)
            {
                //If length of short is greater than any word present in the string  
                //Store value of word into small 
                if (shortest.Length > words[j].Length)
                    shortest = words[j];

                //If length of long is less than any word present in the string  
                //Store value of word into large  
                if (longest.Length < words[j].Length)
                    longest = words[j];
            }

            if (string.IsNullOrEmpty(shortest) || string.IsNullOrEmpty(longest))
            {
                Console.WriteLine("\nTry again using a word");
            }
            DisplayShort(String.Concat(shortest));
            DisplayLong(String.Concat(longest));
        }
        //----------------------------------------------------------------------------------//
        // This is a special string manipulation
        private static void tryMe()
        {
            Console.Clear();
            Console.WriteLine("Hello, this is a special option. Enjoy it :D");
            Console.WriteLine("Please enter the following string: hello Fortech");
            char[] charArray = PlayerInput().ToCharArray();
            string result = new string(charArray);
            result = result.ToUpper();

            string reverse = String.Empty;
            for (int i = result.Length - 1; i > -1; i--)
            {
                reverse += result[i];
            }
            string whitespace = string.Empty;
            for (int i = 0; i < reverse.Length; i++)
            {
                if (reverse[i] != ' ')
                    whitespace += reverse[i];
            }
            if (whitespace == "HCETROFOLLEH")
            {
                Console.WriteLine("\nThank you for this oportunity. Due to your tasks, I learned some basic knowledge about C#");
                Console.WriteLine("Have a beautiful day");
            }
            DisplaytryMe(String.Concat(whitespace));
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
        //----------------------------------------------------------------------------------//

        // Function to display the shortest and longest word in a string 
        private static void DisplayShort(string message)
        {
            Console.WriteLine($"\nThe shortest word in your string is: {message}");
        }
        private static void DisplayLong(string message)
        {
            Console.WriteLine($"\nThe longest word in your string is: {message}");
            Console.Write("\nPress Enter to return to Main Menu");
            Console.ReadLine();
        }

        //----------------------------------------------------------------------------------//

 
        // Function for displaying the result of a very special option selected
        private static void DisplaytryMe(string message)
        {
            Console.WriteLine("\nYour string suffered those changes: uppercase + reverse + removing the whitespace");
            Console.WriteLine($"\nYour modified string is: {message}");
            Console.Write("\nPress Enter to return to Main Menu");
            Console.ReadLine();
        }
    }
}