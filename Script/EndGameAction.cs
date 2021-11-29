using System.Collections.Generic;
using System.Numerics;
using Project_Cautious.Cast.Basics;
using Project_Cautious.Cast;
using Project_Cautious.Services;
using Raylib_cs;

namespace Project_Cautious.Script{
    public class EndGameAction : Action{

        public EndGameAction(){
        }

        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            foreach(Banner banner in cast["banners"]){
                banner.SetVisibility(!banner.GetIsVisible());
            }
        }
    }
}