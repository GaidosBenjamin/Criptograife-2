using System;
using System.Collections.Generic;

namespace Criptografie_2 
{
    class Vigenere {
        private readonly string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private Queue<char> alphabetQueue;
        private char[,] matrix; 

        public Vigenere() {
            this.alphabetQueue = new Queue<char>(new char[] {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L',
             'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'});
            this.matrix = new char[26,26];
            createMatrix();
        }

        public string encryption(string text, string key) {
            text = correctText(text);
            key = createKey(text.Length, key);
            // Console.WriteLine(text);
            // Console.WriteLine(key);
            string result = "";
            for(int i = 0; i < text.Length; i++) {
                result += matrix[alphabet.IndexOf(key[i]), alphabet.IndexOf(text[i])];
            }
            return result;
        }

        public string decryption(string text, string key) {
            key = createKey(text.Length, key);
            string result = "";
            for(int i = 0; i < text.Length; i++) {
                var row = alphabet.IndexOf(key[i]);
                for(int aux = 0; aux < alphabet.Length; aux++) {
                    if(matrix[row, aux] == text[i]) {
                        result += alphabet[aux];
                        break;
                    }
                }
            }
            return result;
        }

        private void createMatrix() {
            for(int i = 0; i < matrix.GetLength(0); i++) {
                var temp = alphabetQueue.ToArray();
                for(int j = 0; j < matrix.GetLength(1); j++) {
                    matrix[i,j] = temp[j];
                }
                alphabetQueue.Enqueue(alphabetQueue.Dequeue());
            }
        }

        private string correctText(string text) {
            text = text.Trim();
            text = text.Replace(" ", String.Empty);
            return text.ToUpper();
        }

        private string createKey(int textLength, string key) {
            key = key.Trim();
            key = key.Replace(" ", String.Empty);
            key = key.ToUpper();
            for(int i = 0; i < textLength / key.Length; i++) {
                key += key;
            }
            key += key.Substring(0, textLength % key.Length);
            return key;
        }

        public void print() {
            for(int i = 0; i < matrix.GetLength(0); i++) {
                for(int j = 0; j < matrix.GetLength(1); j++) {
                    Console.Write(matrix[i,j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}