using System;
using System.Collections.Generic;

namespace Moonshot.Game.Entities
{
    public class Stars : IEntity
    {
        public List<Star> stars = new List<Star>();

        Random rnd;

        public Stars()
        {
            rnd = new Random();

            // Generate Stars Here
            for (var i = 0; i < 128; i++)
            {
                stars.Add(
                    new Star(
                        rnd.Next((int)MoonVars.mapMaximum.X),
                        rnd.Next((int)MoonVars.mapMaximum.X),
                        (float)rnd.NextDouble()
                    )
                );

            }
        }

        public void Draw()
        {
            foreach (IEntity e in stars)
            {
                e.Draw();
            }
        }

        public void Update()
        {
            foreach (IEntity e in stars)
            {
                e.Update();
            }
        }
    }

}
