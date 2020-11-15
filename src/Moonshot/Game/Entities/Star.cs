using System;
using System.Numerics;
using Raylib_cs;

namespace Moonshot.Game.Entities
{
    public class Star : IEntity
    {
        Texture2D texture;
        Vector2 position;
        float opacity = 1f;
        float opacitySpeed = 0.15f;

        public Star(int x, int y, float speed)
        {
            opacitySpeed = speed;

            Color[] c = new Color[5 * 5];
            c[2] = new Color(0, 128, 255, 96);
            c[7] = new Color(0, 128, 255, 192);
            c[10] = new Color(0, 128, 255, 96);
            c[11] = new Color(0, 128, 255, 192);
            c[12] = new Color(0, 128, 254, 255);
            c[13] = new Color(0, 128, 255, 192);
            c[14] = new Color(0, 128, 255, 96);
            c[17] = new Color(0, 128, 255, 192);
            c[22] = new Color(0, 128, 255, 96);

            var img = Raylib.LoadImageEx(c, 5, 5);

            texture = Raylib.LoadTextureFromImage(img);

            position = new Vector2(x, y);
        }

        public void Draw()
        {
            Raylib.DrawTexture(texture, (int)position.X, (int)position.Y, new Color(255, 255, 255, (int)(255 * opacity)));
        }

        public void Update()
        {
            opacity -= opacitySpeed * Raylib.GetFrameTime();


            if (opacity < 0f)
            {
                opacity = 1f;
            }

        }
    }
}
