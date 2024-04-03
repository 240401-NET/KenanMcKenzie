using System.Timers;

namespace typeTest;

class Program
{
    static async Task Main(string[] args)
    {
        System.Diagnostics.Stopwatch myStopWatch = new System.Diagnostics.Stopwatch();

        // using HttpClient client = new HttpClient();
        // var api = new Api(client);
        // await api.GetText();
        myStopWatch.Start();
        Thread.Sleep(10000);
        myStopWatch.Stop();
        Console.WriteLine("Elapsed: " + myStopWatch.Elapsed.Seconds);

    }

}
