using System;

namespace ConsoleApp1
{
    class RailFence
    {
      
        public static void Encrypt()
        {
            Console.WriteLine("\nМетод железнодорожной изгороди");
            Console.WriteLine("\nВведите строку: ");
            string line = Console.ReadLine(); ;
            Console.WriteLine("\nВведите ключ: ");
            var key = int.Parse(Console.ReadLine());

            string encryptline = Encrypting(line, key);
            Console.WriteLine("Зашифрованный текст: {0}", encryptline);

            Console.WriteLine("--------------------------------------------");

            string decryptline = Decrypting(encryptline, key);
            Console.WriteLine("Дешифрованный текст: {0}", decryptline);

            Console.ReadKey();
        }


        //метод создания матрицы
        private static char[][] GenerateMatrix(int rows, int cols)
        {
            char[][] matrix = new char[rows][];

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = new char[cols];
            }

            return matrix;
        }

        //метод преобразования матрицы в строку
        private static string FromMatrixToString(char[][] matrix)
        {
            string str = string.Empty;

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] != '\0')
                    {
                        str += matrix[row][col];
                    }
                }
            }
            return str;
        }

        //транспонирование матрицы
        private static char[][] Transpose(char[][] matrix)
        {
            char[][] result =
                GenerateMatrix(matrix[0].Length, matrix.Length);

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    result[col][row] = matrix[row][col];
                }
            }

            return result;
        }

        //метод шифрования
        private static string Encrypting(string clearText, int key)
        {
            string result = string.Empty;

            char[][] matrix = GenerateMatrix(key, clearText.Length);

            int rowIncrement = 1;
            for (int row = 0, col = 0; col < matrix[row].Length; col++)
            {
                if (
                    row + rowIncrement == matrix.Length ||
                    row + rowIncrement == -1
                    )
                {
                    rowIncrement *= -1;
                }

                matrix[row][col] = clearText[col];

                row += rowIncrement;
            }
            result = FromMatrixToString(matrix);
            return result;
        }

        //метод дешифрования
        private static string Decrypting(string cipherText, int key)
        {
            string result = string.Empty;
            char[][] matrix = GenerateMatrix(key, cipherText.Length);
            int rowIncrement = 1;
            int textIdx = 0;

            for (int selectedRow = 0; selectedRow < matrix.Length; selectedRow++)
            {
                for (
                    int row = 0, col = 0;
                    col < matrix[row].Length;
                    col++
                    )
                {
                    if (
                        row + rowIncrement == matrix.Length ||
                        row + rowIncrement == -1
                        )
                    {
                        rowIncrement *= -1;
                    }

                    if (row == selectedRow)
                    {
                        matrix[row][col] = cipherText[textIdx++];
                    }

                    row += rowIncrement;
                }
            }

            matrix = Transpose(matrix);
            result = FromMatrixToString(matrix);
            return result;
        }
    }
}