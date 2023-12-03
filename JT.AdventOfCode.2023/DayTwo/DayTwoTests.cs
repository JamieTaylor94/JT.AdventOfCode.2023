namespace JT.AdventOfCode._2023.DayTwo;

public class DayTwoTests
{
    private static readonly string FilePath = $"{Directory.GetCurrentDirectory()}/DayTwo/Resources";
    
    // [Fact]
    // public void GameConfiguration_SampleInput_ContainsRedCubes()
    // {
    //     var game = "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green";
    //     
    //     var result = new GameConfiguration(game);
    //     
    //     Assert.Equal(5, result.Red.Count);
    //     Assert.Equal(1, result.GameNumber);
    // }

    [Fact]
    public void SampleInput()
    {
        var lines = File.ReadAllLines($"{FilePath}/sample-1.txt");
        var game = new Game(lines);
        Assert.Equal(8, game.SumPossibleGames(12, 13, 14));
    }
    
    [Fact]
    public void FullInput()
    {
        var lines = File.ReadAllLines($"{FilePath}/day2.txt");
        var game = new Game(lines);
        Assert.Equal(2278, game.SumPossibleGames(12, 13, 14));
        // too low
    }

    [Fact]
    public void Struggle()
    {;
          
        var result = new GameConfiguration("Game 27: 10 red, 8 blue, 7 green; 6 green, 7 blue; 4 red, 10 green, 9 blue; 9 red, 2 green, 1 blue; 11 blue, 15 red, 9 green");
        
        //Assert.Equal(5, result.Red.Count);
        Assert.Equal(1, result.GameNumber);
    }
}

public class Game
{
    private readonly string[] _gameInput;

    public Game(string[] gameInput)
    {
        _gameInput = gameInput;
    }
    public int SumPossibleGames(int red, int green, int blue)
    {
        var allGames = _gameInput.Select(g => new GameConfiguration(g));
        var possibleGames = allGames.Where(g => g.IsValidGame(red, green, blue));
        return possibleGames.Sum(g => g.GameNumber);
    }
}

public class GameConfiguration
{
    private readonly List<Cube> _cubes;
    public int GameNumber { get; }

    public bool IsValidGame(int maxRed,int maxGreen, int maxBlue)
    {
        var maxColours = _cubes.GroupBy(c => c.Colour)
            .Select(group => group
                .OrderByDescending(c => c.Count)
                .First()).ToList();
        
        var reds = maxColours.First(c => c.Colour == "red").Count > maxRed;
        var greens = maxColours.First(c => c.Colour == "green").Count > maxGreen;
        var blues = maxColours.First(c => c.Colour == "blue").Count > maxBlue;

        return !reds && !greens && !blues;
    }

    public GameConfiguration(string game)
    {
        var parts = game.Split(':', ',', ';');
        _cubes = ParseCubes(parts.Skip(1).ToList());
        GameNumber = int.Parse(parts.First().Split(' ').Last());
    }

    private List<Cube> ParseCubes(List<string> parts)
    {
        return parts
            .Select(c =>
            {
                var separated = c.Trim().Split(' ');
                return new Cube(int.Parse(separated.First()), separated.Last());
            })
            .ToList();
    }
}

public record Cube(int Count, string Colour);