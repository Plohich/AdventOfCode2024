using System.Linq.Expressions;

namespace AdventOfCode_202415;

public static class MapTypeExtensions
{
    public static char GetNextPosObject(this MapType map, CoordType coordinates, char direction) =>
    
        direction switch
            {
                '^' => map.MapMatrix[coordinates.Y - 1][coordinates.X],
                'v' => map.MapMatrix[coordinates.Y + 1][coordinates.X],
                '>' => map.MapMatrix[coordinates.Y][coordinates.X + 1],
                '<' => map.MapMatrix[coordinates.Y][coordinates.X - 1],
                _ => map.MapMatrix[coordinates.X][coordinates.Y]
            };
       
    
    public static (CoordType old, CoordType nw) CalculateBoxDisplacement(this MapType map, CoordType coordinates, char direction)
    {
        CoordType boxDisplacementStart = CoordType.FromCoordType(coordinates).Recalculate(direction);
        CoordType boxDisplacementEnd = CoordType.FromCoordType(coordinates);
       
        
        while (GetNextPosObject(map, boxDisplacementEnd, direction) == 'O')
        {
            boxDisplacementEnd = boxDisplacementEnd.Recalculate(direction);
        }
        
        return GetNextPosObject(map, boxDisplacementEnd, direction) switch
        {
            '#' => (coordinates, coordinates),
            '.' => (boxDisplacementStart, boxDisplacementEnd.Recalculate(direction)),
            '@' => (boxDisplacementStart, boxDisplacementEnd.Recalculate(direction)),
            _ => throw new InvalidOperationException("Unknown box displacement")
        };
    }

    public static int GetBoxDistance(this MapType map, int row, int col) =>
        map.MapMatrix[row][col] switch
        {
            'O' => (row * 100) + col,
            _ => 0
        };

}