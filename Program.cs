using System;

namespace Criptografie_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string startupPath = System.IO.Directory.GetCurrentDirectory();
            var text = System.IO.File.ReadAllText(startupPath + "/input.txt");

            Console.Write("Key: ");
            var key = Console.ReadLine();

            Vigenere vigenere = new Vigenere();

            // var encryptedText = vigenere.encryption(text, key);
            // Console.WriteLine("Encrypted: " + encryptedText);
            // Console.WriteLine("Decrypted: " + vigenere.decryption(encryptedText, key));

            Playfair playfair = new Playfair();

            playfair.encryption("", key);
        }
    }
}
