using System;
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

        private void checkForAttack()
        {
            if (!Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
                return;

            Console.WriteLine("Checking for attack");
            Planet p;
            foreach (IEntity e in Entities)
            {
                //TODO mousepos needs to be changes to screen pos
                var mousePos = Raylib.GetMousePosition();
                if (e is Planet)
                {
                    p = (Planet)e;

                    if (p.Collides(mousePos))
                    {
                        Console.WriteLine("Collided");
                    }
                }

            }
        }
    }
}
