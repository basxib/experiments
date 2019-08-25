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
        private static List<Rover> DeployedRovers = new List<Rover>();
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Welcome to cardano rover platform management console");
            Console.WriteLine("Follow the instructions to initialize the platform");
            Console.WriteLine("......");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Step 1: Type the plateau dimensions: example: 5 5");
            Console.ForegroundColor = ConsoleColor.White;
            try
            {
                
                string cmd = Console.ReadLine().Trim();
                var plateauDimensions = cmd.Split(" ");
                Plateau targetPlateau = new Plateau(int.Parse(plateauDimensions[0]), int.Parse(plateauDimensions[1]));
                Console.WriteLine("Awesome!, we created the plateau with the given dimensions..");
                Console.WriteLine("Step 2: Start creating rovers to be deployed over that plateau");
                do
                {
                    Console.WriteLine("...Enter the intitial position and orientation of this rover using the format: 1 2 N");
                    cmd = Console.ReadLine().Trim();
                    var initialPosition = cmd.Split(" ");
                    var rover = new Rover(targetPlateau, int.Parse(initialPosition[0]), int.Parse(initialPosition[1]), Utils.ParseOrientation(initialPosition[2][0]));
                    Console.WriteLine("Congrats, your rover "+ rover.ID +" was created successfully");
                    Console.WriteLine("Now, Enter the movement sequence for this rover in the format: LML");
                    cmd = Console.ReadLine().Trim();
                    var movementSequence = cmd;
                    rover.ExecuteSequence(movementSequence);
                    DeployedRovers.Add(rover);
                    Console.WriteLine("Press enter to add another rover, enter 'Q' if you're done.");
                    cmd = Console.ReadLine();
                }while(cmd!= "Q");
            }
            catch(FormatException)
            {
                Console.WriteLine("Invalid command, please make sure you're using the correct format");
            }
            Console.WriteLine("...................");
            printRovers();
            Console.WriteLine("...................");
            string cmdText = "";
            do{
                Console.WriteLine("Enter the index of the rover and a sequence command to move it, example: 0 MMR");
                cmdText = Console.ReadLine().Trim();
                var x = cmdText.Split();
                var roverIndex = int.Parse(x[0]);
                if(roverIndex < DeployedRovers.Count)
                    DeployedRovers[roverIndex].ExecuteSequence(x[1]);
                else 
                    Console.WriteLine("Wrong input, There's no rover with this index");
                Console.WriteLine("Press enter to move a rover, enter 'Q' to quite.");
                cmdText = Console.ReadLine();
            }while(cmdText!= "Q");
        }
        public static void printRovers()
        {
            Console.WriteLine("You created the following rovers:");
            foreach(var x in DeployedRovers)
            {
                Console.WriteLine("Rover ID:"+ x.ID);
                Console.WriteLine("Rover current position x, y: "+ x.PositionX + " "+ x.PositionY);
                Console.WriteLine("Rover current orientatio: "+ x.CurrentOrientation.ToString());
                Console.WriteLine("...............");
            }
        }
    }
}
