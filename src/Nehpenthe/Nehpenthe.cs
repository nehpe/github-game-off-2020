using System;

namespace Nehpenthe
{
    public class Vector2i
    {
        public int X;
        public int Y;

        public Vector2i()
        {
            this.X = 0;
            this.Y = 0;
        }

        public Vector2i(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public Vector2i(float x, float y)
        {
            this.X = (int)x;
            this.Y = (int)y;
        }

        public static Vector2i ZERO = new Vector2i(0, 0);
    }
}
