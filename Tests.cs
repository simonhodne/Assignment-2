namespace Test
{
    using Tasksolver;
    using static AnsiTools.ANSICodes;

    class Tests
    {
        const string STRINGSORTER = "StringSorter";
        static public void RunTests()
        {
            RunStringSorterTests(false);
            RunTaskSolverTests(true);
        }

        static string sortStringTestInput1 = "K,C,b,f,o,A";
        static string sortStringTestOutput1 = "A,b,C,f,K,o";
        static string sortStringTestInput2 = "AC,PO,Ab,KI,Aa,JL,ad";
        static string sortStringTestOutput2 = "Aa,Ab,AC,ad,JL,KI,PO";
        static string sortStringTestInput3 = "tullball,tull,tullete,DOMIHODE,tulleBukk,Computer,tulle,you,just,activated,my,trap,card,tull";
        static string sortStringTestOutput3 = "activated,card,Computer,DOMIHODE,just,my,trap,tull,tullball,tulle,tulleBukk,tullete,you";
        static string sumTestInput = "1,9,2,8,3,7,4,6,5,5";
        static string sumTestOutput = "50";
        static string fToCTestInput = "13";
        static string fToCTestOutput = "-10.56";
        static string oddOrEvenOddTestInput = "123";
        static string oddOrEvenOddTestOutput = "odd";
        static string oddOrEvenEvenTestInput = "1234";
        static string oddOrEvenEvenTestOutput = "even";

        static void RunStringSorterTests(bool detailsToConsole)
        {
            Test<string>(sortStringTestOutput1, StringSorter.StringSorter.SortString(sortStringTestInput1), "SortString CHAR TEST", detailsToConsole);
            Test<string>(sortStringTestOutput2, StringSorter.StringSorter.SortString(sortStringTestInput2),"SortString TWO CHAR TEST", detailsToConsole);
            Test<string>(sortStringTestOutput3, StringSorter.StringSorter.SortString(sortStringTestInput3), "SortString FULL TEST", detailsToConsole);
        }
        static void RunTaskSolverTests(bool detailsToConsole)
        {
            Test<string>(sumTestOutput, TaskSolver.Sum(sumTestInput),"Sum TEST", detailsToConsole);
            Test<string>(fToCTestOutput, TaskSolver.FarenheitToCelcius(fToCTestInput), "FarenheitToCelcius TEST", detailsToConsole);
            Test<string>(oddOrEvenOddTestOutput, TaskSolver.OddOrEven(oddOrEvenOddTestInput), "OddOrEven ODD TEST", detailsToConsole);
            Test<string>(oddOrEvenEvenTestOutput, TaskSolver.OddOrEven(oddOrEvenEvenTestInput), "OddOrEven EVEN TEST", detailsToConsole);
        }
        
        static void Test<T>(T expected, T actual, string description, bool detailsToConsole)
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

            if(detailsToConsole)
            {
                Console.WriteLine("Expected: " + expected);
                Console.WriteLine("Actual: " + actual);
            }
        }
    }
}