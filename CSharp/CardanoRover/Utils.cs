using System;
public struct Position{
    public int x;
    public int y;
}
public enum Orientation
{Null, North, East, South, West}
public class Direction
{
    public const int Left=-1;
    public const int Right=1; 
    public static int Parse(char d)
{
    if (char.ToUpper(d) == 'L')
        return Left;
    else if (char.ToUpper(d) == 'R')
        return Right;
    else 
        throw new Exception("Invalid direction");

}
}

