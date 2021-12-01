using System;
using System.Collections.Generic;
using Raylib_cs;
using Project_Cautious.Cast.Basics;

namespace Project_Cautious.Services{
    /// <summary>
    /// Handles all the interaction with the drawing library.
    /// </summary>
    public class OutputService
    {
        private Raylib_cs.Color _backgroundColor = Raylib_cs.Color.BLACK;
        private Dictionary<string, Raylib_cs.Texture2D> _textures
            = new Dictionary<string, Raylib_cs.Texture2D>();

        private Dictionary<string, Raylib_cs.Font> _fonts = new Dictionary<string, Font>();

        public OutputService(){
        }

        /// <summary>
        /// Opens a new window with the specified coordinates and title.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="title"></param>
        /// <param name="frameRate"></param>
        public void OpenWindow(int width, int height, string title, int frameRate)
        {
            Raylib.InitWindow(width, height, title);
            Raylib.SetTargetFPS(frameRate);
        }

        /// <summary>
        /// Closes the window
        /// </summary>
        public void CloseWindow()
        {
            Raylib.CloseWindow();
        }

        /// <summary>
        /// Starts the drawing process. This should be called
        /// before any draw commands.
        /// </summary>
        public void StartDrawing()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(_backgroundColor);
        }

        /// <summary>
        /// This finishes the drawing process. This should be called
        /// after all draw commands are finished.
        /// </summary>
        public void EndDrawing()
        {
            Raylib.EndDrawing();
        }

        /// <summary>
        /// Draws a rectangular box on the screen at the provided coordinates.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void DrawBox(int x, int y, int width, int height, Raylib_cs.Color color)
        {
            Raylib.DrawRectangle(x, y, width, height, color);            
        }

        /// <summary>
        /// Draws an image at the specified coordinates.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="image">The path to the image file</param>
        public void DrawImage(int x, int y, string image)
        {
            if (!_textures.ContainsKey(image))
            {
                Raylib_cs.Texture2D loaded = Raylib.LoadTexture(image);
                _textures[image] = loaded;
            }

            Raylib_cs.Texture2D texture = _textures[image];
            Raylib.DrawTexture(texture, x, y, Raylib_cs.Color.WHITE);
        }

        /// <summary>
        /// Displays text on the screen at the provided coordinates.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="text"></param>
        /// <param name="darkText"></param>
        public void DrawText(int x, int y, string text, bool darkText)
        {
            Raylib_cs.Color color = Raylib_cs.Color.WHITE;

            if (!(_fonts.ContainsKey("./Assets/computo-monospace.otf"))){
                Raylib_cs.Font loaded = Raylib.LoadFont("./Assets/computo-monospace.otf");
                _fonts["./Assets/computo-monospace.otf"] = loaded;
            }

            if (darkText)
            {
                color = Raylib_cs.Color.BLACK;
            }

            System.Numerics.Vector2 location = new System.Numerics.Vector2(x + Constants.DEFAULT_TEXT_OFFSET,
                y + Constants.DEFAULT_TEXT_OFFSET);
            Raylib.DrawTextEx(_fonts["./Assets/computo-monospace.otf"],
                text,
                location,
                Constants.DEFAULT_FONT_SIZE,
                Constants.DEFAULT_TEXT_OFFSET,
                color);
        }

        /// <summary>
        /// Draws a single actor.
        /// </summary>
        /// <param name="actor"></param>
        public void DrawActor(Actor actor)
        {
            int x = actor.GetX();
            int y = actor.GetY();
            int width = actor.GetWidth();
            int height = actor.GetHeight();
            Raylib_cs.Color color = actor.GetColor();


            if (actor.HasImage())
            {
                string image = actor.GetImage();
                DrawImage(x, y, image);
            }
            else if (actor.HasText())
            {
                bool darkText = false;
                string text = actor.GetText();
                DrawText(x, y, text, darkText);
            }
            else
            {
                DrawBox(x, y, width, height, color);
            }

            if (actor.HasSubtitle()){
                bool darkText = false;
                string subtitle = actor.GetSubtitle();
                int subX = x + (actor.GetWidth() / 2) - ((subtitle.Length / 2) * Constants.DEFAULT_FONT_SIZE);
                int subY = y + actor.GetHeight();
                DrawText(subX, subY, subtitle, darkText);
            }
        }

        /// <summary>
        /// Draws all actors in the list.
        /// </summary>
        /// <param name="actors"></param>
        public void DrawActors(List<Actor> actors)
        {
            foreach (Actor actor in actors)
            {
                if (actor.GetIsVisible()){
                    DrawActor(actor);
                }
            }
        }

    }
}