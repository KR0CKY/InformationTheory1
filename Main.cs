using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int num;
            string select;

            do
            {
                Console.WriteLine("Методы перестановок");
                Console.WriteLine("----------------------------------");
                Console.WriteLine("1: Метод железнодорожной изгороди ");
                Console.WriteLine("2: Столбцовый метод ");
                Console.WriteLine("3: Метод поворачивающейся решётки");
                Console.WriteLine("----------------------------------");
                Console.WriteLine("Метод подстановки ");
                Console.WriteLine("4: Шифр Цезаря");
                Console.WriteLine("----------------------------------");
                Console.WriteLine("0: Выйти");
                Console.WriteLine("----------------------------------");
                Console.Write("Введите номер: ");
                select = Console.ReadLine();

                if (!Int32.TryParse(select, out num)) continue;

                if (select == "0")
                {
                    Environment.Exit(0);
                }

                Console.WriteLine("Вы выбрали метод номер " + select);

                if (select == "1")
                {
                    RailFence.Encrypt();
                }

                if (select == "2")
                {
                    Сolumn.Encrypt();
                }

                if (select == "3")
                {
                    Grid90.Encrypt();
                }

                if (select == "4")
                {
                    Ceasar.Encrypt();
                }
            } while (true);
        }
    }
}