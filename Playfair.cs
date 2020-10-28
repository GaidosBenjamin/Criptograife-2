using System;
using System.Linq;

namespace Criptografie_2
{
    class Playfair {
        private string alphabet = "ABCDEFGHIKLMNOPQRSTUVWXYZ";
        private char[,] keyMatrix = new char[5, 5];

        public string encryption(string text, string key) {
            createKey(key);
            text = modifyText(text);
            Console.WriteLine("Corrected: " + text);

            string result = "";
            for(int x = 0; x < text.Length - 1; x += 2) {

                int row1 = 0, row2 = 0, col1 = 0, col2 = 0;
                bool ok1 = false, ok2 = false;
                for(int i = 0; i < keyMatrix.GetLength(0); i++) {
                    for(int j = 0; j < keyMatrix.GetLength(1); j++) {
                        if(text[x] == keyMatrix[i, j]) {
                            row1 = i;
                            col1 = j;
                            ok1 = true;
                        }
                        if(text[x + 1] == keyMatrix[i, j]) {
                            row2 = i;
                            col2 = j;
                            ok2 = true;
                        }
                    }
                    if(ok1 && ok2) {
                        break;
                    }
                }
                result += compareEncryption(row1, row2, col1, col2);
            }

            return result;
        }

        public string decryption(string text, string key) {
            createKey(key);

            string result = "";
            for(int x = 0; x < text.Length - 1; x += 2) {
                int row1 = 0, row2 = 0, col1 = 0, col2 = 0;
                bool ok1 = false, ok2 = false;
                for(int i = 0; i < keyMatrix.GetLength(0); i++) {
                    for(int j = 0; j < keyMatrix.GetLength(1); j++) {
                        if(text[x] == keyMatrix[i, j]) {
                            row1 = i;
                            col1 = j;
                            ok1 = true;
                        }
                        if(text[x + 1] == keyMatrix[i, j]) {
                            row2 = i;
                            col2 = j;
                            ok2 = true;
                        }
                    }
                    if(ok1 && ok2) {
                        break;
                    }
                }
                result += compareDecryption(row1, row2, col1, col2);
            }

            return result;
        }

        private string compareEncryption(int row1, int row2, int col1, int col2) {
            string result = "";
            if(row1 == row2) {
                if(col1 == keyMatrix.GetLength(0) - 1)  {
                    result += keyMatrix[row1, 0].ToString() + keyMatrix[row2, col2 + 1].ToString();
                    return result;
                }
                if(col2 == keyMatrix.GetLength(0) - 1) {
                    result += keyMatrix[row1, col1 + 1].ToString() + keyMatrix[row2, 0].ToString();
                    return result;
                }
                result += keyMatrix[row1, col1 + 1].ToString() + keyMatrix[row2, col2 + 1].ToString();
                return result;
            }
            if(col1 == col2) {
                if(row1 == keyMatrix.GetLength(1) - 1)  {
                    result += keyMatrix[0, col1].ToString() + keyMatrix[row2 + 1, col2].ToString();
                    return result;
                }
                if(row2 == keyMatrix.GetLength(1) - 1) {
                    result += keyMatrix[row1 + 1, col1].ToString() + keyMatrix[0, col2].ToString();
                    return result;
                }
                result += keyMatrix[row1 + 1, col1].ToString() + keyMatrix[row2 + 1, col2].ToString();
                return result;
            }
            result += keyMatrix[row1, col2].ToString() + keyMatrix[row2, col1].ToString();
            return result;
        }

        private string compareDecryption(int row1, int row2, int col1, int col2) {
            string result = "";
            var length = keyMatrix.GetLength(0) - 1;
            if(row1 == row2) {
                if(col1 == 0)  {
                    result += keyMatrix[row1, length].ToString() + keyMatrix[row2, col2 -1].ToString();
                    return result;
                }
                if(col2 == 0) {
                    result += keyMatrix[row1, col1 - 1].ToString() + keyMatrix[row2, length].ToString();
                    return result;
                }
                result += keyMatrix[row1, col1 - 1].ToString() + keyMatrix[row2, col2 - 1].ToString();
                return result;
            }
            if(col1 == col2) {
                if(row1 == 0)  {
                    result += keyMatrix[length, col1].ToString() + keyMatrix[row2 - 1, col2].ToString();
                    return result;
                }
                if(row2 == 0) {
                    result += keyMatrix[row1 - 1, col1].ToString() + keyMatrix[length, col2].ToString();
                    return result;
                }
                result += keyMatrix[row1 - 1, col1].ToString() + keyMatrix[row2 - 1, col2].ToString();
                return result;
            }
            result += keyMatrix[row1, col2].ToString() + keyMatrix[row2, col1].ToString();
            return result;
        }

        private string modifyText(string text) {
            string result = "";
            text = text.Replace(" ", String.Empty);
            text = text.ToUpper();
            for(int i = 0; i < text.Length - 1; i++) {
                if(text[i] == text[i+1]) {
                    result += text[i] + "X";
                }
                else {
                    result += text[i];
                }
            }
            result += text[text.Length - 1];
            return result;
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