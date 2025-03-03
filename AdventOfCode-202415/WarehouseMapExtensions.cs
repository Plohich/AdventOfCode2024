namespace AdventOfCode_202415;

public static  class WarehouseMapExtensions
{
    public static (RobotPositionType newRobot, MapType updatedMap) ApplyRobotMove(this WarehouseMap warehouseMap, char direction) =>
    
        warehouseMap.Map.GetNextPosObject(warehouseMap.RobotPosition.Coordinates, direction) switch
        {
            '.' => (warehouseMap.RobotPosition.Recalculate(direction), warehouseMap.Map),
            '#' => (warehouseMap.RobotPosition, warehouseMap.Map),
            'O' => warehouseMap.RecalculateRobotAndBoxesPositions(direction),
            '@' => (warehouseMap.RobotPosition.Recalculate(direction), warehouseMap.Map),
            _ => throw new InvalidOperationException("Unknown object")
        };
    
    private static (RobotPositionType, MapType) RecalculateRobotAndBoxesPositions(this WarehouseMap warehouseMap, char direction)
    {
       var recalc = warehouseMap.Map.CalculateBoxDisplacement(warehouseMap.RobotPosition.Coordinates, direction);
       
        (warehouseMap.Map.MapMatrix[recalc.old.Y][recalc.old.X], warehouseMap.Map.MapMatrix[recalc.nw.Y][recalc.nw.X]) = 
            (warehouseMap.Map.MapMatrix[recalc.nw.Y][recalc.nw.X],warehouseMap.Map.MapMatrix[recalc.old.Y][recalc.old.X]);
        
        (warehouseMap.Map.MapMatrix[warehouseMap.RobotPosition.Coordinates.Y][warehouseMap.RobotPosition.Coordinates.X], warehouseMap.Map.MapMatrix[recalc.old.Y][recalc.old.X]) = 
            (warehouseMap.Map.MapMatrix[recalc.old.Y][recalc.old.X],warehouseMap.Map.MapMatrix[warehouseMap.RobotPosition.Coordinates.Y][warehouseMap.RobotPosition.Coordinates.X]);
        
        return (new RobotPositionType(recalc.old), warehouseMap.Map);
       
    }
}