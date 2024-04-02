using Extensions;

namespace TextWordsRecord
{
    class TextWork
    {
        #region OtherSpeach
        string[] unionsArray = {"а", "и",  "абы","аж","ажно", "ай", "ак", "ака",
            "аки", "ако", "але", "али", "аль", "ан", "аще", "б", "благо", "благодаря", "бо", "буде", "будто",
            "будь", "ведь", "вдобавок",  "впрочем", "всё", "всё-таки", "вследствие", "г", "где", "где-то", "д", "да",
            "дабы", "даже", "тех", "докуда", "дотоле", "е", "егда", "едва", "еже", "ежели", "ежель",
            "если", "ещё", "еще", "ж", "же", "з", "зане", "занеже", "зато", "затем", "зачем", "значит", "и", "и/или", "или",
            "ибо", "из-за", "того", "что", "этого", "иль", "именно", "имже", "инако", "иначе", "инда", "ино",
            "итак", "кабы", "как", "бы", "не", "то", "как-то", "кабы", "каков", "какой", "ковда", "ковды", "когда",
            "когды", "коли", "коль", "который", "куда", "л", "ли", "либо", "лишь", "только", "ль", "н", "настолько",
            "нежели", "ни", "ниже", "нижли", "но", "обаче", "однако", "одначе", "отколь", "откуда", "откудова",
            "оттого", "отчего", "особенно", "п", "перед",  "тем", "поелику", "пока", "покамест", "покаместь", "покеда",
            "поколева", "поколику", "поколь", "покуль", "покуда", "пускай", "раз", "покуля", "понеже", "поскольку", "постольку", "пота",
            "потолику", "потому", "почём", "почем" , "почему", "правда", "преж", "прежде", "чем", "притом", "причём",
            "причем", "просто", "пускай", "пусть", "р", "равно", "раз", "разве", "ровно", "с", "чтобы", "сиречь",
            "сколько", "следовательно", "следственно", "словно", "столько", "т", "так", "также", "ти", "есть",
            "тож", "тоже", "х", "хоть", "хотя", "ч", "чи", "чтоб", "чуть", "ш", "штоб", "штобы", "я", "яко",
            "якобы", "уже", "был", "была", "этом", "быть", "были", "была", "будет", "мог", "могу", "нужно",
            "там", "эти", "вот", "эту", "этой", "это", "этих", "эта"
        };
        string[] preposition = { "без", "безо", "близ", "в", "во", "вне", "вместо", "для", "до", "за", "из", "изо",
            "из-за", "из-под", "к", "ко", "кроме", "между", "меж", "на", "над", "надо", "о", "об", "обо", "от", "ото",
            "перед", "передо", "пред", "предо", "по", "под", "подо", "при", "про", "ради", "c", "со", "сквозь", "среди",
            "у", "через", "чрез"
        };
        string[] pronous = { "я", "ты", "он", "она", "оно", "мы", "вы", "они", "себя", "мой", "твой", "ваш", "наш",
            "свой", "его", "ее", "их", "то", "это", "тот", "этот", "такой", "таков", "столько", "весь", "любой", "всякий",
            "каждый", "сам", "другой", "самый", "иной", "кто", "что", "какой", "каков", "чей", "сколько", "никто", "ничто",
            "некого", "нечего", "никакой", "ничей", "нисколько", "кто-то", "кое-кто", "кто-нибудь", "кто-либо", "что-то",
            "кое-что", "что-нибудь", "что-либо", "какой-то", "какой-либо", "какой-нибудь", "некто", "нечто", "некоторый",
            "некий", "мне", "ему", "ей", "вам", "вас", "меня",  "нему", "него", "ней", "нее", "свою", "вами", "ним",
            "нем", "все", "них", "нас", "им", "сама", "сами", "её"
        };

        #endregion OtherSpeach

        #region OtherBool

        bool Unions {
            get { return SettingsWrite.Unions; }
        }
        bool Preposition
        {
            get { return SettingsWrite.Preposition; }
        }
        bool Pronoun {
            get { return SettingsWrite.Pronoun; }
        }

