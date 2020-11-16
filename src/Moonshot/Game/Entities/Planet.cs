using System.Numerics;
using Raylib_cs;

namespace Moonshot.Game.Entities
{
    public class Planet : IEntity
    {
        bool selected = false;
        Vector2 pos;
        int size;
        int health;
        EPlanetType type;

        public Planet(int x, int y, int size)
        {
            this.pos = new Vector2(x, y);
            this.size = size;

            this.health = GameState.Rand.Next(this.size / 2, this.size * 2);

            this.type = (GameState.Rand.Next(4) >= 2 ? EPlanetType.Fuel : EPlanetType.Metal);
        }

        public void Draw()
        {
            Raylib.DrawCircle((int)pos.X, (int)pos.Y, size, this.GetColor());
            Raylib.DrawText(this.health.ToString(), (int)pos.X - (2 * this.health.ToString().Length), (int)pos.Y - 4, 6, this.GetHighlightColor());
            if (selected)
                Raylib.DrawCircleLines((int)pos.X, (int)pos.Y, size + 2, this.GetHighlightColor());
        }

        private Color GetColor()
        {
            if (this.type == EPlanetType.Metal)
            {
                return Color.GRAY;
            }
            else
            {
                return Color.GREEN;
            }
        }

        private Color GetHighlightColor()
        {
            if (this.type == EPlanetType.Metal)
            {
                return Color.LIGHTGRAY;
            }
            else
            {
                return Color.LIME;
            }
        }

        public void Update()
        {

        }
    }
}
