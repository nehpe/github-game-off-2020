using System;
using System.Numerics;
using Raylib_cs;

namespace Moonshot.Game.Entities
{
    public class Ship : IEntity
    {
        private Planet _target;
        private Vector2 _position;
        private float _speed = 15f;
        private Vector2 _diffVector;

        public bool Destroyed = false;

        public Ship(Vector2 startPos, Planet target)
        {
            _target = target;
            startPos.X += GameState.Rand.Next(-5, 5);
            startPos.Y += GameState.Rand.Next(-5, 5);
            _position = startPos;

            _diffVector = target.Position - startPos;
            _diffVector = Vector2.Normalize(_diffVector);
        }


        public void Draw()
        {
            Raylib.DrawPixel((int)_position.X, (int)_position.Y, Color.GOLD);
        }

        public void Update()
        {
            if (Destroyed) return;

            _position += _diffVector * _speed * Raylib.GetFrameTime();

            if (!_target.Collides(_position)) return;
            Destroyed = true;
            _target.Hit();
        }
    }
}