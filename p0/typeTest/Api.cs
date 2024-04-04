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
    var url = "https://baconipsum.com/api/?type=meat-and-filler&sentences=50&format=text";
    try
    {
      var response = await httpClient.GetAsync(url);
      if (response.IsSuccessStatusCode)
      {
        var jsonResponse = await response.Content.ReadAsStringAsync();
        // Console.WriteLine("jsonRes: " + jsonResponse); //-> ["Sentence", "Sentence"...]
        if (jsonResponse != null)
        {
          //write to file (name, content)
          string quoteFileName = "quotes.txt";
          File.WriteAllText(quoteFileName, jsonResponse.ToString()); //read and separate in Logic
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