public static class StringSorter
{
    const string ALPHABET = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    public static string SortString(string stringToSort)
    {
        string[] words = stringToSort.Split(',');
        int longestWordLength = GetLengthOfLongestWord(words);

        words = FillShortWords(words, longestWordLength);
        words = SortWords(words, longestWordLength);
        words = RemoveFillerFromWords(words);

        string output = FormatString(words);
        return output;
    }
    static void Debug(string[] words)
    {
        foreach(string word in words)
        {
            Console.WriteLine(word);
        }
        Console.ReadKey();
    }
    public static int GetLengthOfLongestWord(string[] words)
    {
        int longestWordLength = 0;
        foreach(string word in words)
        {
            if(word.Length > longestWordLength)
            {
                longestWordLength = word.Length;
            }
        }
        return longestWordLength;
    }
    
    public static string[] FillShortWords(string[] words, int longestWordLength)
    {
        string[] filledWords = new string[words.Length];
        for(int w = 0; w < words.Length; w++)
        {
            while(words[w].Length < longestWordLength)
            {
                words[w] += ",";
            }
            filledWords[w] = words[w];
        }
        return filledWords;
    }

    public static string[] SortWords(string[] words, int longestWordLength)
    {
        string[] sortedWords = words;
        
        for(int letterIndex = longestWordLength-1; letterIndex >= 0; letterIndex--)
        {
            sortedWords = SortBySelectLetter(sortedWords, letterIndex);
        }
        return sortedWords;
    }

    public static string[] SortBySelectLetter(string[] words, int letterIndex)
    {
        string[] sortedWords = new string[words.Length];
        int sortedCount = 0;
        for(int w = 0; w < words.Length; w++)
        {
            if(words[w][letterIndex] == ',')
            {
                sortedWords[sortedCount] = words[w];
                sortedCount++;
            }    
        }
        
        foreach(char letter in ALPHABET)
        {
            for(int w = 0; w < words.Length; w++)
            {
                    if(words[w].ToUpper()[letterIndex] == letter)
                    {
                        sortedWords[sortedCount] = words[w];
                        sortedCount++;
                    }
            }
            if(sortedCount == words.Length)
            {
                break;
            }
        }
        return sortedWords;
    }

    public static string[] RemoveFillerFromWords(string[] words)
    {
        string[] wordsWithoutFiller = new string[words.Length];
        for (int w = 0; w < words.Length; w++)
        {
            wordsWithoutFiller[w] = words[w].Replace(",", "");
        }
        return wordsWithoutFiller;
    }

    public static string FormatString(string[] words)
    {
        string output = "";
        for(int w = 0; w < words.Length; w++)
        {
            output = output + words[w] + ",";
        }
        output = output.Substring(0,output.Length-1);
        return output;
    }
}