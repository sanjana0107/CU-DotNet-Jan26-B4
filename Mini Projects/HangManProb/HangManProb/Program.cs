using System.Threading.Channels;

namespace HangManProb
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = { "Bicycle", "Mango", "Antique", "Petal", "Echo" };

            Random random = new Random();
            int index = random.Next(words.Length);

            int lives = 6;
            List<char> guessedLetters = new List<char>();
            string guessedWord = words[index].ToUpper().Trim();
            
            char[] displayWord = new char[guessedWord.Length];


            for (int i = 0; i < displayWord.Length; i++)
            {
                displayWord[i] = '_';
            }


            while (lives > 0)
            {
                Console.WriteLine("Word: " + string.Join(" ", displayWord));
                Console.WriteLine("Guessed letters : " + string.Join(" ", guessedLetters));
                Console.WriteLine($"Lives left: {lives}");


                Console.Write("Enter a letter: ");
                string input = Console.ReadLine().ToUpper();

                if (input.Length == 1 && char.IsLetter(input[0]))
                {
                    char c = input[0];

                    if (guessedLetters.Contains(c))
                    {
                        Console.WriteLine("Already guessed!");
                        continue;
                    }
                    guessedLetters.Add(c);

                    bool correctGuess = false;

                    for(int i = 0; i < guessedWord.Length; i++)
                    {
                        if (guessedWord[i] == c)
                        {
                            displayWord[i] = c;
                            correctGuess = true;
                        }
                    }

                    if (!correctGuess)
                    {
                        lives--;
                        Console.WriteLine("wrong guess!");
                    }

                    if (!displayWord.Contains('_'))
                    {
                        Console.WriteLine("Correct word guessed! The word was :" + guessedWord);
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("Enter a valid letter.");
                }
            }
            Console.WriteLine("Zero lives. You lost! The word was "+ guessedWord);
        }
    }
}

