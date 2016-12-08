using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ru.lecha.curs
{
    class Program
    {
        static void Main(string[] args)
        {
            while (Console.ReadKey().Key != ConsoleKey.Escape) {
                Console.WriteLine(" 1) Введите на первой строке путь к файлу C:/Users/Public/TestFolder/WriteText.txt \n 2) На второй, 2 первых символа для поиска \n 3) Выход - Esc");
                var dictionary = new Regex(@"\W|\d")
                    .Replace(System.IO.File.ReadAllText(Console.ReadLine()), " ")
                    .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .ToLookup(s => (s.Length > 1) ? s.Substring(0, 2) : "--");
                Console.WriteLine(dictionary[Console.ReadLine()].Count());
               }
        }
    }
}
