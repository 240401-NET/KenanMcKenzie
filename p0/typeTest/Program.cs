namespace typeTest;

class Program
{
    static async Task Main(string[] args)
    {

        Console.Clear();
        Menu.PrintHeader();
        while (true)
        {
            using HttpClient client = new HttpClient();
            var api = new Api(client);
            await api.GetText();
            Logic.HandleMenuCmdInput();
        }
    }

}
