using Moonshot.Game.Entities;

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
    }
}
