using System.Numerics;
using Moonshot.Game.Entities;
using Moonshot.Game.Generative;
using Raylib_cs;

namespace Moonshot.Game.Scenes
{
    public partial class PlayScene
    {
        private void initPlacement() { }

        private void drawInitialPlacementCamera() { }

        private void drawInitialPlacementUI()
        {
            Raylib.DrawTextEx(
                uiFont, "Place your Home",
                new Vector2(
                    4, 16
                ),
                uiFontSize, 1, Color.DARKPURPLE
            );

            mouseCursor.Draw();
        }

        private void generatePlanets()
        {
            var planets = PlanetGeneration.Generate();

            Entities.AddRange(planets);
        }

        private void placeHome()
        {
            GameState.CurrentPhase = EGamePhase.Expanding;

            Entities.Add(new HomePlanet(
                (int)((camera.target.X - camera.offset.X) + mouseCursor.Position.X),
                (int)((camera.target.Y - camera.offset.Y) + mouseCursor.Position.Y),
                10
            ));
        }

        private void checkForPlacement()
        {
            if (Raylib.IsMouseButtonDown(MouseButton.MOUSE_LEFT_BUTTON))
            {
                placeHome();
                generatePlanets();
            }
        }
    }
}
