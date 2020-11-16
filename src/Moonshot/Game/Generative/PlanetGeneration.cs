using System.Collections.Generic;
using Moonshot.Game.Entities;

namespace Moonshot.Game.Generative
{
    public class PlanetGeneration
    {
        static PlanetGeneration()
        {
        }

        public static List<Planet> Generate()
        {
            List<Planet> planets = new List<Planet>();

            for (var i = 0; i < 14; i++)
            {
                planets.Add(
                    new Planet(
                        GameState.Rand.Next((int)MoonVars.mapMinimum.X, (int)MoonVars.mapMaximum.X),
                        GameState.Rand.Next((int)MoonVars.mapMinimum.Y, (int)MoonVars.mapMaximum.Y),
                        i + 5
                    )
                );
            }

            return planets;
        }
    }
}
