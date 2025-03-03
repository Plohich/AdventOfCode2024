namespace AdventOfCode_202415;

public class WarehouseMap
{
    public MapType  Map { get; }
    public RobotPositionType RobotPosition { get; }

    private WarehouseMap(string[] mapLines)
    {
        RobotPosition = new (new (0, 0));
        Map = new ( MapMatrix: new char[mapLines.Length][]);
        for (int i = 0; i < mapLines.Length; i++)
        {
            Map.MapMatrix[i] = mapLines[i].ToCharArray();
            int colIndex = mapLines[i].IndexOf('@');
            if ( colIndex > -1)
            {
                RobotPosition = new(new(i, colIndex));
            }
        }
    }

    private WarehouseMap(RobotPositionType robotPosition, MapType map) => 
        (RobotPosition, Map) = (robotPosition, map);
    
    public static WarehouseMap Create(string[] mapLines) =>
        new (mapLines);
    
    public static WarehouseMap FromRobotPositionAndMap(RobotPositionType newRobotLoc, MapType updatedMap) => 
        new(newRobotLoc, updatedMap);

    public void Print()
    {
        for (int i = 0; i < Map.MapMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < Map.MapMatrix[i].Length; j++)
            {
                Console.Write($"{Map.MapMatrix[i][j]} ");
            }
            
            Console.WriteLine();
        }
    }

    public long GetBoxesCoordinatesSum()
    {
        long sum = 0;
        for (int i = 1; i < Map.MapMatrix.GetLength(0); i++)
        {
            for (int j = 1; j < Map.MapMatrix[i].Length; j++)
            {
                sum += Map.GetBoxDistance(i, j);
            }
            
        }
        return sum;
    }
    
}