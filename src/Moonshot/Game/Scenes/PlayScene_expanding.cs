using System;
using Nehpenthe;
using Moonshot.Game.Entities;
using Raylib_cs;

namespace Moonshot.Game.Scenes
{
    public partial class PlayScene
    {
        private void drawExpandingCamera()
        {
            foreach (IEntity e in Entities)
            {
                e.Draw();
            }
        }

        private void drawExpandingUI()
        {
        }

        private void checkForHover()
        {
            var worldPos = MouseUtil.ScreenToWorldPosition(Raylib.GetMousePosition() / MoonVars.RenderScale, camera);
            Planet p;

            foreach (IEntity e in Entities)
            {
                if (e is Planet)
                {
                    p = (Planet)e;

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
        }

        private void checkForAttack()
        {
            if (!Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
                return;

            Console.WriteLine("Checking for attack");
            Planet p;

            //TODO mousepos needs to be changes to screen pos
            var worldPos = MouseUtil.ScreenToWorldPosition(Raylib.GetMousePosition() / MoonVars.RenderScale, camera);
            Console.WriteLine(worldPos);
            foreach (IEntity e in Entities)
            {

                if (e is Planet)
                {
                    p = (Planet)e;

                    if (p.Collides(worldPos))
                    {
                        Console.WriteLine("Collided");
                    }
                }

            }
        }
    }
}
