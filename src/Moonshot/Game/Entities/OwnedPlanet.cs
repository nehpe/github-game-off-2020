using System.Numerics;
using Raylib_cs;

namespace Moonshot.Game.Entities
{
    public class OwnedPlanet : IEntity
    {
        public Vector2 Position;
        private int Size;
        public readonly EPlanetType Type;

        public bool Selected = false;

        public OwnedPlanet(int x, int y, int size, EPlanetType type)
        {
            this.Position = new Vector2(x, y);
            this.Size = size;
            this.Type = type;
        }

        public void Draw()
        {
            Raylib.DrawCircle(
                (int) Position.X,
                (int) Position.Y,
                Size,
                this.GetColor()
            );

            if (Selected)
                Raylib.DrawCircleLines(
                    (int) Position.X,
                    (int) Position.Y,
                    Size + 2,
                    this.GetHighlightColor()
                );
        }

        private Color GetColor()
        {
            if (this.Type == EPlanetType.Fuel)
            {
                return Color.GREEN;
            }
            else
            {
                return Color.GRAY;
            }
        }

        private Color GetHighlightColor()
        {
            if (this.Type == EPlanetType.Fuel)
            {
                return Color.LIME;
            }
            else
            {
                return Color.LIGHTGRAY;
            }
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