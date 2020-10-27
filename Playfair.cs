using System;
using System.Linq;

namespace Criptografie_2
{
    class Playfair {
        private string alphabet = "ABCDEFGHIKLMNOPQRSTUVWXYZ";
        private char[,] keyMatrix = new char[5, 5];

        public string encryption(string text, string key) {
            createKey(key);
            
            return null;
        }

        private void createKey(string key) {
            key = key.Replace("j", String.Empty);
            key = key.Replace(" ", String.Empty);
            key = key.ToUpper();
            key = new string(key.ToCharArray().Distinct().ToArray());

            createAlphabet(key); 

            createKeyMatrix();
        }

        private void createAlphabet(string key) {
            foreach(char ch in key) {
                alphabet = alphabet.Replace(ch.ToString(), String.Empty);
            }
            alphabet = key + alphabet;
        }

        private void createKeyMatrix() {
            int aux = 0;
            for(int i = 0; i < keyMatrix.GetLength(0); i++) {
                for(int j = 0; j < keyMatrix.GetLength(1); j++) {
                    keyMatrix[i, j] = alphabet[aux++];
                }
            }
        }

        public void print() {
            for(int i = 0; i < keyMatrix.GetLength(0); i++) {
                for(int j = 0; j < keyMatrix.GetLength(1); j++) {
                    Console.Write(keyMatrix[i,j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}