using System.Collections.Generic;
using System.Numerics;
using Project_Cautious.Cast.Basics;
using Project_Cautious.Cast;
using Project_Cautious.Services;
using Raylib_cs;

namespace Project_Cautious.Script{
    /// <summary>
    /// Action to handle constant updates to player every frame from input or timers.
    /// </summary>
    public class ControlActorsAction : Action {
        private InputService _inputService;
        private Point _playerPosition;
        
        public ControlActorsAction(InputService inputService){
            _inputService = inputService;
        }

        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            foreach (Actor actor in cast["player"]){
                if (actor is Player){
                    Player player = (Player) actor;
                    player.setFocusing(_inputService.IsFocusKeyPressed());
                    player.SetVelocity(_inputService.GetDirection());
                    player.tickIFrames();
                    _playerPosition = player.GetPosition();
                } else {
                    PlayerOverlay playerOverlay = (PlayerOverlay) actor;
                    playerOverlay.HoldPosition();
                }
            }

            foreach (Enemy enemy in cast["enemies"]){
                enemy.Move(_playerPosition);
            }
        }
    }
}