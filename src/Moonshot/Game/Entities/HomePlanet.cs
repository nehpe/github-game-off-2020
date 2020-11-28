using System.Numerics;
using Raylib_cs;

namespace Moonshot.Game.Entities
{
    public class HomePlanet : IEntity
    {
        //bool selected = false;
        public Vector2 Pos;
        int size;

        public HomePlanet(int x, int y, int size)
        {
            this.Pos = new Vector2(x, y);
            this.size = size;
        }

        public void Draw()
        {
            Raylib.DrawCircle(
                (int)Pos.X,
                (int)Pos.Y,
                size,
                Color.DARKPURPLE
            );

            Raylib.DrawCircleLines(
                (int)Pos.X,
                (int)Pos.Y,
                size + 2,
                Color.PURPLE
            );
        }

        public void Update()
        {
        }
    }
}