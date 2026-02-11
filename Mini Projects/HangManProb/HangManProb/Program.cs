namespace HangManProb
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = { "Bicycle", "Mango", "entique ", "Petal", "Echo" };
            int lives = 6;
            List<char> letters = new List<char>();
            Random random = new Random();
            int index = random.Next(words.Length);
            string guessedWord = words[index];
            Console.Write("Guessed Word: ");
            char[] guessedChar = new char[guessedWord.Length];
            for (int i = 0; i < guessedWord.Length; i++)
            {
                Console.Write("_ ");
            }

            Console.WriteLine();
            Console.WriteLine($"Lives left: {lives}");
            while ( lives > 0 )
            {
                Console.Write("Enter a letter: ");
                char c = char.Parse(Console.ReadLine().ToUpper());
                if (char.IsLetter(c))
                {
                    for (int i = 0; i < guessedWord.Length; i++)
                    {
                        if (guessedWord[i] == c)
                        {
                            guessedChar[i] = c;
                        }
                    }
                }
                else
                {
                    letters.Add(c);
                    Console.WriteLine($"Guessed Letters: {string.Join(',', letters).ToString()}");
                    lives--;
                    Console.WriteLine($"Lives left: {lives}");
                }

                }

                
            }
        }
    }

