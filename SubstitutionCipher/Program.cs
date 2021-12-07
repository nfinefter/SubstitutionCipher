using System;

namespace SubstitutionCipher
{
    class Program
    {
        static string Encrypt(string input, string key, string alphabet)
        {
            string encryptedMsg = "";

            for (int i = 0; i < input.Length; i++)
            {
                char current = input[i];
                int indexInAlphabet = IndexOf(alphabet, current);

                if(indexInAlphabet == -1)
                {
                    encryptedMsg += current;
                }
                else
                {
                    encryptedMsg += key[indexInAlphabet];
                }
            }

            return encryptedMsg;
        }


        static string Decrypt(string encrypted, string key, string alphabet)
        {
            string decrptedMsg = "";

            for (int i = 0; i < encrypted.Length; i++)
            {
                decrptedMsg += key[i];
            }

            return decrptedMsg;
        }

        static Random rand = new Random();


        static string MakeKey(string alphabet)
        {
            string key = "";

            for (int i = 0; i < alphabet.Length; i++)
            {
                char storedLetter = alphabet[rand.Next(0, alphabet.Length)];
                while (Contains(key, storedLetter))
                {
                    storedLetter = alphabet[rand.Next(0, alphabet.Length)];
                }
                key += storedLetter;

            }

            return key;
        }

        static bool Contains(string str, char c)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (c == str[i])
                {
                    return true;
                }
                
            }
            return false;
        }

        static int IndexOf(string str, char c)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (c == str[i])
                {
                    return i;
                }

            }
            return -1;
        }

        static void Main(string[] args)
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            string key = MakeKey(alphabet);
            string encrypt = Encrypt("asdkjasdisaujd", key, alphabet);
            Console.WriteLine(encrypt);
            Console.WriteLine(Decrypt(encrypt, key, alphabet));

        }
    }
}
