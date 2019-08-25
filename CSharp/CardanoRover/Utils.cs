using System;
public struct Position{
    public int x;
    public int y;
}
public class Utils
{
    public enum Orientation
    {Null, North, East, South, West}

    public enum Direction
    { Left=-1, Right=1}

    public static Orientation ParseOrientation(char Orietationletter)
    {
        switch(char.ToUpper(Orietationletter))
        {
            case 'N': return Orientation.North;
            case 'E': return Orientation.East;
            case 'S': return Orientation.South;
            case 'W': return Orientation.West;
            default: return Orientation.Null;
        }
    }

    public static Direction ParseDirection(char d)
    {
        if (char.ToUpper(d) == 'L')
            return Direction.Left;
        else if (char.ToUpper(d) == 'R')
            return Direction.Right;
        else 
            throw new Exception("Invalid direction");

    }


}



