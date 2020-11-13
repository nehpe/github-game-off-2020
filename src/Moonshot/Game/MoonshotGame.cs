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
            Raylib.SetExitKey(KeyboardKey.KEY_Q);

            this.target = Raylib.LoadRenderTexture(MoonVars.RenderWidth, MoonVars.RenderHeight);
            this.scene = new LogoScene(this);
        }

        public void Run()
        {
            while (!Raylib.WindowShouldClose())
            {
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
