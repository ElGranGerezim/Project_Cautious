using System.Collections.Generic;
using System.Numerics;
using Project_Cautious.Cast.Basics;
using Project_Cautious.Cast;
using Raylib_cs;

namespace Project_Cautious.Script{
    public class KillPlayerAction : Action{
        public KillPlayerAction(){}
        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            List<Actor> toRemove = new List<Actor>();
            foreach (Player player in cast["player"]){
                if (player.GetHealth() == 0){
                    toRemove.Add(player);
                }
            }
            
            foreach (Actor bye in toRemove){
                cast["player"].Remove(bye);
            }
        }
    }
}