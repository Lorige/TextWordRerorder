using DocumentFormat.OpenXml.Packaging;


namespace TextWordsRecord
{
    public class ImportTextFile
    {
        public string? path;
        Dictionary<string, Action<string>> FileExtenxionsAction;
        public ImportTextFile(string str)
        {
            FileExtenxionsAction = new Dictionary<string, Action<string>> { 
                { ".docx", TextFromFile_Docx },
                { ".txt", TextFromFile_Txt },
            };
            var extension = new FileInfo(str).Extension;
            if (IsPath(str) && Path.Exists(str))
            {
                if (IsTextFile(extension, str))
                    FileExtenxionsAction[extension](str);
                else
                    Console.WriteLine("Неизвестное расширение файла");
            }
            else
                TextInterface.WriteError("Ошибка в имени пути");
        }

        bool IsPath(string path)
        {
            var driveInfo = DriveInfo.GetDrives();
            foreach (var drive in driveInfo)
            {
                if (path.Contains(drive.Name))
                    return true;
            }
            return false; 
        }

        bool IsTextFile(string fileExtension, string path)
        {
            foreach (var extension in FileExtenxionsAction.Keys)
                if (extension == fileExtension) 
                    return true;
            return false;
        }

        void TextFromFile_Docx(string path)
        {
            try
            {
                var wordProcessingDocument = WordprocessingDocument.Open(path, true);
                new TextWork(wordProcessingDocument.MainDocumentPart?.Document.Body?.InnerText ?? "", new DirectoryInfo(path), out this.path);
            } catch (DirectoryNotFoundException ex)
            {
                TextInterface.WriteError($"Ошибка в имени пути или файл имеет слишком длинное имя >231 символа");
            } catch (Exception ex)
            {
                TextInterface.WriteError(ex.Message);
            }
        }

        void TextFromFile_Txt(string path)
        {
            using (var streamReader =  new StreamReader(path))
                new TextWork(streamReader.ReadToEnd(), new DirectoryInfo(path), out this.path);
        }
    }

}
