using Extensions;

namespace TextWordsRecord
{
    class ProgramStart
    {
        public ProgramStart() 
        {
            while(true)
            {
                new ImportTextFile(InputString());
            }
        }

        private string InputString()
        {
            string str;
            while (true)
            {
                TextInterface.Start();
                string? strEmpty = Console.ReadLine();
                if (strEmpty == "1")
                    SettingsSet();
                else if (strEmpty.RemoveAuxiliaryChars().IsNull())
                {
                    TextInterface.WriteError("Такого пути не существует");
                }
                else
                {
                    str = strEmpty;
                    return str;
                }
            }
        }

        private void SettingsSet()
        {
            var exit = false;
            while (!exit)
            {
                Console.Clear();
                TextInterface.OtherPartOfSpeachWriter();
                switch (Console.ReadKey(true).KeyChar)
                {
                    case '1':
                        SettingsWrite.Unions = !SettingsWrite.Unions;
                        break;
                    case '2':
                        SettingsWrite.Preposition = !SettingsWrite.Preposition;
                        break;
                    case '3':
                        SettingsWrite.Pronoun = !SettingsWrite.Pronoun;
                        break;
                    case '0':
                        exit = true;
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Неизвестная команда");
                        break;
                }
            }
        }
    }
}
