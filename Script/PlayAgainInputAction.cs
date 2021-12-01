using System.Collections.Generic;
using System.Numerics;
using Project_Cautious.Cast.Basics;
using Project_Cautious.Cast;
using Project_Cautious.Services;
using Raylib_cs;

namespace Project_Cautious.Script{
    public class PlayAgainInputAction : Action{

        InputService _inputService;
        public PlayAgainInputAction(InputService inputService){
            _inputService = inputService;
        }

        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            if (_inputService.IsContinuePressed()){
                cast["banners"].Clear();
            }
        }
    }
}