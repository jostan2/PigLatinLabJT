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
                    string vowels = "aeiou";
                    //string consonants = "bcdfghjklmnpqrstvwxyz";
                    var piglatin = ""; //output after translation

                    foreach (var word in englishIn.Split()) //foreach loop to look at the user input (engword) and run each variable through it. Also .Split() separates the sentence 'engword' into individual words  by whitespace to be inspected.
                    {
                        var firstLetter = word.Substring(0, 1);
                        var restOfWord = word.Substring(1, word.Length - 1);
                        var currentLetter = vowels.IndexOf(firstLetter);
                        //var currentLetter2 = consonants.IndexOf(firstLetter);

                        if (currentLetter == -1)
                        {
                            piglatin += restOfWord + firstLetter + "-ay ";
                        }
                        //else if (currentLetter2 == -1)
                        //{
                        //    piglatin += restOfWord + firstLetter + "ay";
                        //}
                        else
                        {
                            piglatin += word + "-way ";
                        }
                    }
                    Console.WriteLine(piglatin);
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