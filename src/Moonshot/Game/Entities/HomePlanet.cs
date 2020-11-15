using System.Numerics;
using Raylib_cs;

namespace Moonshot.Game.Entities
{
    public class HomePlanet : IEntity
    {
        //bool selected = false;
        Vector2 pos;
        int size;

        public HomePlanet(int x, int y, int size)
        {
            this.pos = new Vector2(x, y);
            this.size = size;
        }

        public void Draw()
        {
            Raylib.DrawCircle(
                (int)pos.X,
                (int)pos.Y,
                size,
                Color.DARKPURPLE
            );

            Raylib.DrawCircleLines(
                (int)pos.X,
                (int)pos.Y,
                size + 2,
                Color.PURPLE
            );
        }

        public void Update()
        {
        }
    }
}
