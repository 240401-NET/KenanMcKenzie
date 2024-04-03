using System.Text.Json;

namespace typeTest;

class Api
{
  //est connection
  private readonly HttpClient httpClient;
  public Api(HttpClient http)
  {
    httpClient = http;
  }
  //fetch quotes -> write to file
  public async Task GetText()
  {
    var url = "https://baconipsum.com/api/?paras=5&type=meat-and-filler";
    try
    {
      var response = await httpClient.GetAsync(url);
      Console.WriteLine("response: " + response);
      if (response.IsSuccessStatusCode)
      {
        var jsonResponse = await response.Content.ReadAsStringAsync();
        Console.WriteLine("jsonRes: " + jsonResponse); //-> ["Sentence", "Sentence"...]
        if (jsonResponse != null)
        {
          //write to file (name, content)
          string quoteFileName = "quotes.json";
          File.WriteAllText(quoteFileName, jsonResponse); //read and separate in Logic
        }
      }
      else
      {
        Console.WriteLine("Problem fetching quotes");
        return;
      }
    }
    catch (Exception ex)
    {
      Console.WriteLine("Error connecting to endpoint: " + ex.Message); //make custom exception classes
    }
  }
}