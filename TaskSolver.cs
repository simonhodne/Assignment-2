namespace Tasksolver
{
    using HTTPUtils;

    public static class TaskSolver
    {
        public static string RunTaskSolver(int taskNumber, string taskParameters)
        {
            string output = "";
            if(taskNumber == 1)
            {
                output = StringSorter.StringSorter.SortString(taskParameters);
            }
            else if(taskNumber == 2)
            {
                output = Sum(taskParameters);
            }
            else if(taskNumber == 3)
            {
                output = FarenheitToCelcius(taskParameters);
            }
            else if(taskNumber == 4)
            {
                output = OddOrEven(taskParameters);
            }

            return output;
        }

        public static string Sum(string numberString)
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

        public static string FarenheitToCelcius(string temperatureFH)
        {
            double inputTemp = double.Parse(temperatureFH);
            double outputTemp = (((inputTemp-32)*5)/9);
            string output = outputTemp.ToString("#.##");
            if(!output.Contains('.'))
            {
                output += ".00";
            }
            return output;
        }

        public static string OddOrEven(string number)
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
    }
}