namespace typeTest;

class Program
{
    static async Task Main(string[] args)
    {
        using HttpClient client = new HttpClient();

        Console.Clear();
        Menu.PrintHeader();
        while (true)
        {
            var api = new Api(client);
            await api.GetText();
            Logic.HandleMenuCmdInput();
        }
    }

}
