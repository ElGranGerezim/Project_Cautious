using System.Collections.Generic;
using System.Numerics;
using Project_Cautious.Cast.Basics;
using Project_Cautious.Cast;
using Project_Cautious.Services;
using Raylib_cs;

namespace Project_Cautious.Script{
    /// <summary>
    /// Action to convert user input to player action.
    /// </summary>
    public class ControlActorsAction : Action {
        private InputService _inputService;
        
        public ControlActorsAction(InputService inputService){
            _inputService = inputService;
        }

        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            foreach (Player player in cast["player"]){
                player.setFocusing(_inputService.IsFocusKeyPressed());
                player.setShouldFire(_inputService.IsFireKeyPressed());
                player.SetVelocity(_inputService.GetDirection());
            }
        }
    }
}