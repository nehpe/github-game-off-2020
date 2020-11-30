using System.Numerics;
using Moonshot.Game.Entities;
using Moonshot.Game.Generative;
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

        StarBackground bg;

        Stars stars;

        public LogoScene(MoonshotGame g)
        {
            this.g = g;

            loadAssets();

            font = AssetManager.GetFont("jupiter_crash");

            textMeasure = Raylib.MeasureTextEx(font, "nehpe", fontSize, 1);

            //TODO(np): colors should maybe be static / globally available
            bgColor = new Color(36, 36, 36, 255);
            fgColor = new Color(196, 196, 196, 255);
            //fgColor = Color.DARKBLUE;

            bg = new StarBackground();

            stars = new Stars();
        }

        private void loadAssets()
        {
            AssetManager.AddFont("jupiter_crash", Raylib.LoadFont("Resources/Fonts/jupiter_crash.png"));
            AssetManager.AddFont("pixantiqua", Raylib.LoadFont("Resources/Fonts/pixantiqua.png"));
            AssetManager.AddFont("alpha_beta", Raylib.LoadFont("Resources/Fonts/alpha_beta.png"));

            AssetManager.AddSound("placeHome", Raylib.LoadSound("Resources/Sounds/Home_Place.wav"));
            AssetManager.AddSound("connectionCreate", Raylib.LoadSound("Resources/Sounds/Create_Connection.wav"));
            AssetManager.AddSound("shipLaunch", Raylib.LoadSound("Resources/Sounds/Ship_Launch.wav"));
            AssetManager.AddSound("shipDestroy", Raylib.LoadSound("Resources/Sounds/Ship_Destroy.wav"));
        }

        public void Draw(RenderTexture2D target)
        {
            Raylib.BeginDrawing();
            {
                Raylib.BeginTextureMode(target);

                Raylib.ClearBackground(bgColor);

                stars.Draw();

                Raylib.DrawTextEx(font, "nehpe",
                    new Vector2(
                        Text.Center(MoonVars.RenderWidth, (int)textMeasure.X),
                        Text.Center(MoonVars.RenderHeight, (int)textMeasure.Y)
                    ),
                    fontSize, 1, fgColor);

                Raylib.EndTextureMode();
            }
            Raylib.EndDrawing();
        }

        public void Update()
        {
            stars.Update();

            if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
            {
                g.NextScene(new MenuScene(this.g));
            }
        }
    }
}
