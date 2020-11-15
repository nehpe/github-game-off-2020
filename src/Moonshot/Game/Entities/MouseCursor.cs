using System;
using System.Numerics;
using Raylib_cs;

namespace Moonshot.Game.Entities
{
    public class MouseCursor : IEntity
    {
        Texture2D texture;
        public Vector2 Position;

        public MouseCursor()
        {
            Color col = Color.MAGENTA;
            Color[] c = new Color[4 * 4];
            c[0] = col;
            c[3] = col;
            c[12] = col;
            c[15] = col;

            var img = Raylib.LoadImageEx(c, 4, 4);

            texture = Raylib.LoadTextureFromImage(img);

            Position = Vector2.Zero;
        }

        public void Draw()
        {
            Raylib.DrawTexture(texture,
                    (int)Position.X-2,
                    (int)Position.Y-2,
                    Color.WHITE);
        }

        public void Update()
        {
            var mousePos = Raylib.GetMousePosition();

            var normalizedMousePos = mousePos / MoonVars.RenderScale;

            Position = normalizedMousePos;

        }
    }
}
