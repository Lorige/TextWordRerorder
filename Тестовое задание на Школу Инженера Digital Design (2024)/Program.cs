using System;
using System.IO;
using System.Windows.Input;
using Тестовое_задание_на_Школу_Инженера_Digital_Design__2024_;


internal class Program
{
    private static void Main(string[] args)
    {
        Console.Title = "TextWriter";
        TextInterface.OtherPartOfSpeachWriter();
        TextInterface.Start();
        while (true) 
        {
            ConsoleKeyInfo cki;
            _ = new ProgramStart();

            Console.WriteLine("Нажмите Escape для выхода или любую кнопку для продолжения работы программы/путь для файла");
            cki = Console.ReadKey(true);
            Console.OpenStandardOutput();
            if (cki.Key == ConsoleKey.Escape)
            {
                TextInterface.End();
                break;
            }
            else
            {
                //Console.Write(cki);
            }
        }

        bool keyIsDrive(char key)
        {
            foreach (var drive in DriveInfo.GetDrives())
                if (drive.Name[0] == key)
                    return true;
            return false;
        }
    }
}