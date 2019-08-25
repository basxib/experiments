using System;
using System.Linq;
using System.Collections.Generic;
public class Rover{
    public Rover( Plateau basePlateau, int initialPositionX,int initialPositionY, Orientation initialOrientation)
    {
        PositionX = initialPositionX;
        PositionY = initialPositionY;
        BasePlateau = basePlateau;
        CurrentOrientation= initialOrientation; 
        ID = Guid.NewGuid();

    }
    public Guid ID{get;}
    public int PositionX{get; set;}
    public int PositionY{get; set;}
    public Plateau BasePlateau {get;} 
    public Orientation CurrentOrientation{get; set;}
    public void ExecuteSequence(string sequence)
    {
        sequence= sequence.ToUpper();
        foreach(var x in sequence)
        {
            switch(x){
                case 'M':
                    Move();
                    break;
                case 'L':
                case 'R':
                    Rotate(x);
                    break;
                default:
                    throw new Exception("Invalid Command");
            }
        }
    }
    public void Move()
    {
        switch(CurrentOrientation)
        {
            case Orientation.East:
                PositionX++;
                break;
            case Orientation.West:
                PositionX--;
                break;
            case Orientation.North:
                PositionY--;
                break;
            case Orientation.South:
                PositionY++;
                break;
            default: throw new Exception("Invalid orientation on rover with ID:" + this.ID);
        }

        
    }
    public void Rotate(Char direction)
    {
        CurrentOrientation = (Orientation)((int)CurrentOrientation % 5) + Direction.Parse(direction);
    }
} 


