namespace PigLatinTranslater_v2_JT
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
                    string[] words = englishIn.Split(" ");

                    string[] pigWords = new string[words.Length];

                    for (int i = 0; i < words.Length; i++)
                    {
                        string word = words[i];
                        string pigWord = TranslateWord(word);
                        pigWords[i] = pigWord;
                    }

                    string pigSentence = ""; 

                    foreach (string s in pigWords)
                    {
                        pigSentence = pigSentence + s + " ";
                    }
                    pigSentence = pigSentence.Trim();

                    Console.WriteLine("Translated:");
                    Console.WriteLine(pigSentence);
                    Console.WriteLine();


                    bool askAgain = true;//while loop to repeat restart/exit prompt
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

        static string TranslateWord(string word) //method for determining when a word has a vowel/consonant, along with adding suffix and dealing with consonant blocks. (Ty Rone for your help on this)
        {
           string pigWord = word;
           char firstLetter = word[0];
           char lastChar = word[word.Length - 1];

           if (Char.IsPunctuation(lastChar))
           {
               word = word.Substring(0, word.Length - 1);
           }
           else if (IsAVowel(Char.ToLower(firstLetter))) // if the word starts with a vowel, just add "-way" to the end and call it done.
           {
               pigWord = word + "-way";
           }
           else
           {
               char[] wordChars = word.ToCharArray(); // Convert the word string into a char array

               for (int j = 0; j < wordChars.Length; j++)
               {
                   if (IsAVowel(Char.ToLower(wordChars[j]))) // if word does not start with vowel, move consonants and add "-ay" suffix
                   {
                       string sub1 = word.Substring(0, j) + "-ay";
                       string sub2 = word.Substring(j);

                       pigWord = sub2 + sub1;

                       break;
                   }
               }
           }
         return pigWord;
        }

            static bool checkVowel(char c)
            {
                return (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u');
            }

            static bool IsAVowel(char letter)
            {
                char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
                foreach (char c in vowels)
                {
                    if (letter.Equals(c))
                    {
                        return true;
                    }
                }
                return false;
            }

        
    }
}


//What are some of the c# string methods you used when doing the Capstone? 
//You can use string.split to take the whole sentence the user types in, and split them into individual components. I also used string.substring() to specify which index numbers of the string i wanted to use. For instance, looking at the second or third word of the sentence.  String.indexOf() was used to find if specific letters (the vowels in this case) occurred in each word. 