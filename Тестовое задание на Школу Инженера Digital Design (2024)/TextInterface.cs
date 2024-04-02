
namespace TextWordsRecord
{
    class TextInterface
    {

        public static void Start() =>
            Console.WriteLine("Нажмите 1 для редактирования настроек\n" +
                "Введите путь к файлу или перенесите файл сюда: ");
        public static void End() =>
            Console.WriteLine("Завершение приложения");
        public static void OtherPartOfSpeachWriter()
        {
            Console.WriteLine($"1. Союзы: {BoolToString(SettingsWrite.Unions)}");
            Console.WriteLine($"2. Предлоги: {BoolToString(SettingsWrite.Preposition)}");
            Console.WriteLine($"3. Местоимения: {BoolToString(SettingsWrite.Pronoun)}");
            Console.WriteLine("выкл - не сохраняется, вкл - сохраняется");
            Console.WriteLine("Нажмите соответствующую цифру для изменения или 0 для выхода");
        }

        private static string BoolToString(bool value)
        {
            if (value)
                return "выкл";
            else
                return "вкл";
        }

        public static void WritePathSucces(string path)=>
            WriteWithColor(path, ConsoleColor.Green);


        public static void WriteError(string ex) =>
            WriteWithColor(ex, ConsoleColor.Red);

        private static void WriteWithColor(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
            Console.WriteLine("Нажмите любую клавишу для продолжения");
            Console.ReadKey(true);
            Console.Clear();
        }
    }
}
