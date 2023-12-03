namespace JT.AdventOfCode._2023.DayTwo;

public class Game
{
    private readonly List<Cube> _cubes;
    public int GameId { get; }
    public Bag MinimumRequiredCubes { get; }

    public Game(string gameInput)
    {
        var parts = gameInput.Split(':', ',', ';');
        _cubes = ExtractCubes(parts.Skip(1).ToList());
        GameId = int.Parse(parts.First().Split(' ').Last());
        MinimumRequiredCubes = GetLargestCubeColours();
    }
    
    public bool IsValidGame(Bag bagCapacity)
    {
        return !(MinimumRequiredCubes.RedCubes > bagCapacity.RedCubes) &&
               !(MinimumRequiredCubes.GreenCubes > bagCapacity.GreenCubes) &&
               !(MinimumRequiredCubes.BlueCubes > bagCapacity.BlueCubes);
    }

    private Bag GetLargestCubeColours()
    {
        var reds = _cubes.Where(c => c.Colour == "red").Max(c => c.Count);
        var greens = _cubes.Where(c => c.Colour == "green").Max(c => c.Count);
        var blues = _cubes.Where(c => c.Colour == "blue").Max(c => c.Count);
        
        return new Bag(reds, greens, blues);
    }
    
    private List<Cube> ExtractCubes(List<string> parts)
    {
        return parts.Select(c =>
            {
                var separated = c.Trim().Split(' ');
                return new Cube(int.Parse(separated.First()), separated.Last());
            })
            .ToList();
    }
}