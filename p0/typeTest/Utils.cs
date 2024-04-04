namespace typeTest;

class Utils
{
  public static string[] CleanArr(string[] quoteArr)
  {
    string joined = String.Join(", ", quoteArr);
    string[] cleaned = joined.Split(".  ");
    return cleaned;
  }
}