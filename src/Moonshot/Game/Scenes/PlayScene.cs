using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moonshot.Game.Scenes
{
    public class PlayScene : IScene
    {
        MoonshotGame g;

        public PlayScene(MoonshotGame g)
        {
            this.g = g;
        }

        public void Draw(RenderTexture2D target)
        {
            Raylib.BeginDrawing();
            {
                Raylib.BeginTextureMode(target);

                Raylib.ClearBackground(new Color(36, 36, 36, 255));

                Raylib.EndTextureMode();
            }
            Raylib.EndDrawing();
        }

        public void Update()
        {
        }
    }
}
