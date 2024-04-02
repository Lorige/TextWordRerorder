namespace Extensions
{
    public static class StringExtension
    {
        public static string? RemoveAuxiliaryChars(this string? word)
        {
            if (word != null && word != "")
                if (!AuxiliaryCharacters(word[^1]))
                    return RemoveAuxiliaryChars(RemoveChar(word, word[^1]));
                else if (!AuxiliaryCharacters(word[0]))
                    return RemoveAuxiliaryChars(RemoveChar(word, word[0]));
            return word;
        }

        static string RemoveChar(string word, char axChar)
        {
            var withoutAxChar = word.Remove(word.IndexOf(axChar), 1);
            return withoutAxChar;
        }

        static bool AuxiliaryCharacters(char c)
        {
            return ('А' <= c & c <= 'я') || ('A' <= c & c <= 'Z') || ('a' <= c & c <= 'z') || 'Ё' == c || 'ё' == c;
        }
        public static bool IsNull(this string? word)
        {
            if (word == null || word == "") 
                return true;
            else
                return false;
        }
    }
}
