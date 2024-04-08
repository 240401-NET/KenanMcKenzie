﻿namespace typeTest;

class Program
{
    static async Task Main(string[] args)
    {
        using HttpClient client = new HttpClient();
        var api = new Api(client);
        await api.GetText();
        Console.Clear();
        Menu.PrintHeader();
        while (true)
        {
            Logic.HandleMenuCmdInput();
        }
    }

}
