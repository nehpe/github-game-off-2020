using Moonshot.Game.Entities;
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moonshot.Game.Scenes
{
    public class PlayScene : IScene
    {
        MoonshotGame g;
        List<IEntity> Entities = new List<IEntity>();

        public PlayScene(MoonshotGame g)
        {
            this.g = g;
            _init();
        }

        private void _init()
        {
            Entities.Add(new Planet(50, 50, 10));
            Entities.Add(new Planet(150, 150, 20));
            Entities.Add(new Planet(25, 100, 7));
        }

        public void Draw(RenderTexture2D target)
        {
            Raylib.BeginDrawing();
            {
                Raylib.BeginTextureMode(target);

                Raylib.ClearBackground(new Color(36, 36, 36, 255));

                _draw();

                Raylib.EndTextureMode();
            }
            Raylib.EndDrawing();
        }

        private void _draw()
        {
            foreach (IEntity e in Entities)
            {
                e.Draw();
            }
        }

        public void Update()
        {
            foreach (IEntity e in Entities)
            {
                e.Update();
            }
        }
    }
}
