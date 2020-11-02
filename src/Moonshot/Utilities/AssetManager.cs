using System.Collections.Generic;
using Raylib_cs;

namespace Moonshot.Utilities
{
    public static class AssetManager
    {
        public static Dictionary<string, Font> Fonts = new Dictionary<string, Font>();
        public static Dictionary<string, Texture2D> Textures = new Dictionary<string, Texture2D>();
        public static Dictionary<string, Sound> Sounds = new Dictionary<string, Sound>();

        public static void AddFont(string name, Font font)
        {
            Fonts.Add(name, font);
        }

        public static void AddTexture(string name, Texture2D texture)
        {
            Textures.Add(name, texture);
        }

        public static void AddSound(string name, Sound sound)
        {
            Sounds.Add(name, sound);
        }

        public static Font GetFont(string name)
        {
            return Fonts[name];
        }

        public static Texture2D GetTexture(string name)
        {
            return Textures[name];
        }

        public static Sound GetSound(string name)
        {
            return Sounds[name];
        }
    }
}