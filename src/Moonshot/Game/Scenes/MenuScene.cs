using Moonshot.Game.Entities;
using Moonshot.Utilities;
using Raylib_cs;
using System.Numerics;

namespace Moonshot.Game.Scenes
{
    public class MenuScene : IScene
    {
        MoonshotGame g;

        Vector2 textMeasure;
        int fontSize = 20;
        Font font;

        Font instructFont;
        Vector2 instructMeasure;
        int instructFontSize = 12;
        string instruction = "Press Enter to Start";

        Stars stars;


        public MenuScene(MoonshotGame g)
        {
            this.g = g;

            font = AssetManager.GetFont("alpha_beta");
            instructFont = AssetManager.GetFont("pixantiqua");

            textMeasure = Raylib.MeasureTextEx(font, MoonVars.Name, fontSize, 1);
            instructMeasure = Raylib.MeasureTextEx(instructFont, instruction, instructFontSize, 1);

            stars = new Stars();
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

                Raylib.DrawTextEx(
                    instructFont, "Press Enter to Start",
                    new Vector2(
                        Text.Center(MoonVars.RenderWidth, (int)instructMeasure.X),
                        MoonVars.RenderHeight / 4 * 3
                    ),
                    instructFontSize, 1, Color.DARKBLUE
                );

                stars.Draw();

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

            stars.Update();
        }
    }
}
