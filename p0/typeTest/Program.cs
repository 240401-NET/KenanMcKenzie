namespace typeTest;

class Program
{
    static async Task Main(string[] args)
    {
        ConsoleKeyInfo keyPressed = Console.ReadKey(true);
        do
        {
            using HttpClient client = new HttpClient();
            var api = new Api(client);
            await api.GetText();
            Console.Clear();
            Menu.PrintHeader();
            Logic.HandleMenuCmdInput();
        } while (keyPressed.Key != ConsoleKey.Escape);
    }

}
