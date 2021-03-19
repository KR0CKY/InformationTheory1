using System;

namespace ConsoleApp1
{
    class Ceasar
    {
       //исполнительная часть
       public static void Encrypt()
        {
            Console.WriteLine("\nШифр цезаря");
            var cypher = new Ceasar();
            Console.Write("Введите строку: ");
            var encryptline = Console.ReadLine();
            Console.Write("Введите ключ шифрования: ");
            var Key = Convert.ToInt32(Console.ReadLine());
            var encryptedText = cypher.Encrypt(encryptline, Key);
            Console.WriteLine("Зашифрованный текст: {0}", encryptedText);
            Console.WriteLine("Дешифрованный текст: {0}", cypher.Decrypt(encryptedText, Key));
            Console.ReadLine();
        }
       

        //константная переменная содержащая алфавит
        const string alfabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        
        
        //метод, выполняющий кодирования согласно шифру Цезвря
        //для шифрования используется ключ, введённый пользователем
        //для дешифрования его отрицательное значение
        private string EncodingCode(string EncryptLine, int k)
        {
            //создание полного алфавита
            var Alfabet = alfabet + alfabet.ToLower();
            var letterQty = Alfabet.Length;
            var value = "";
            for (int i = 0; i < EncryptLine.Length; i++)
            
                //основной цикл кодирования
            {
                var letter = EncryptLine[i];
                var index = Alfabet.IndexOf(letter);
                if (index < 0)
                {
                    value += letter.ToString();
                }
                else
                {
                    var codeIndex = (letterQty + index + k) % letterQty;
                    value += Alfabet[codeIndex];
                }
            }

            return value;
        }

        public string Encrypt(string plainMessage, int key)
            => EncodingCode(plainMessage, key);

        public string Decrypt(string encryptedMessage, int key)
            =>EncodingCode(encryptedMessage, -key);
    }

    
}
