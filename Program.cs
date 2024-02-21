﻿using HTTPUtils;
using System.Text.Json;
using AnsiTools;
using Colors = AnsiTools.ANSICodes.Colors;

class Program
{
    static async void Main(string[] args)
    {
        if(args[0] == "-t")
        {
            Tests.RunTests();
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Starting Assignment 2");

            // SETUP 
            const string myPersonalID = "b3b323af01cc8000db9688fac0005010ad30b396cea4c7de66d8efdc49e5b2c6"; 
            const string baseURL = "https://mm-203-module-2-server.onrender.com/";
            const string startEndpoint = "start/"; // baseURl + startEndpoint + myPersonalID
            const string taskEndpoint = "task/";   // baseURl + taskEndpoint + myPersonalID + "/" + taskID

            // Creating a variable for the HttpUtils so that we dont have to type HttpUtils.instance every time we want to use it
            HttpUtils httpUtils = HttpUtils.instance;

            //#### REGISTRATION
            // We start by registering and getting the first task
            Response startRespons = await httpUtils.Get(baseURL + startEndpoint + myPersonalID);
            Console.WriteLine($"Start:\n{Colors.Magenta}{startRespons}{ANSICodes.Reset}\n\n"); // Print the response from the server to the console
            string taskID = "otYK2"; // We get the taskID from the previous response and use it to get the task (look at the console output to find the taskID)

            //#### FIRST TASK 
            // Fetch the details of the task from the server.
            Response task1Response = await httpUtils.Get(baseURL + taskEndpoint + myPersonalID + "/" + taskID); // Get the task from the server
            Console.WriteLine(task1Response);
        }
    }
}