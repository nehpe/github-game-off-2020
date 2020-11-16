using System.Numerics;
using Raylib_cs;

namespace Nehpenthe
{
    public static class MouseUtil
    {
        public static Vector2 ScreenToWorldPosition(Vector2 mousePos, Camera2D cam)
        {
            return new Vector2(
                    (cam.target.X - cam.offset.X) + mousePos.X,
                    (cam.target.Y - cam.offset.Y) + mousePos.Y
            );
        }
    }
}
