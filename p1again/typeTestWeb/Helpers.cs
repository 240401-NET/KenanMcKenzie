namespace typeTestWeb;

public class Helpers
{
  public double CalculateWPM(double minutes, int correct, int incorrect)
  {
    int totalWords = GetTotal(correct, incorrect);
    double WPM = Math.Round(totalWords / 5 / minutes);
    return WPM;
  }
  public int GetTotal(int correct, int incorrect)
  {
    return correct + incorrect;
  }
  public double CalculateAccuracy(int correct, int incorrect)
  {
    int total = GetTotal(correct, incorrect);
    double ratio = (double)correct / total;
    return Math.Round(ratio, 2);
  }
  public double CalculateAWPM(double minutes, int correct, int incorrect)
  {
    double adjustedWPM = Math.Round(CalculateAccuracy(correct, incorrect) * CalculateWPM(minutes, correct, incorrect));
    return adjustedWPM;
  }
}