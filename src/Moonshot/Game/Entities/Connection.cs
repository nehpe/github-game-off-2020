using System.Numerics;
using Raylib_cs;

namespace Moonshot.Game.Entities
{
    public class Connection : IEntity
    {
        private readonly Vector2 _targetPos;
        private readonly Vector2 _startPos;
        private readonly EPlanetType _type;

        public Connection(Vector2 targetPos, Vector2 startPos, EPlanetType type)
        {
            _targetPos = targetPos;
            _startPos = startPos;
            _type = type;
        }
        
        public void Draw()
        {
            Raylib.DrawLineBezier(_startPos, _targetPos, 2, Color.WHITE);
        }

        public void Update()
        {
        }
    }
}