using System;
using System.Collections.Generic;
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
            List<IEntity> toRemove = new List<IEntity>();
            
            foreach (IEntity e in Entities)
            {
                e.Draw();

                if (e is Ship)
                {
                    if (((Ship) e).Destroyed)
                    {
                        toRemove.Add(e);
                    }
                }
            }

            Console.WriteLine(Entities.OfType<Ship>().Count());
            
            RemoveDestroyedShips(toRemove);
        }

        private void RemoveDestroyedShips(List<IEntity> toRemove)
        {
            foreach (IEntity r in toRemove)
            {
                Entities.Remove(r);
            }
        }

        private void ReplacePlanets()
        {
            List<Planet> planetsToRemove = new List<Planet>();
            List<OwnedPlanet> planetsToAdd = new List<OwnedPlanet>();
            
            foreach (Planet p in Entities.OfType<Planet>())
            {
                if (!p.Destroyed) continue;
                planetsToRemove.Add(p);
                planetsToAdd.Add(new OwnedPlanet((int) p.Position.X, (int) p.Position.Y, p.Size, p.Type));
            }

            foreach (Planet p in planetsToRemove)
            {
                Entities.Remove(p);
            }
            Entities.AddRange(planetsToAdd);
        }

        private void DrawExpandingUi()
        {
        }

        private void CheckForHover()
        {
            Vector2 worldPos = MouseUtil.ScreenToWorldPosition(Raylib.GetMousePosition() / MoonVars.RenderScale, _camera);
            foreach (Planet p in Entities.OfType<Planet>())
            {
                p.Selected = p.Collides(worldPos);
            }
        }

        private void CheckForAttack()
        {
            if (!Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
                return;

            Console.WriteLine("Checking for attack");

            Vector2 worldPos = MouseUtil.ScreenToWorldPosition(Raylib.GetMousePosition() / MoonVars.RenderScale, _camera);
            Console.WriteLine(worldPos);
            foreach (Planet p in Entities.OfType<Planet>())
            {
                if (!p.Collides(worldPos)) continue;
                Attack(p);
                return;
            }
        }

        private void Attack(Planet p)
        {
            int shipsToAttack = p.Health > GameState.Ships ? GameState.Ships : p.Health;
            GameState.Ships -= shipsToAttack;

            HomePlanet hp = Entities.OfType<HomePlanet>().First();

            for (int i = 0; i < shipsToAttack; i++)
            {
                Entities.Add(new Ship(hp.Pos, p));
            }
        }
    }
}