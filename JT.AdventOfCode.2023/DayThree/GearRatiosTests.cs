namespace JT.AdventOfCode._2023.DayThree;

public class GearRatiosTests : InputReader
{
    [Fact]
    public void SampleOne_ReturnSymbols()
    {
        var input = InputByLine("DayThree", "sample-1.txt");
        Assert.Equal(4361, new GearRatios(input).Calculate());
    }
    
    [Fact]
    public void FullInput_PartOne_ReturnSymbols()
    {
        var input = InputByLine("DayThree");
        Assert.Equal(551094, new GearRatios(input).Calculate());
    }
    
    [Fact]
    public void FullInput_PartTwo_ReturnSymbols()
    {
        var input = InputByLine("DayThree", "sample-1.txt");
        Assert.Equal(551094, new GearRatios(input).CalculateGears());
    }
}