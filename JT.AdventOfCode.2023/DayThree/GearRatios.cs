namespace JT.AdventOfCode._2023.DayThree;

public class GearRatios
{
    private readonly int _rowLength;
    private readonly int _columnLength;
    private readonly char[,] _grid;
    public GearRatios(string[] input)
    {
        _rowLength = input.Length;
        _columnLength = input[0].Length;
        _grid = CreateGrid(input);
    }

    public int Calculate()
    {
        var sum = 0;
        var cellsPartOfNumber = new List<Cell>();
        
        for (var row = 0; row < _rowLength; row++)
        {
            for (var column = 0; column < _columnLength; column++)
            {
                if (char.IsDigit(_grid[row, column]))
                {
                    cellsPartOfNumber.Add(new Cell(row, column, _grid));
                }
                else
                {
                    if (cellsPartOfNumber.Any(c => c.HasSymbolNearby()))
                    {
                        var number = int.Parse(string.Concat(cellsPartOfNumber
                                .Select(c => c.ExtractNumber)
                                .ToList()));
                        sum += number;
                    }
                    cellsPartOfNumber.Clear();
                }
            }
        }
        return sum;
    }

    private char[,] CreateGrid(string[] input)
    {
        var grid = new char[_rowLength, _columnLength];
        for (var row = 0; row < _rowLength; row++) {
            for (var column = 0; column < _columnLength; column++) {
                grid[row, column] = input[row][column];
            }
        }

        return grid;
    }
}