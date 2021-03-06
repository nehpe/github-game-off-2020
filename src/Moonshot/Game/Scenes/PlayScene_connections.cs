using System.Collections.Generic;
using System.Numerics;
using Moonshot.Game.Entities;
using Moonshot.Utilities;
using Nehpenthe;
using Raylib_cs;

namespace Moonshot.Game.Scenes
{
    public partial class PlayScene : IScene
    {
        private List<Connection> _connectedPlanets = new List<Connection>();

        public void UpdateConnections()
        {
            foreach (Connection c in _connectedPlanets)
            {
                c.Update();
            }
        }

        private void CheckForConnection()
        {
            if (!Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
                return;

            Vector2 worldPos = MouseUtil.ScreenToWorldPosition(Raylib.GetMousePosition() / MoonVars.RenderScale, _camera);

            HomePlanet p = GetHomePlanet();
            if (p.Collides(worldPos))
            {
                if (_currentSelection != null) AddConnection(_currentSelection);

                ClearSelection();
                return;
            }
        }

        private void AddConnection(OwnedPlanet op)
        {
            Raylib.PlaySound(AssetManager.GetSound("connectionCreate"));
            HomePlanet hp = GetHomePlanet();
            _connectedPlanets.Add(new Connection(hp.Pos, op.Position, op.Type));
        }

        private void DrawConnections()
        {
            HomePlanet hp = GetHomePlanet();

            foreach (Connection c in _connectedPlanets)
            {
                c.Draw();
            }
        }

        private void BuildShips()
        {
            if (GameState.Fuel >= 10 && GameState.Metal >= 5)
            {
                GameState.Fuel -= 10;
                GameState.Metal -= 5;
                GameState.Ships++;
            }
        }
    }
}