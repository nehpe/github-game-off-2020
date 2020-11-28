using System.Collections.Generic;
using System.Numerics;
using Moonshot.Game.Entities;
using Moonshot.Game.Generative;
using Nehpenthe;
using Raylib_cs;

namespace Moonshot.Game.Scenes
{
    public partial class PlayScene
    {
        private void InitPlacement() { }

        private void DrawInitialPlacementCamera() { }

        private void DrawInitialPlacementUi()
        {
            Raylib.DrawTextEx(
                _uiFont, "Place your Home",
                new Vector2(
                    4, 16
                ),
                UiFontSize, 1, Color.DARKPURPLE
            );
            _mouseCursor.Draw();
        }

        private void GeneratePlanets()
        {
            List<Planet> planets = PlanetGeneration.Generate();
            Entities.AddRange(planets);
        }

        private void PlaceHome()
        {
            GameState.CurrentPhase = EGamePhase.Expanding;

            Vector2i worldPos = new Vector2i(MouseUtil.ScreenToWorldPosition(_mouseCursor.Position, _camera));

            Entities.Add(new HomePlanet(
                worldPos.X,
                worldPos.Y,
                10
            ));
        }

        private void CheckForPlacement()
        {
            if (!Raylib.IsMouseButtonDown(MouseButton.MOUSE_LEFT_BUTTON)) return;
            
            PlaceHome();
            GeneratePlanets();
        }
    }
}
