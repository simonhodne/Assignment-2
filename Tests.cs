using static AnsiTools.ANSICodes;
class Tests
{
    static string inputString1 = "K,C,b,f,o,A";
    static string[] inputStringArray1 = new string[]{"K","C","b","f","o","A"};
    static string outputString1 = "A,b,C,f,K,o";
    static public void RunTests()
    {
        Test<string>(outputString1, StringSorter.SortWords(inputStringArray1), "SortWords CHAR TEST");
        Test<string>(outputString1, StringSorter.GetSortedString(inputString1), "GetSortedString CHAR TEST");
    }
    
    static void Test<T>(T expected, T actual, string description)
    {
        if(expected.Equals(actual))
        {
            Console.WriteLine(Colors.Green + description);
        }
        else
        {
            Console.WriteLine(Colors.Red + description);
        }
        Console.Write(Colors.White);
    }
}