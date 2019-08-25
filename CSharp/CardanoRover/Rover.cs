using System;
using System.Linq;
using System.Collections.Generic;
public class Rover{
    public Rover( Plateau basePlateau, int initialPositionX,int initialPositionY, Utils.Orientation initialOrientation)
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
    public Utils.Orientation CurrentOrientation{get; set;}
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
            case Utils.Orientation.East:
            if(PositionX + 1 > BasePlateau.Width)
                throw new Exception("Not allowed movement on rover with ID: "+ this.ID);
            else
                PositionX++;
            break;
            case Utils.Orientation.West:
            if(PositionX - 1 < 0)
                throw new Exception("Not allowed movement on rover with ID: "+ this.ID);
            else
                PositionX--;
            break;
            case Utils.Orientation.North:
            if(PositionY -1 < 0)
                throw new Exception("Not allowed movement on rover with ID: "+ this.ID);
            else
                PositionY--;
                break;
            case Utils.Orientation.South:
            if(PositionY + 1 > BasePlateau.Length)
                throw new Exception("Not allowed movement on rover with ID: "+ this.ID);
            else
                PositionY++;
                break;
            default: throw new Exception("Invalid orientation on rover with ID:" + this.ID);
        }

        
    }
    public void Rotate(Char direction)
    {
        if(CurrentOrientation == Utils.Orientation.North && Utils.ParseDirection(direction) == Utils.Direction.Left)
            CurrentOrientation = Utils.Orientation.West;
        else
            CurrentOrientation = (Utils.Orientation)((int)CurrentOrientation % 5) + (int)Utils.ParseDirection(direction);
    }
} 


