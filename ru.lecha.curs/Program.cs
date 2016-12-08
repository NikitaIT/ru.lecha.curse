using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace ru.lecha.curs
{
    class Program
    {
        static void Main(string[] args)
        {
            while (Console.ReadKey().Key != ConsoleKey.Escape) {
                Console.Clear();
                Console.WriteLine(" Введите путь к файлу, как C:/Users/Public/TestFolder/WriteText.txt");
                var p = Console.ReadLine()??"";
                Console.WriteLine("---------------------------------------------------------------\n Поиск - Y; Назад - Другая клавиша;");
                while (File.Exists(p)&&Console.ReadKey().Key == ConsoleKey.Y) {
                var dictionary = new Regex(@"\W|\d")
                    .Replace(File.ReadAllText(p), " ")
                    .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .ToLookup(s => (s.Length > 1) ? s.Substring(0, 2) : "--");
                Console.WriteLine("\n---------------------------------------------------------------\n Введите 2 первых символа для поиска");
                Console.WriteLine("---------------------------------------------------------------\n Найдено: " + dictionary[Console.ReadLine()].Count()+ "; Продолжить поиск - Y; Назад - Другая клавиша;");
                }
                Console.WriteLine("---------------------------------------------------------------\n Выход - Esc; Читать новый файл - Другая клавиша; ");
            }
        }
    }
}
