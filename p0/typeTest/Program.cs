﻿namespace typeTest;

class Program
{
    static async Task Main(string[] args)
    {

        using HttpClient client = new HttpClient();
        var api = new Api(client);
        await api.GetText();
        Menu.PrintHeader();
        Console.ResetColor();
        Logic.Run();
        // Input.Type();
        // Logic.ReadNextChar();
        // KeyInfo.Start();
    }

}
