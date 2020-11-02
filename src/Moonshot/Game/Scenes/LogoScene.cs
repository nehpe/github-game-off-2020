using System.Numerics;
using Moonshot.Utilities;
using Raylib_cs;

namespace Moonshot.Game.Scenes
{
    public class LogoScene : IScene
    {
        MoonshotGame g;

        Vector2 textMeasure;
        int fontSize = 20;
        Font font;
        Color bgColor;
        Color fgColor;

        public LogoScene(MoonshotGame g)
        {
            this.g = g;

            loadAssets();

            textMeasure = Raylib.MeasureTextEx(font, "nehpe", fontSize, 1);

            bgColor = new Color(36, 36, 36, 255);
            fgColor = new Color(196, 196, 196, 255);
        }

        private void loadAssets()
        {
            AssetManager.AddFont("jupiter_crash", Raylib.LoadFont("Resources/Fonts/jupiter_crash.png"));

            font = AssetManager.GetFont("jupiter_crash");
        }

        public void Draw(RenderTexture2D target)
        {
            Raylib.BeginDrawing();
            {
                Raylib.BeginTextureMode(target);

                Raylib.ClearBackground(bgColor);

                Raylib.DrawTextEx(font, "nehpe", new Vector2(0, 0), fontSize, 1, fgColor);

                Raylib.EndTextureMode();
            }
            Raylib.EndDrawing();
        }

        public void Update()
        {
        }
    }
}
