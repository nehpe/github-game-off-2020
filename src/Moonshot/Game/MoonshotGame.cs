using System.Numerics;
using Raylib_cs;

namespace Moonshot.Game
{
    class MoonshotGame
    {

        RenderTexture2D target;

        public MoonshotGame()
        {
            Raylib.InitWindow(MoonVars.SCREEN_WIDTH, MoonVars.SCREEN_HEIGHT, "Moonshot");
            Raylib.SetTargetFPS(MoonVars.TARGET_FPS);

            this.target = Raylib.LoadRenderTexture(MoonVars.RENDER_WIDTH, MoonVars.RENDER_HEIGHT);
        }

        public void Run()
        {
            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginTextureMode(target);

                Raylib.ClearBackground(new Color(65, 61, 61, 255));
                Raylib.DrawCircle(50, 50, 100, Color.RED);
                Raylib.DrawText("Hello, world!", 12, 12, 20, Color.BLACK);

                Raylib.EndTextureMode();

                Raylib.BeginDrawing();

                Raylib.DrawTexturePro(this.target.texture,
                    new Rectangle(0, 0, MoonVars.RENDER_WIDTH, -MoonVars.RENDER_HEIGHT),
                    new Rectangle(0, 0, MoonVars.SCREEN_WIDTH, MoonVars.SCREEN_HEIGHT),
                    new Vector2(0, 0), 0, Color.WHITE
                );



                Raylib.EndDrawing();
            }
        }

        ~MoonshotGame()
        {
            Raylib.CloseWindow();
        }

    }
}
