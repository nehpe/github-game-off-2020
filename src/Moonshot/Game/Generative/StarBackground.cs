using System;
using Raylib_cs;

namespace Moonshot.Game.Generative
{
    public class StarBackground
    {
        //public Image img;
        public RenderTexture2D texture;

        public Random rnd;

        private Image star;
        private Texture2D starTex;
        private Texture2D starTex90;


        public StarBackground()
        {
            rnd = new Random();

            //img = Raylib.GenImageColor(MoonVars.RenderWidth, MoonVars.RenderHeight, new Color(0, 0, 0, 0));
            //texture = Raylib.LoadTextureFromImage(img);
            //
            texture = Raylib.LoadRenderTexture(MoonVars.RenderWidth, MoonVars.RenderHeight);

            Color[] c = new Color[9];
            c[1] = new Color(255, 255, 255, 150);
            c[3] = new Color(255, 255, 255, 150);
            c[4] = Color.DARKGRAY;
            c[5] = new Color(255, 255, 255, 150);
            c[7] = new Color(255, 255, 255, 150);

            star = Raylib.LoadImageEx(c, 3, 3);
            starTex = Raylib.LoadTextureFromImage(star);

            c = new Color[9];

            c[0] = Color.DARKGRAY;
            c[2] = Color.DARKGRAY;
            c[4] = Color.DARKGRAY;
            c[6] = Color.DARKGRAY;
            c[8] = Color.DARKGRAY;

            star = Raylib.LoadImageEx(c, 3, 3);
            starTex90 = Raylib.LoadTextureFromImage(star);
            _render();
        }

        private void _render()
        {
            Raylib.BeginDrawing();
            Raylib.BeginTextureMode(texture);
            //Raylib.ClearBackground(Color.BLACK);

            Raylib.DrawRectangle(50, 50, 1, 1, Color.WHITE);
            Raylib.DrawTexture(starTex90, 100, 100, Color.WHITE);
            Raylib.DrawTexture(starTex, MoonVars.RenderWidth / 2, MoonVars.RenderHeight / 2, Color.WHITE);
            Raylib.DrawRectangle(48, 50, 1, 1, new Color(255, 255, 255, 255));
            Raylib.DrawRectangle(51, 50, 1, 1, new Color(255, 255, 255, 255));
            Raylib.DrawRectangle(50, 51, 1, 1, new Color(255, 255, 255, 255));
            Raylib.DrawRectangle(50, 48, 1, 1, new Color(255, 255, 255, 255));

            Raylib.EndTextureMode();
            Raylib.EndDrawing();
        }
    }
}
