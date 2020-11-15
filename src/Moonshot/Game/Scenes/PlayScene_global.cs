using System.Collections.Generic;
using System.Numerics;
using Moonshot.Game.Entities;
using Moonshot.Utilities;
using Raylib_cs;

namespace Moonshot.Game.Scenes
{
    public partial class PlayScene
    {
        List<IEntity> GlobalEntities = new List<IEntity>();

        private void initGlobal()
        {
            GlobalEntities.Add(new Stars());
        }

        private void updateCamera()
        {
            camera.offset = new Vector2(MoonVars.RenderWidth / 2, MoonVars.RenderHeight / 2);
            camera.target = cursor.Position;
        }

        private void input()
        {
            if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
            {
                cursor.Position.X -= speed * Raylib.GetFrameTime();
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
            {
                cursor.Position.X += speed * Raylib.GetFrameTime();
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
            {
                cursor.Position.Y -= speed * Raylib.GetFrameTime();
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
            {
                cursor.Position.Y += speed * Raylib.GetFrameTime();
            }

            // Keep within bounds
            cursor.Position.X = MathUtil.Clamp(cursor.Position.X, MoonVars.mapMinimum.X, MoonVars.mapMaximum.X);
            cursor.Position.Y = MathUtil.Clamp(cursor.Position.Y, MoonVars.mapMinimum.Y, MoonVars.mapMaximum.Y);
        }

        private void drawGlobal()
        {
            foreach (IEntity e in GlobalEntities)
            {
                e.Draw();
            }
        }

        private void updateGlobal()
        {
            foreach (IEntity e in GlobalEntities)
            {
                e.Update();
            }
        }
    }
}
