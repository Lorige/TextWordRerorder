
namespace TextWordsRecord
{
    class ProgramStart
    {
        public ProgramStart() 
        {
           new ImportTextFile(InputString());
        }

        private string InputString()
        {
            string str;
            while (true)
            {
                string? strEmpty = Console.ReadLine()
                                      .RemoveAuxiliaryChars();
                
                if (strEmpty.IsNull())
                    Console.WriteLine("Пустая строка");
                else
                {
                    str = strEmpty;
                    return str;
                }
            }
        }
        private bool ReadKey()
        {
            ConsoleKeyInfo cki;

            cki = Console.ReadKey(false);
            if (cki.Key == ConsoleKey.Escape)
                TextInterface.End();

            else if (cki.Key == ConsoleKey.D1)
                SettingsWrite.Unions = !SettingsWrite.Unions;
            return false;
        }

    }
}
