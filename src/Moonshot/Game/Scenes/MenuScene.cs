using Moonshot.Utilities;
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Moonshot.Game.Scenes
{
    public class MenuScene : IScene
    {
        MoonshotGame g;

        Vector2 textMeasure;
        int fontSize = 20;
        Font font;


        public MenuScene(MoonshotGame g)
        {
            this.g = g;

            font = AssetManager.GetFont("alpha_beta");

            textMeasure = Raylib.MeasureTextEx(font, MoonVars.Name, fontSize, 1);
        }

        public void Draw(RenderTexture2D target)
        {
            Raylib.BeginDrawing();
            {
                Raylib.BeginTextureMode(target);

                Raylib.ClearBackground(new Color(36, 36, 36, 255));

                Raylib.DrawTextEx(
                    font, MoonVars.Name,
                    new Vector2(
                        Text.Center(MoonVars.RenderWidth, (int)textMeasure.X),
                        MoonVars.RenderHeight / 4
                    ),
                    fontSize, 1, new Color(196, 196, 196, 255)
                );

                Raylib.DrawFPS(0, 0);
                Raylib.EndTextureMode();
            }
            Raylib.EndDrawing();
        }

        public void Update()
        {
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
            {
                this.g.NextScene(new PlayScene(this.g));
            }
        }
    }
}
