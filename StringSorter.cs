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
    /*
    public static Stack<Word> SplitString(string stringToSort)
    {
        Stack<Word> output = new();
        int characterCounter = 0;
        int previousSubstring = 0;
        foreach(char character in stringToSort)
        {
            if(character == ',')
            {
                string subString = stringToSort.Substring(previousSubstring, characterCounter);
                previousSubstring = characterCounter; //Check obo on this
                subString = subString.Replace(",", "");
                Word word = new(subString);
            }
            characterCounter++;
        }

        return output;
    }
    */
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

/*
public class Word
{
    public Word(string subString)
    {
        SubStringWord = subString;
    }
    string SubStringWord {get;set;}
}
*/

        /*int currentFirstCharIndex = 25;
        foreach(string word in words)
        {
            if(output == "")
            {
                output = word;
            }
            else if(word.ToUpper()[0] == output.ToUpper()[0])
            {
                for(int charIndex = 1; charIndex < word.Length; charIndex++)
                {
                    if(word[charIndex] == output[charIndex])
                    {

                    }
                }
            }
            else if(ALPHABET[..currentFirstCharIndex].Contains(word.ToUpper()[0]))
            {
                output = word + "," + output;
            }
            else
            {
                output = word +
            }
            
        }
        */