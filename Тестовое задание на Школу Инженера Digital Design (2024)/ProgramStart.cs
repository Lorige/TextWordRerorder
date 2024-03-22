using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Тестовое_задание_на_Школу_Инженера_Digital_Design__2024_
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
            {
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
    }
}
