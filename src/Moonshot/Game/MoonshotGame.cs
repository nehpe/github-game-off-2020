using System.Numerics;
using Moonshot.Game.Scenes;
using Raylib_cs;

namespace Moonshot.Game
{
    public class MoonshotGame
    {
        IScene scene;
        RenderTexture2D target;

        public MoonshotGame()
        {
            Raylib.InitWindow(MoonVars.ScreenWidth, MoonVars.ScreenHeight, "Moonshot - " + MoonVars.Version);
            //Raylib.SetTargetFPS(MoonVars.TargetFPS);

            this.target = Raylib.LoadRenderTexture(MoonVars.RenderWidth, MoonVars.RenderHeight);
            this.scene = new LogoScene(this);
        }

        public void Run()
        {
            while (!Raylib.WindowShouldClose())
            {
                //Raylib.BeginTextureMode(target);

                //Raylib.ClearBackground(new Color(65, 61, 61, 255));
                //Raylib.DrawCircle(50, 50, 20, Color.RED);
                //Raylib.DrawText("Hello, world!", 12, 12, 20, Color.BLACK);

                //Raylib.EndTextureMode();

                this.scene.Update();

                this.scene.Draw(this.target);

                Raylib.DrawTexturePro(this.target.texture,
                    new Rectangle(0, 0, MoonVars.RenderWidth, -MoonVars.RenderHeight),
                    new Rectangle(0, 0, MoonVars.ScreenWidth, MoonVars.ScreenHeight),
                    new Vector2(0, 0), 0, Color.WHITE
                );
            }
        }

        public void NextScene(IScene scene)
        {
            this.scene = scene;
        }

        ~MoonshotGame()
        {
            Raylib.CloseWindow();
        }
    }
}
