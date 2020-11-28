using System.Numerics;
using Raylib_cs;

namespace Moonshot.Game.Entities
{
    public class Planet : IEntity
    {
        public bool Selected = false;
        public Vector2 Position;
        public readonly int Size;
        public int Health;
        public EPlanetType Type;
        public bool Destroyed = false;

        public Planet(int x, int y, int size)
        {
            this.Position = new Vector2(x, y);
            this.Size = size;

            this.Health = GameState.Rand.Next(this.Size / 2, this.Size * 2);
            this.Type = (GameState.Rand.Next(4) >= 2 ? EPlanetType.Fuel : EPlanetType.Metal);
        }

        public void Draw()
        {
            Raylib.DrawCircle((int)Position.X, (int)Position.Y, Size, this.GetColor());
            Raylib.DrawText(this.Health.ToString(), (int)Position.X - (2 * this.Health.ToString().Length), (int)Position.Y - 4, 6, this.GetHighlightColor());
            if (Selected)
                Raylib.DrawCircleLines((int)Position.X, (int)Position.Y, Size + 2, this.GetHighlightColor());
        }

        private Color GetColor()
        {
            if (this.Type == EPlanetType.Metal)
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
            if (this.Type == EPlanetType.Metal)
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
            Health--;
            if (Health == 0)
                Destroyed = true;
        }

        public void Update()
        {
        }

        public bool Collides(Vector2 mousePos)
        {
            return Raylib.CheckCollisionPointCircle(mousePos, Position, Size);
        }
    }
}
