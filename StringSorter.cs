public static class StringSorter
{
    const string ALPHABET = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    public static string GetSortedString(string stringToSort)
    {
        string output = "";
        string[] words = stringToSort.Split(',');
        output = SortWords(words);
        return output;
    }

    public static string SortWords(string[] words)
    {
        string output = "";
        int wordCount = 0;
        foreach(char letter in ALPHABET)
        {
            foreach(string word in words)
            {
                if(word.ToUpper()[0] == letter)
                {
                    output = output + word + ",";
                    wordCount++;
                }
            }
            if(wordCount == words.Length)
            {
                break;
            }
        }
        output = output.Substring(0, output.Length-1);
        Console.WriteLine(output);
        return output;
    }

    static void TestAlphOrder()
    {
        
    }
}

