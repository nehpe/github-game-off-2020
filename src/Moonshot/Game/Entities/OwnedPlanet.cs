using System.Numerics;
using Raylib_cs;

namespace Moonshot.Game.Entities
{
    public class OwnedPlanet : IEntity
    {
        public Vector2 Position;
        private int Size;
        private readonly EPlanetType _type;
        
        public OwnedPlanet(int x, int y, int size, EPlanetType type)
        {
            this.Position = new Vector2(x, y);
            this.Size = size;
            this._type = type;
        }
        
        public void Draw()
        {
            Raylib.DrawCircle(
                (int) Position.X,
                (int) Position.Y,
                Size, 
                this.GetColor()
            );
            
            Raylib.DrawCircleLines(
                (int) Position.X, 
                (int) Position.Y, 
                Size + 2,
                this.GetHighlightColor()
            );
        }

        private Color GetColor()
        {
            if (this._type == EPlanetType.Fuel)
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
            if (this._type == EPlanetType.Fuel)
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
    }
}