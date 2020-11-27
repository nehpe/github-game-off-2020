using System.Numerics;
using Raylib_cs;

namespace Moonshot.Game.Entities
{
    public class Planet : IEntity
    {
        public bool Selected = false;
        public Vector2 Pos;
        int size;
        int health;
        EPlanetType type;

        public Planet(int x, int y, int size)
        {
            this.Pos = new Vector2(x, y);
            this.size = size;

            this.health = GameState.Rand.Next(this.size / 2, this.size * 2);

            this.type = (GameState.Rand.Next(4) >= 2 ? EPlanetType.Fuel : EPlanetType.Metal);
        }

        public void Draw()
        {
            Raylib.DrawCircle((int)Pos.X, (int)Pos.Y, size, this.GetColor());
            Raylib.DrawText(this.health.ToString(), (int)Pos.X - (2 * this.health.ToString().Length), (int)Pos.Y - 4, 6, this.GetHighlightColor());
            if (Selected)
                Raylib.DrawCircleLines((int)Pos.X, (int)Pos.Y, size + 2, this.GetHighlightColor());
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

        public void Hit()
        {
            health--;
        }

        public void Update()
        {

        }

        public bool Collides(Vector2 mousePos)
        {
            return Raylib.CheckCollisionPointCircle(mousePos, Pos, size);
        }
    }
}
