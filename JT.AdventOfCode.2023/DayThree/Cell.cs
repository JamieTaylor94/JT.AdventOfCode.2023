namespace JT.AdventOfCode._2023.DayThree;

public class Cell
{
    private readonly int _currentRow;
    private readonly int _currentColumn;
    private readonly char[,] _grid;

    public Cell(int currentRow, int currentColumn, char[,] grid)
    {
        _currentRow = currentRow;
        _currentColumn = currentColumn;
        _grid = grid;
    }

    public int ExtractNumber => _grid[_currentRow, _currentColumn] - '0';
    
    public bool HasSymbolNearby()
    {
        var directions = new [] {Right, Left, Top, Bottom, DiagonalTopRight, DiagonalTopLeft, DiagonalBottomRight, DiagonalBottomLeft};
        return directions.Any(c => c.HasValue && IsSymbol(c.Value));
    }
   
    public char? Right => GetValue(_currentRow, _currentColumn + 1);
    public char? Left => GetValue(_currentRow, _currentColumn - 1);
    public char? Top => GetValue(_currentRow - 1, _currentColumn);
    public char? Bottom => GetValue(_currentRow + 1, _currentColumn);
    public char? DiagonalTopRight => GetValue(_currentRow - 1, _currentColumn + 1);
    public char? DiagonalTopLeft => GetValue(_currentRow - 1, _currentColumn - 1);
    public char? DiagonalBottomRight => GetValue(_currentRow + 1, _currentColumn + 1);
    public char? DiagonalBottomLeft => GetValue(_currentRow + 1, _currentColumn - 1);

    private char? GetValue(int row, int column)
    {
        return row >= 0 &&
            row < _grid.GetLength(0)
            && column >= 0
            && column < _grid.GetLength(1)
                ?_grid[row, column] 
                : null;
    }
    
    private bool IsSymbol(char c)
    {
        return !char.IsDigit(c) && c != '.';
    }
}