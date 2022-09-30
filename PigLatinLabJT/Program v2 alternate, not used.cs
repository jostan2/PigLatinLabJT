namespace PigLatinLabJT
{
    internal class Program
    {
        static void Main()
        {
            bool Start = true; //Start of loop to restart program
            while (Start)
            {
                Console.WriteLine("Welcome to the English-Pig Latin Translator. Please type any word.");
                string englishIn = Console.ReadLine().ToLower(); //converts user input to all lower-case
                if (englishIn.Length < 2)
                {
                    Console.WriteLine("This word is not long enough, try again.");
                    Start = true;
                }
                else 
                {
                    string[] words = englishIn.Split(' ');

                    foreach(string words2 in words)
                    {
                        int vowelPosition = -1;
                        foreach (char letter in words2)
                        {
                            vowelPosition++;
                            if (letter == 'a' || letter == 'e' || letter == 'i' || letter == 'o' || letter == 'u');
                            {
                                break;
                            }
                        }

                        string vowelSuffix = "-way";
                        string ConstSuffix = "-ay";
                        string beforeLetter = "";
                        string afterLetter = "";

                        if (vowelPosition == 0)
                        {
                            vowelSuffix = words2 + vowelSuffix;
                                Console.WriteLine(vowelSuffix);
                        }
                        else
                        {
                            beforeLetter = words2.Substring(0, vowelPosition);
                            afterLetter = words2.Substring(vowelPosition);
                            string constword = afterLetter + beforeLetter + ConstSuffix;
                            Console.WriteLine(constword);
                        }
                    }          
                }

                bool askAgain = true;//Loop to repeat restart/exit prompt
                while (askAgain)
                {
                    Console.WriteLine("Do you want to translate another word? Y/N");
                    string input = Console.ReadLine().ToLower();

                    if (input == "y")
                    {
                        Start = true; //yes to restart program
                        askAgain = false; //no to ask to restart
                    }
                    else if (input == "n")
                    {
                        Start = false; //no to restart program
                        askAgain = false; //no to ask to restart
                    }
                    else //if user input is not "y" or "n"
                    {
                        Console.WriteLine("I'm sorry, I'm afraid I can't do that, invalid input. Please try again.");
                        askAgain = true;
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}


//process breakdown-
//split engsent into words
//shuffle vowels and consonants to their respective positions ***
//add the ending 'ay' or 'way'
//join words back into sentence