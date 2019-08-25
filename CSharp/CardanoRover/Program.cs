using System;

namespace CardanoRover
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Rover r = new Rover(new Plateau(5, 5), 1, 2, Orientation.North);
            r.Rotate('R');
            r.Move();
            Console.WriteLine(r.PositionX  + " " + r.PositionY);
        }
    }
}
