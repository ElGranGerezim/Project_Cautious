using System.Collections.Generic;
using System.Numerics;
using Project_Cautious.Cast.Basics;
using Project_Cautious.Cast;
using Project_Cautious.Services;
using Raylib_cs;
using Project_Cautious.UI;

namespace Project_Cautious.Script{
    public class EndGameAction : Action{

        AudioService _audioService;
        public EndGameAction(AudioService audioService){
            _audioService = audioService;
        }

        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            _audioService.SwitchBGM(Constants.LOSE_BGM);
            foreach(Banner banner in cast["banners"]){
                banner.SetVisibility(!banner.GetIsVisible());
            }
        }
    }
}