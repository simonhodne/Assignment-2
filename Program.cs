﻿using HTTPUtils;
using System.Text.Json;
using AnsiTools;
using Colors = AnsiTools.ANSICodes.Colors;
using Deserialize;

/*class Program
{
    const string TEST_ARG = "-t";
    const string STRINGSORTER = "StringSorter";
    static string testType = "";
    static bool detailsToConsole = false;
    static void Main(string[] args)
    {
        if(args.Length >= 1)
        {
            if(args[0] == TEST_ARG)
            {
                ProcessArgs(args);
                Tests.RunTests(testType, detailsToConsole);
            }
            else
            {
                Run();
            }
        }
        else
        {
            Run();
        }
    }

    static void ProcessArgs(string[] args)
    {
        if(args.Length == 3)
        {
            if(args[2] == "true")
            {
                detailsToConsole = true;
            }
            else
            {
                detailsToConsole = false;
            }
        }

        if(args.Length > 1)
        {
            if(args[1] == STRINGSORTER)
            {
                testType = STRINGSORTER;
            }
        }
    }
*/
    //static async void Run()
    //{
        Console.Clear();
        Console.WriteLine("Starting Assignment 2");

        // SETUP 
        const string myPersonalID = "b3b323af01cc8000db9688fac0005010ad30b396cea4c7de66d8efdc49e5b2c6"; 
        const string baseURL = "https://mm-203-module-2-server.onrender.com/";
        const string startEndpoint = "start/"; // baseURl + startEndpoint + myPersonalID
        const string taskEndpoint = "task/";   // baseURl + taskEndpoint + myPersonalID + "/" + taskID

        // Creating a variable for the HttpUtils so that we dont have to type HttpUtils.instance every time we want to use it
        HttpUtils httpUtils = HttpUtils.instance;
        HttpClient client = new();

        //#### REGISTRATION
        // We start by registering and getting the first task
        Response startRespons = await httpUtils.Get(baseURL + startEndpoint + myPersonalID);
        Console.WriteLine($"Start:\n{Colors.Magenta}{startRespons}{ANSICodes.Reset}\n\n"); // Print the response from the server to the console
        string task1ID = "otYK2"; // We get the taskID from the previous response and use it to get the task (look at the console output to find the taskID)

        //#### FIRST TASK 
        // Fetch the details of the task from the server.
        TaskInfo task1Info = await GetTaskDetails(client, task1ID);
        
       
        //#### FIRST TASK ANSWER
        string answer1 = StringSorter.StringSorter.SortString(task1Info.parameters);
        Response task1AnswerResponse = await SendAnswer(httpUtils, task1ID, answer1);
        Console.WriteLine(task1AnswerResponse);
        string task2ID = "psu31_4";
        
        
        //#### SECOND TASK
        TaskInfo task2Info = await GetTaskDetails(client, task2ID);

        //#### SECOND TASK ANSWER
        string answer2 = Sum(task2Info.parameters);
        Response task2AnswerResponse = await SendAnswer(httpUtils,task2ID,answer2);
        Console.WriteLine(task2AnswerResponse);
        string task3ID = "aAaa23";

        //#### THIRD TASK
        TaskInfo task3Info = await GetTaskDetails(client, task3ID);

        //#### THIRD TASK ANSWER
        string answer3 = FarenheitToCelcius(task3Info.parameters);
        Response task3AnswerResponse = await SendAnswer(httpUtils,task3ID,answer3);
        Console.WriteLine(task3AnswerResponse);
        string task4ID = "aLp96";

        //#### FOURTH TASK
        TaskInfo task4Info = await GetTaskDetails(client, task4ID);

        //#### FOURTH TASK ANSWER
        string answer4 = OddOrEven(task4Info.parameters);
        Response task4AnswerResponse = await SendAnswer(httpUtils, task4ID, answer4);
        Console.WriteLine(task4AnswerResponse);


        static async Task<Response> SendAnswer(HttpUtils http, string taskID, string answer)
        {
            Response taskAnswerResponse = await http.Post(baseURL + taskEndpoint + myPersonalID + "/" + taskID, answer);
            return taskAnswerResponse;
        }


        static async Task<TaskInfo> GetTaskDetails(HttpClient client, string taskID)
        {
            await using Stream stream =
                await client.GetStreamAsync(baseURL + taskEndpoint + myPersonalID + "/" + taskID);

            TaskInfo taskInfo = await JsonSerializer.DeserializeAsync<TaskInfo>(stream);
            stream.Close();
            Console.WriteLine($"TASK: {taskInfo.title}\n{taskInfo.description}\nParameters: {taskInfo.parameters}");
            return taskInfo;
        }

        static string Sum(string numberString)
        {
            string[] numbersToSum = numberString.Split(',');
            int sum = 0;
            foreach(string number in numbersToSum)
            {
                int n = int.Parse(number);
                sum+= n;
            }
            string output = sum.ToString();
            return output;
        }
        static string FarenheitToCelcius(string temperatureFH)
        {
            double inputTemp = double.Parse(temperatureFH);
            double outputTemp = (((inputTemp-32)*5)/9);
            string output = outputTemp.ToString("#.##");
            return output;
        }
        static string OddOrEven(string number)
        {
            int n = int.Parse(number);
            if(n % 2 == 1)
            {
                return "odd";
            }
            else
            {
                return "even";
            }
        }
 //   }
//}