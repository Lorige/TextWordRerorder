using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Тестовое_задание_на_Школу_Инженера_Digital_Design__2024_
{
    class TextInterface
    {

        public static void Start() =>
            Console.WriteLine("Введите путь к файлу или перенесите файл сюда: ");
        public static void End() =>
            Console.WriteLine("Завершение приложения");
        public static void OtherPartOfSpeachWriter()
        {
            Console.WriteLine($"Союзы: {BoolToString(SettingsWrite.Unions)}");
            Console.WriteLine($"Предлоги: {BoolToString(SettingsWrite.Preposition)}");
            Console.WriteLine($"Местоимения: {BoolToString(SettingsWrite.Pronoun)}");
            Console.WriteLine("выкл - не сохраняется, вкл - сохраняется");
        }

        private static string BoolToString(bool value)
        {
            if (value)
                return "выкл";
            else
                return "вкл";
        }

        public static void WritePathSucces(string path)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Файл создан: {path}");
            Console.ResetColor();
        }

        public static void WriteError(string ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ex);
            Console.ResetColor();
        }
    }
}
