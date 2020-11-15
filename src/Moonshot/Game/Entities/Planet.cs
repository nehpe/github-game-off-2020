using System;
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

        public Planet(int x, int y, int size)
        {
            this.pos = new Vector2(x, y);
            this.size = size;

            this.health = GameState.Rand.Next(this.size / 2, this.size * 2);
        }

        public void Draw()
        {
            Raylib.DrawCircle((int)pos.X, (int)pos.Y, size, Color.DARKGRAY);
            Raylib.DrawText(this.health.ToString(), (int)pos.X - (2 * this.health.ToString().Length), (int)pos.Y - 4, 6, Color.GRAY);
            if (selected)
                Raylib.DrawCircleLines((int)pos.X, (int)pos.Y, size + 2, Color.LIGHTGRAY);
        }

        public void Update()
        {

        }
    }
}
