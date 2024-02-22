﻿using HTTPUtils;
using AnsiTools;
using Colors = AnsiTools.ANSICodes.Colors;
using Tasksolver;

const bool RUN_TESTS = false;
const string myPersonalID = "b3b323af01cc8000db9688fac0005010ad30b396cea4c7de66d8efdc49e5b2c6"; 
const string baseURL = "https://mm-203-module-2-server.onrender.com/";
const string startEndpoint = "start/";
const string taskEndpoint = "task/"; 
const int NUMBER_OF_TASKS = 4;
int taskNumber = 1;
string answer;

if(RUN_TESTS)
{
    Test.Tests.RunTests();
}
else
{
    Console.Clear();
    Console.WriteLine(ProgramStrings.Start);

    HttpUtils httpUtils = HttpUtils.instance;
    Response taskResponse = await httpUtils.Get(baseURL + startEndpoint + myPersonalID);

    while(!(taskNumber > NUMBER_OF_TASKS))
    {
        if(taskResponse.statusCode == 200)
        {
            Console.WriteLine(ProgramStrings.TaskRecieved, taskNumber);
        }

        taskResponse = await GetTaskDetails(taskResponse, httpUtils);
        if(taskResponse.statusCode == 200)
        {
            Console.WriteLine(ProgramStrings.DetailsRecieved);
            Console.WriteLine(ANSICodes.Effects.Bold + taskResponse.task.title + ANSICodes.Reset);
            Console.WriteLine(Colors.Yellow + taskResponse.task.description + ANSICodes.Reset);
            Console.WriteLine(ProgramStrings.Parameters, taskResponse.task.parameters);
        }

        answer = TaskSolver.RunTaskSolver(taskNumber, taskResponse.task.parameters);
        Console.WriteLine(ProgramStrings.ProposedAnswer, answer);
        taskResponse = await PostAnswerAndRecieveNextTask(answer, taskResponse, httpUtils);
        if(taskResponse.task != null)
        {
            Console.WriteLine(ProgramStrings.AnswerAccepted);
        }
        else
        {
            break;
        }
        taskNumber++;
    }

    Console.Clear();
    if(taskNumber > NUMBER_OF_TASKS)
    {
        Console.WriteLine(Colors.Green + "All tasks complete!" + ANSICodes.Reset);
    }
    else
    {
        Console.WriteLine($"{Colors.Yellow}{taskNumber} task(s) were completed.{ANSICodes.Reset}");
    }
}

static async Task<Response> GetTaskDetails(Response taskResponse, HttpUtils httpUtils)
{
    taskResponse = await httpUtils.Get(baseURL + taskEndpoint + myPersonalID + "/" + taskResponse.task.taskID);
    return taskResponse;
}

static async Task<Response> PostAnswerAndRecieveNextTask(string answer, Response taskResponse, HttpUtils httpUtils)
{
    Response newTaskResponse = await httpUtils.Post(baseURL + taskEndpoint + myPersonalID + "/" + taskResponse.task.taskID, answer);
    return newTaskResponse;
}
static class ProgramStrings
{
    public static string Start = "Starting Assignment 2\n";
    public static string TaskRecieved = Colors.Green+"Task {0} recieved"+ANSICodes.Reset +"\n";
    public static string DetailsRecieved = "Task Details Recieved:";
    public static string Parameters = "Parameters: {0}";
    public static string ProposedAnswer = "Proposed Answer: {0}";
    public static string AnswerAccepted = Colors.Green+"Answer was accepted!"+ANSICodes.Reset;
    public static string AllTasksComplete = Colors.Green+"All tasks complete!"+ANSICodes.Reset;
    public static string SomeTasksComplete = Colors.Yellow+"{0} task(s) were completed."+ANSICodes.Reset;
}