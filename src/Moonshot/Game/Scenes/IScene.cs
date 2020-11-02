using Raylib_cs;

namespace Moonshot.Game.Scenes
{
    public interface IScene
    {
        void Update();
        void Draw(RenderTexture2D target);
    }
}
