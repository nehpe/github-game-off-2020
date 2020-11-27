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

        private void InitGlobal()
        {
            GlobalEntities.Add(new Stars());
        }

        private void UpdateCamera()
        {
            _camera.offset = new Vector2(MoonVars.RenderWidth / 2, MoonVars.RenderHeight / 2);
            _camera.target = _cursor.Position;
        }

        private void Input()
        {
            if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
            {
                _cursor.Position.X -= speed * Raylib.GetFrameTime();
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
            {
                _cursor.Position.X += speed * Raylib.GetFrameTime();
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
            {
                _cursor.Position.Y -= speed * Raylib.GetFrameTime();
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
            {
                _cursor.Position.Y += speed * Raylib.GetFrameTime();
            }

            // Keep within bounds
            _cursor.Position.X = MathUtil.Clamp(_cursor.Position.X, MoonVars.mapMinimum.X, MoonVars.mapMaximum.X);
            _cursor.Position.Y = MathUtil.Clamp(_cursor.Position.Y, MoonVars.mapMinimum.Y, MoonVars.mapMaximum.Y);
        }

        private void DrawGlobal()
        {
            foreach (IEntity e in GlobalEntities)
            {
                e.Draw();
            }
        }

        private void UpdateGlobal()
        {
            foreach (IEntity e in GlobalEntities)
            {
                e.Update();
            }
        }
    }
}
