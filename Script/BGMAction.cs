using Project_Cautious.Services;
using Project_Cautious.Script;
using System.Collections.Generic;
using Project_Cautious.Cast.Basics;

namespace Project_Cautious.Script{
    public class BGMAction : Action{
        AudioService _audioservice;

        public BGMAction(AudioService audioService){
            _audioservice = audioService;
        }

        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            if (!_audioservice.IsBGMPlaying()){
                _audioservice.PlayBGM();
            }
        }
    }
}