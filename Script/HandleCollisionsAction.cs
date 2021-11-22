using System.Collections.Generic;
using Raylib_cs;
using Project_Cautious.Services;
using Project_Cautious.Cast.Basics;

namespace Project_Cautious.Script{
    public class HandleCollisionsAction : Action{
        PhysicsService _physicsService;
        AudioService _audioService;

        public HandleCollisionsAction(PhysicsService physicsService, AudioService audioService){
            _physicsService = physicsService;
            _audioService = audioService;
        }

        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            throw new System.NotImplementedException();
        }

    }
}