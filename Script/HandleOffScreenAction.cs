using System.Collections.Generic;
using Project_Cautious.Cast;
using Project_Cautious.Cast.Basics;
using Project_Cautious.Services;


namespace Project_Cautious.Script
{
    /// <summary>
    /// An action to move all of the actors in the game according to their stored velocity.
    /// </summary>
    public class HandleOffScreenAction : Action
    {
        public HandleOffScreenAction(){

        }

        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            foreach (List<Actor> group in cast.Values)
            {
                List<Actor> toRemove = new List<Actor>();
                foreach(Actor actor in group){
                    if (actor is Player){
                        if (actor.GetX() <= 0 || actor.GetX() + actor.GetVelocity().GetX() <= 0){
                            actor.SetPosition(new Point(0, actor.GetPosition().GetY()));
                        }
                        else if (actor.GetX() >= Constants.MAX_X - actor.GetWidth() || actor.GetX() + actor.GetVelocity().GetX() >= Constants.MAX_X){
                            actor.SetPosition(new Point(Constants.MAX_X - actor.GetWidth(), actor.GetPosition().GetY()));
                        }

                        if (actor.GetY() <= 0 || actor.GetY() + actor.GetVelocity().GetY() <= 0){
                            actor.SetPosition(new Point(actor.GetPosition().GetX(), 0));
                        }
                        else if (actor.GetY() >= Constants.MAX_Y - actor.GetHeight() / 2|| actor.GetY() + actor.GetVelocity().GetY() >= Constants.MAX_Y){
                            actor.SetPosition(new Point(actor.GetPosition().GetX(), Constants.MAX_Y - actor.GetHeight() / 2));
                        }
                    }
                    else{
                        if (actor.GetX() > Constants.MAX_X || actor.GetX() < 0 || actor.GetY() > Constants.MAX_Y || actor.GetY() < 0){
                            toRemove.Add(actor);
                        }
                    }
                }
                foreach(Actor bye in toRemove){
                    group.Remove(bye);
                }
            }    
        }
    }
}