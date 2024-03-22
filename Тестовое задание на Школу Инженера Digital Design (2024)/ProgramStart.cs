
namespace TextWordsRecord
{
    class ProgramStart
    {
        internal string localPathResult;
        public ProgramStart() 
        {
            ImportTextFile importTextFile = new ImportTextFile(InputString());
            localPathResult = importTextFile.path;
        }

        private string InputString()
        {
            string str;
            while (true)
            {+----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                if (ReadKey())


                    continue;
                string? strEmpty = Console.ReadLine()
                                      .RemoveAuxiliaryChars();
                
                if (strEmpty.IsNull())
                    Console.WriteLine("Пустая строка");
                else
                {
                    str = strEmpty;
                    break;
                }
            }
            return str;
        }
        private bool ReadKey()
        {
            ConsoleKeyInfo cki;

            cki = Console.ReadKey(false);
            if (cki.Key == ConsoleKey.Escape)
                TextInterface.End();

            else if (cki.Key == ConsoleKey.D1)
                SettingsWrite.Unions = !SettingsWrite.Unions;
        }
    }
}
