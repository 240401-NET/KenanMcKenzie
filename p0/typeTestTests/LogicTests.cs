namespace typeTestTests;

public class LogicTests
{
  [Theory]
  [InlineData(8, 2, 0.80)]
  [InlineData(0, 50, 0.0)]
  [InlineData(1, 100, 0.01)]
  public void Logic_CalculateAccuracy_ReturnsExpectedValue(int numCorrect, int numIncorrect, double expectedAccuracy)
  {
    //Arrange

    //Act
    var result = Logic.CalculateAccuracy(numCorrect, numIncorrect);
    //Assert
    Assert.Equal(expectedAccuracy, result);
  }

  [Fact]
  public void Logic_CalculateWPM_ReturnsDouble()
  {
    var result = Logic.CalculateWPM(1.55);
    Assert.Equal(typeof(double), result.GetType());
  }
  [Theory]
  [InlineData(0.00)]
  [InlineData(0.01)]
  [InlineData(1.5)]
  [InlineData(.8)]
  public void Logic_CalculateWPM_ReturnsNumber(double minutes)
  {
    var result = Logic.CalculateWPM(minutes);
    Assert.Equal(typeof(double), result.GetType());
  }
}
