using System.Text;

namespace Day38Exercise
{
    internal class Program
    {
        public static string VowelShift(string input)
        {
            StringBuilder sb = new StringBuilder();
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
            string alpha = "bcdfghjklmnpqrstvwxyz";
            char[] consonant = alpha.ToCharArray();
           
            for (int i = 0; i < input.Length; i++)
            {
                bool found = false;
                for (int j = 0; j < vowels.Length; j++)
                {
                    if (input[i] == vowels[j])
                    {
                        int index = j;
                        if (index == vowels.Length - 1)
                            sb.Append(vowels[0]);
                        else
                            sb.Append(vowels[index + 1]);
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    for (int k = 0; k < consonant.Length; k++)
                    {
                        if (input[i] == consonant[k])
                        {
                            int index = k;
                            if (index == consonant.Length - 1)
                                sb.Append(consonant[0]);
                            else
                                sb.Append(consonant[index + 1]);
                            break;
                        }
                    }
                }
            }
            return sb.ToString();
        }

            static void Main(string[] args)
            {
                Console.Write("Enter a string : ");
                string input = Console.ReadLine();
            Console.WriteLine(VowelShift(input));

            }
        }
    }
