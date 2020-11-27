using System;
using System.Linq;
using System.Numerics;
using Nehpenthe;
using Moonshot.Game.Entities;
using Raylib_cs;

namespace Moonshot.Game.Scenes
{
    public partial class PlayScene
    {
        private void DrawExpandingCamera()
        {
            foreach (IEntity e in Entities)
            {
                e.Draw();
            }
        }

        private void DrawExpandingUi()
        {
        }

        private void CheckForHover()
        {
            Vector2 worldPos = MouseUtil.ScreenToWorldPosition(Raylib.GetMousePosition() / MoonVars.RenderScale, _camera);
            foreach (Planet p in Entities.OfType<Planet>())
            {
                if (p.Collides(worldPos))
                {
                    p.selected = true;
                }
                else
                {
                    p.selected = false;
                }
            }
        }

        private void CheckForAttack()
        {
            if (!Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
                return;

            Console.WriteLine("Checking for attack");
            Planet p;

            Vector2 worldPos = MouseUtil.ScreenToWorldPosition(Raylib.GetMousePosition() / MoonVars.RenderScale, _camera);
            Console.WriteLine(worldPos);
            foreach (Planet e in Entities.OfType<Planet>())
            {
                if (e.Collides(worldPos))
                {
                    Console.WriteLine("Collided");
                }
            }
        }
    }
}
