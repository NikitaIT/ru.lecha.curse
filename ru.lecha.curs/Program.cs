using System;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace ru.lecha.curs
{
    class Program
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static void Main(string[] args)
        {
            while (Console.ReadKey().Key != ConsoleKey.Escape) {
                Console.Clear();
                Console.WriteLine(" Введите путь к файлу, как C:/Users/Public/TestFolder/WriteText.txt");
                var p = Console.ReadLine()??"";
                if (!File.Exists(p)) continue;
                var dictionary = new Regex(@"\W|\d")
                .Replace(File.ReadAllText(p), " ")
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToLookup(s => (s.Length > 1) ? s.Substring(0, 2) : "--");
                do {
                    Console.WriteLine("\n---------------------------------------------------------------\n Введите 2 первых символа для поиска");
                    var findStr = Console.ReadLine();
                    Console.WriteLine("---------------------------------------------------------------\n Найдено: " + dictionary[findStr].Count()+" ");
                    dictionary[findStr].ToList().ForEach(s => Console.Write(s + " "));
                    Console.WriteLine("; Продолжить поиск - Y; Назад - Другая клавиша;"); 
                } while (Console.ReadKey().Key == ConsoleKey.Y);
                Console.WriteLine("---------------------------------------------------------------\n Выход - Esc; Читать новый файл - Другая клавиша; ");
            }
        }
    }
}
