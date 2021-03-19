using System;
using System.Text;

namespace ConsoleApp1
{
    public static class Сolumn
    {
        public static void Encrypt()
        {
            Console.WriteLine("\nСтолбцовый метод: ");
            Console.WriteLine("\nВведите строку: ");
            string enctyptline = Console.ReadLine();
            Console.WriteLine("\nВведите ключ: ");
            String key = Console.ReadLine();
            if (key != null && enctyptline != null)
            {
                String upperCase =enctyptline.ToUpperInvariant();
                String upperKey = key.ToUpperInvariant();
                upperCase = upperCase.Replace(" ", "");

                String encryption = columnEncrypt(upperCase, upperKey);
                Console.WriteLine("Зашифрованный текст: " + encryption.Replace("*", ""));
                Console.WriteLine("Дешифрованный текст: " + columnDecrypt(encryption, upperKey));
            }
        }

        private static int[] GetEncryptKey(String key)
        {
            char c = (char)2000;
            int[] keyNumArr = new int[key.Length];

            StringBuilder _key = new StringBuilder(key);
            for (int i = 0; i < _key.Length; i++)
            {
                int min = i;
                for (int j = 0; j < _key.Length; j++)
                {
                    if (_key[j] != c)
                    {
                        min = j;
                        break;
                    }
                }

                for (int j = 0; j < _key.Length; j++)
                {
                    if ((int)_key[j] < (int)_key[min])
                    {
                        min = j;
                    }
                }

                keyNumArr[i] = min;
                _key[min] = c;
            }

            return keyNumArr;
        }

        private static int[] GetDecryptKey(String key)
        {
            int[] keyArray = new int[key.Length];
            StringBuilder _key = new StringBuilder(key);

            for (int i = 0; i < _key.Length; i++)
            {
                int min = 0;
                for (int j = 0; j < _key.Length; j++)
                {
                    if ((int)_key[i] > (int)_key[j])
                    {
                        min++;
                    }
                    else if (((int)_key[i] == (int)_key[j]) && (i > j))
                    {
                        min++;
                    }
                }

                keyArray[i] = min;
            }

            return keyArray;
        }

        private static String columnEncrypt(String text, String key)
        {
            int col = key.Length;
            int row = 0;
            String tempr = "";

            while (tempr.Length < text.Length)
            {
                tempr += key;
                row++;
            }

            var Matrix = new char[row, col];

            while (text.Length % col != 0)
            {
                text += '*';
            }

            int index = 0;
            int m = 0;
            while (index < text.Length)
            {
                int n = 0;
                while (n < col && index < text.Length)
                {
                    Matrix[m, n] = text[index];
                    n++;
                    index++;
                }

                m++;
            }

            String resultText = "";
            int[] keyNumArr = GetEncryptKey(key);
            for (int i = 0; i < keyNumArr.Length; i++)
            {
                int number = keyNumArr[i];
                for (int j = 0; j < row; j++) resultText += Matrix[j, number];
            }

            return resultText;
        }

        private static String columnDecrypt(String text, String key)
        {
            int col = key.Length;

            int[] keyNumArr = GetDecryptKey(key);

            int row = text.Length / col;
            var charMatrix = new char[row, col];
            int m = 0;
            int index = 0;
            while (index < text.Length)
            {
                int n = 0;
                while (n < text.Length / col)
                {
                    charMatrix[n, m] = text[index];
                    n++;
                    index++;
                }

                m++;
            }

            char[,] Matrix2 = new char[row, col];

            for (int i = 0; i < col; i++)
            {
                int number = keyNumArr[i];
                for (int j = 0; j < row; j++)
                {
                    Matrix2[j, i] = charMatrix[j, number];
                }
            }

            String result = "";
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    result += Matrix2[i, j];
                }
            }
            return result.Replace("*", "");
        }
    }
}
