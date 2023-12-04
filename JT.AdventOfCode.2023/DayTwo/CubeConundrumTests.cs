namespace JT.AdventOfCode._2023.DayTwo;

public class CubeConundrumTests: InputReader
{
    private readonly string[] _gameInput = InputByLine("DayTwo");
    
    [Fact]
    public void GameConfiguration_IsGameIdOne()
    {
        const string input = "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green";
        var result = new Game(input);
        Assert.Equal(1, result.GameId);
    }

    [Fact]
    public void SampleInput_ReturnsSumOfValidGameIds()
    {
        var gameInput = InputByLine("DayTwo", "sample-1.txt");
        var game = new CubeConundrum(gameInput);
        Assert.Equal(8, game.SumOfValidGamesIds(new Bag(12, 13, 14)));
    }
    
    [Fact]
    public void FullInput_PartOne_ReturnsSumOfValidGameIds()
    {
        var game = new CubeConundrum(_gameInput);
        Assert.Equal(2278, game.SumOfValidGamesIds(new Bag(12, 13, 14)));
    }
    
    [Fact]
    public void FullInput_PartTwo_ReturnsSumOfLowestRequiredCubes()
    {
        var game = new CubeConundrum(_gameInput);
        Assert.Equal(67953, game.SumOfLowestRequiredCubes());
    }
}