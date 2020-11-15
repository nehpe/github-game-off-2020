using System.Numerics;
using System.Reflection;

namespace Moonshot.Game
{
    public static class MoonVars
    {
        // Screen Dims
        public const int RenderWidth = 256;
        public const int RenderHeight = 224;
        public const int RenderScale = 4;

        public const int ScreenWidth = 1024;
        public const int ScreenHeight = 896;
        public const int TargetFPS = 60;

        // Strings
        public static string Version = Assembly.GetEntryAssembly().GetName().Version.ToString();
        public static string Name = "Astrogate";

        public static bool DebugMode = false;

        // Map
        public static Vector2 mapMinimum = new Vector2(128, 112);
        public static Vector2 mapMaximum = new Vector2(512, 512);
    }
}
