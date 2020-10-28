using System;

namespace Criptografie_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string startupPath = System.IO.Directory.GetCurrentDirectory();
            var text = System.IO.File.ReadAllText(startupPath + "/input.txt");

            // Console.Write("Key: ");
            // var key = Console.ReadLine();

            Vigenere vigenere = new Vigenere();

            // var encryptedText = vigenere.encryption(text, key);
            // Console.WriteLine("Encrypted: " + encryptedText);
            // Console.WriteLine("Decrypted: " + vigenere.decryption(encryptedText, key));

            Playfair playfair = new Playfair();

            // var encryptedText = playfair.encryption(text, key);
            // Console.WriteLine("Encrypted: " + encryptedText);
            // Console.WriteLine("Decrypted: " + playfair.decryption(encryptedText, key));

            Jefferson jefferson = new Jefferson();

            text = correctText(text);
            int[] key = createKey(text);
            Console.Write("Input position (1 - 26): ");
            var position = Int32.Parse(Console.ReadLine());

            var encryptedText = jefferson.encryption(text, key, position);
            Console.WriteLine("Encrypted: " + encryptedText);
            Console.WriteLine("Decrypted: " + jefferson.decryption(encryptedText, key, position));
        }

        private static int[] createKey(string text) {
            int[] result = new int[text.Length];
            for(int i = 0; i < text.Length; i++) {
                Console.Write("Input number of disk for char " + text[i] + " (1-10): ");
                var input = Console.ReadLine();
                result[i] = Int32.Parse(input);
            }
            return result;
        }

        private static string correctText(string text) {
            text = text.Replace(" ", String.Empty);
            return text.ToUpper();
        }
    }
}
