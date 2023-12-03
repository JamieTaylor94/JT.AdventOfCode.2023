namespace JT.AdventOfCode._2023.DayTwo;

public class CubeConundrum
{
    private readonly string[] _allGamesInput;

    public CubeConundrum(string[] allGamesInput)
    {
        _allGamesInput = allGamesInput;
    }

    public int SumOfValidGamesIds(Bag bag)
    {
        var allGames = _allGamesInput.Select(g => new Game(g));
        var possibleGames = allGames.Where(g => g.IsValidGame(bag));
        return possibleGames.Sum(g => g.GameId);
    }
    
    public int SumOfLowestRequiredCubes()
    {
        var allGames = _allGamesInput.Select(g => new Game(g));
        return allGames.Sum(games => 
            games.MinimumRequiredCubes.RedCubes *
            games.MinimumRequiredCubes.GreenCubes *
            games.MinimumRequiredCubes.BlueCubes);
    }
}