using System.Numerics;
using Raylib_cs;

namespace Moonshot.Game.Entities
{
    public class Connection : IEntity
    {
        private readonly Vector2 _targetPos;
        private readonly Vector2 _startPos;
        private readonly EPlanetType _type;

        private float timer = 0f;
        private float maxTimer = 10f;
        private float speed = 5f;
        private float flashing = 0f;

        public Connection(Vector2 targetPos, Vector2 startPos, EPlanetType type)
        {
            _targetPos = targetPos;
            _startPos = startPos;
            _type = type;
        }

        public void Draw()
        {
            Raylib.DrawLineBezier(_startPos, _targetPos, 2, (flashing > 0 ? Color.GOLD : Color.WHITE));
        }

        public void Update()
        {
            timer += Raylib.GetFrameTime() * speed;
            if (flashing > 0f) flashing -= Raylib.GetFrameTime() * speed;

            if (timer > maxTimer)
            {
                AddResources();
                flashing = 1f;
                timer = 0;
            }
        }

        private void AddResources()
        {
            if (_type == EPlanetType.Fuel)
            {
                GameState.Fuel += 2;
            }
            else
            {
                GameState.Metal += 1;
            }
        }
    }
}