#pragma warning disable CS8618
#pragma warning disable CS8625

using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;

namespace HTTPUtils
{
    class TaskDetails
    {
        public string taskID {get; set;}
        public string title {get; set;}
        public string description {get; set;}
        public string parameters {get; set;}
    }
    class Response
    {
        public Response(string response)
        {
            task = JsonSerializer.Deserialize<TaskDetails>(response);
        }
        public TaskDetails task {get; set;}
        public int statusCode { get; set; }
        public string url { get; set; }

        public override string ToString()
        {
            return $"Response ({statusCode})\n{url} \n{task}";
        }

    }

    class HttpUtils
    {

        private HttpClient httpClient = new HttpClient();


        private static HttpUtils _instance = null;

        public static HttpUtils instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new HttpUtils();
                }
                return _instance;
            }
        }

        private HttpUtils()
        {

        }


        public async Task<Response> Get(string url)
        {
            int statusCode = 0;
            String? response = null;
            try
            {
                response = await httpClient.GetStringAsync(url);
                statusCode = 200;
            }
            catch (HttpRequestException e)
            {
                statusCode = (int)(e.StatusCode ?? 0);
                Console.Error.WriteLine($"Error : {statusCode} ");
                Console.Error.WriteLine(e.Message);
            }

            return new Response(response) { statusCode = statusCode, url = url };

        }

        public async Task<Response> Post(string url, string content)
        {
            int statusCode = 0;
            String? respons = null;
            try
            {
                Answer answer = new Answer() { answer = content };
                var response = await httpClient.PostAsJsonAsync(url, answer);
                respons = await response.Content.ReadAsStringAsync();
                statusCode = (int)response.StatusCode;
            }
            catch (HttpRequestException e)
            {
                statusCode = (int)(e.StatusCode ?? 0);
                Console.Error.WriteLine($"Error : {statusCode} ");
                Console.Error.WriteLine(e.Message);
            }

            return new Response(respons) { statusCode = statusCode, url = url };
        }


    }

    class Answer
    {
        public string answer { get; set; }
    }

}