using System;

namespace Criptografie_2
{
    class Jefferson {
        private string[] disk;

        public Jefferson() {
            string startupPath = System.IO.Directory.GetCurrentDirectory();
            disk = System.IO.File.ReadAllLines(startupPath + "/JeffersonDisksInput.txt");
        }

        public string encryption(string text, int[] sequence, int position) {
            string result = "";
            for(int i = 0; i < text.Length; i++) {
                
                var nr = sequence[i] - 1;
                for(int j = 0; j < disk[nr].Length; j++) {
                    if(disk[nr][j] == text[i]) {
                        if(j + position >= disk[nr].Length) {
                            result += disk[nr][(j + position) - disk[nr].Length];
                        }
                        else {
                            result += disk[nr][j + position];
                        }
                    }
                }
            }

            return result;
        }

        public string decryption(string text, int[] sequence, int position) {
            string result = "";
            for(int i = 0; i < text.Length; i++) {
                
                var nr = sequence[i] - 1;
                for(int j = 0; j < disk[nr].Length; j++) {
                    if(disk[nr][j] == text[i]) {
                        if(j - position < 0) {
                            result += disk[nr][(j + disk[nr].Length) - position];
                        }
                        else {
                            result += disk[nr][j - position];
                        }
                    }
                }
            }
            return result;
        }
    }
}