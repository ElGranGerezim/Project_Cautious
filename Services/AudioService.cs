using System;
using Raylib_cs;
using Project_Cautious.Cast.Basics;
using System.Collections.Generic;

namespace Project_Cautious.Services{
    /// <summary>
    /// Handles all the audio elements the game.
    /// </summary>
    public class AudioService
    {
        private string currentBGM;
        private Dictionary<string, Raylib_cs.Sound> _sounds
            = new Dictionary<string, Raylib_cs.Sound>();
        
        public AudioService()
        {

        }

        /// <summary>
        /// Plays the sound stored in the provided .wav file.
        /// </summary>
        /// <param name="filename">The path to the .wav file</param>
        public void PlaySound(string filename)
        {
            if (!_sounds.ContainsKey(filename))
            {
                Raylib_cs.Sound loaded = Raylib.LoadSound(filename);
                _sounds[filename] = loaded;
            }
            Raylib_cs.Sound sound = _sounds[filename];
            Raylib.PlaySound(sound);
        }

        public bool IsBGMPlaying(){
            if (_sounds.ContainsKey(currentBGM)){
                Raylib_cs.Sound sound = _sounds[currentBGM];
                return Raylib.IsSoundPlaying(sound);
            } else
            return false;
        }

        public void PlayBGM(){
            PlaySound(currentBGM);
        }

        /// <summary>
        /// Initializes the audio device.
        /// </summary>
        public void StartAudio()
        {
            Raylib.InitAudioDevice();
        }

        /// <summary>
        /// Closes down the audio device.
        /// </summary>
        public void StopAudio()
        {
            Raylib.CloseAudioDevice();
        }
 
        public void SwitchBGM(string newBGM){
            if (currentBGM is not null){
                if (_sounds.ContainsKey(currentBGM)){
                    if (Raylib.IsSoundPlaying(_sounds[currentBGM])){
                        Raylib.StopSound(_sounds[currentBGM]);
                    }
                }
            }
            currentBGM = newBGM;
            PlaySound(currentBGM);
        }
   }
}
