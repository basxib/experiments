using System;
using CommandLine;
using System.Collections.Generic;

namespace CardanoRover
{
    public class Options
        {
            [Option('v', "verbose", Required = false, HelpText = "Set output to verbose messages.")]
            public bool Verbose { get; set; }
        }

    class Program
    {
        List<Rover> DeployedRovers;
        static void Main(string[] args)
        {
            string cmd = Console.ReadLine();
            var plateauDimensions = cmd.Split(" ");
            
            while(cmd!= null)
            {
                var initialPosition = Console.ReadLine().Split(" ");
                var movementSequence = Console.ReadLine();
            }
            

            Rover r = new Rover(new Plateau(5, 5), 1, 2, Orientation.North);
            r.Rotate('R');
            r.Move();
            Console.WriteLine(r.PositionX  + " " + r.PositionY);
        }
    }
}