        #endregion OtherBool

        #region Property
        string Text;
        DirectoryInfo Path;
        bool WriteSucces = false;
        string PathResult { get; set; }
        Dictionary<string, int> CountUniqueWords = new Dictionary<string, int>();

        #endregion Property

        #region act
        Action<string?> WriteUniqueWordAdd { get; set; }
        #endregion act

        public TextWork(string text, DirectoryInfo directory, out string path)
        {
            Text = text;
            Path = directory;
            WriteUniqueWordAdd = (word) =>
            {
                if (word != null && word != "" && word.Length != 1)
                {

                    word = word.ToLower();
                    if (CountUniqueWords.ContainsKey(word))
                        CountUniqueWords[word]++;
                    else
                        if (!AnotherPart(word))
                        CountUniqueWords.Add(word, 1);
                }
            };
            path = PathResult;
            Start();
        }

        void Start()
        {
            RecordUniqueWords(Text.Split('\n', ' ', '.', ';', ':', ',', '-'));
            WritingResultsToFile(SortByCondition());
            if (WriteSucces)
            TextInterface.WritePathSucces(PathResult);
        }

        void RecordUniqueWords(params string[] words)
        {
            foreach (var word in words)
                if (word != null && word != "")
                    WriteUniqueWordAdd(word.RemoveAuxiliaryChars());
        }


        Dictionary<string, int> SortByCondition()
        {
            Dictionary<string, int> SortedbyMaxUniqueWord = new Dictionary<string, int>();
            while (CountUniqueWords.Count != 0)
            {
                var uniqueWord = SelectingTheMaximumValue();
                CountUniqueWords.Remove(uniqueWord.Item1);
                SortedbyMaxUniqueWord.Add(uniqueWord.Item1, uniqueWord.Item2);
            };
            return SortedbyMaxUniqueWord;
        }

        Tuple<string, int> SelectingTheMaximumValue()
        {
            int maxValue = 0;
            string uniqueWord = "";
            foreach (var word in CountUniqueWords)
                if (word.Value > maxValue)
                {
                    uniqueWord = word.Key;
                    maxValue = word.Value;
                }
            return Tuple.Create(uniqueWord, maxValue);
        }

        void WritingResultsToFile(Dictionary<string, int> sortedWords)
        {
            foreach (var word in sortedWords)
            {
                try
                {
                    RecordTextFileResult(word.Key + $" {word.Value}");
                }
                catch (Exception ex)
                {
                    TextInterface.WriteError(ex.Message);
                    break;
                }
            }
        }

        bool AnotherPart(string word)
        {
            if (!Unions)
                if (CheckAnotherPartSpeech(word, unionsArray))
                    return true;

            if (!Preposition)
                if (CheckAnotherPartSpeech(word, preposition))
                    return true;

            if (!Pronoun)
                if (CheckAnotherPartSpeech(word, pronous))
                    return true;

            return false;
        }

        bool CheckAnotherPartSpeech(string word, string[] anotherPartSpeechArray)
        {
            foreach (var anotherPartSpeech in anotherPartSpeechArray)
                if (word == anotherPartSpeech)
                    return true;
            return false;
        }

        void RecordTextFileResult(string text)
        {
            try
            {
                using (var streamWriter = new StreamWriter(PathResult ?? ReturnFilePath(), true))
                {
                    WriteSucces = true;
                    streamWriter.WriteLine(text);
                }
            }
            catch (Exception ex)
            {
                WriteSucces = false;
                throw new Exception(ex.Message.ToString());
            }
        }

        string ReturnFilePath()
        {
            return PathResult = Path.FullName
                .Replace(Path.Extension, string.Format(" Words [{0:d2}]-", DateTime.Now.Hour) +
                string.Format("[{0:d2}]-", DateTime.Now.Minute) + string.Format("[{0:d2}]", DateTime.Now.Second) + ".txt");
        }

        
    }
}
