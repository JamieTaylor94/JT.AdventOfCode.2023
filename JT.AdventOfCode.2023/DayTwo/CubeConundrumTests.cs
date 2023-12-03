namespace JT.AdventOfCode._2023.DayTwo;

public class CubeConundrumTests
{
    private static readonly string FilePath = $"{Directory.GetCurrentDirectory()}/DayTwo/Resources";
    private readonly string[] _dayTwoGameInput = File.ReadAllLines($"{FilePath}/day2.txt");
    
    [Fact]
    public void GameConfiguration_IsGameIdOne()
    {
        const string gameInput = "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green";
        var result = new Game(gameInput);
        Assert.Equal(1, result.GameId);
    }

    [Fact]
    public void SampleInput_ReturnsSumOfValidGameIds()
    {
        var gameInput = File.ReadAllLines($"{FilePath}/sample-1.txt");
        var game = new CubeConundrum(gameInput);
        Assert.Equal(8, game.SumOfValidGamesIds(new Bag(12, 13, 14)));
    }
    
    [Fact]
    public void FullInput_PartOne_ReturnsSumOfValidGameIds()
    {
        var game = new CubeConundrum(_dayTwoGameInput);
        Assert.Equal(2278, game.SumOfValidGamesIds(new Bag(12, 13, 14)));
    }
    
    [Fact]
    public void FullInput_PartTwo_ReturnsSumOfLowestRequiredCubes()
    {
        var game = new CubeConundrum(_dayTwoGameInput);
        Assert.Equal(67953, game.SumOfLowestRequiredCubes());
    }
}