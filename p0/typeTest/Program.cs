namespace typeTest;

class Program
{
    static async Task Main(string[] args)
    {

        using HttpClient client = new HttpClient();
        var api = new Api(client);
        await api.GetText();
        // myStopWatch.Start();
        // Thread.Sleep(10000);
        // Input.Type();
        // myStopWatch.Stop();
        // Console.WriteLine("Elapsed: " + myStopWatch.Elapsed.Seconds);
        Input.Type();
    }

}
