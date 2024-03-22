using TextWordsRecord;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.Title = "TextWriter";
        TextInterface.OtherPartOfSpeachWriter();
        TextInterface.Start();
        _ = new ProgramStart();
                                            
        bool keyIsDrive(char key)
        {
            foreach (var drive in DriveInfo.GetDrives())
                if (drive.Name[0] == key)
                    return true;
            return false;
        }
    }
}