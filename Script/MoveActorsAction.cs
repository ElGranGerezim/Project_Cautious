using System.Collections.Generic;
using Project_Cautious.Cast.Basics;
using Project_Cautious.Services;


namespace Project_Cautious.Script
{
    /// <summary>
    /// An action to move all of the actors in the game according to their stored velocity.
    /// </summary>
    public class MoveActorsAction : Action
    {
        public MoveActorsAction(){

        }

        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            foreach (List<Actor> group in cast.Values)
            {
                foreach(Actor item in group){
                    Point position = item.GetPosition();
                    Point velocity = item.GetVelocity();
                    int newX = position.GetX() + velocity.GetX();
                    int newY = position.GetY() + velocity.GetY();
                    item.SetPosition(new Point(newX, newY));
                }
            }    
        }
    }
}