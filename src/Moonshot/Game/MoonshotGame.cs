using System.Numerics;
using Moonshot.Game.Scenes;
using Raylib_cs;

namespace Moonshot.Game
{
    public class MoonshotGame
    {
        private IScene _scene;
        private readonly RenderTexture2D _target;

        public MoonshotGame()
        {
            Raylib.InitWindow(MoonVars.ScreenWidth, MoonVars.ScreenHeight, "Moonshot - " + MoonVars.Version);
            //Raylib.SetTargetFPS(MoonVars.TargetFPS);
            Raylib.SetExitKey(KeyboardKey.KEY_Q);

            //TODO(n): remove this later
            Raylib.SetWindowPosition(2600, 28);

            this._target = Raylib.LoadRenderTexture(MoonVars.RenderWidth, MoonVars.RenderHeight);
            this._scene = new LogoScene(this);
        }

        public void Run()
        {
            while (!Raylib.WindowShouldClose())
            {
                this._scene.Update();

                this._scene.Draw(this._target);

                Raylib.DrawTexturePro(this._target.texture,
                    new Rectangle(0, 0, MoonVars.RenderWidth, -MoonVars.RenderHeight),
                    new Rectangle(0, 0, MoonVars.ScreenWidth, MoonVars.ScreenHeight),
                    new Vector2(0, 0), 0, Color.WHITE
                );
            }
        }

        public void NextScene(IScene scene)
        {
            this._scene = scene;
        }

        ~MoonshotGame()
        {
            Raylib.CloseWindow();
        }
    }
}
