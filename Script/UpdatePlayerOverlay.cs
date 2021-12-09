using System.Collections.Generic;
using Project_Cautious.Cast;
using Project_Cautious.Cast.Basics;

namespace Project_Cautious.Script{
    public class UpdatePlayerOverlay : Action{
        public UpdatePlayerOverlay(){}

        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            foreach (Actor actor in cast["player"]){
                if (actor is PlayerOverlay){
                    PlayerOverlay playerOverlay = (PlayerOverlay) actor;
                    playerOverlay.HoldPosition();
                    playerOverlay.UpdateImage();
                }
            }
        }
    }
}