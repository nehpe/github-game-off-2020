using System.Numerics;
using Moonshot.Utilities;
using Raylib_cs;

namespace Moonshot.UI
{
    public class Label : UIEntity
    {
        string Text;
        Rectangle Box;
        Color Col;
        Font Fon;
        Texture2D Icon;

        public delegate string onUpdate();

        private onUpdate updateFunc;

        public Label(string t, Rectangle r, Color c, onUpdate func)
        {
            this.Text = t;
            this.Box = r;
            this.Col = c;
            this.Fon = AssetManager.GetFont("pixantiqua");
            this.updateFunc = func;

            Image image = Raylib.GenImageColor(8, 8, Color.BLACK);
            this.Icon = Raylib.LoadTextureFromImage(image);
        }

        public void Draw()
        {
            Raylib.DrawRectangle(
                (int)this.Box.x, (int)this.Box.y, (int)this.Box.width, (int)this.Box.height, this.Col
            );

            Raylib.DrawTexture(Icon, (int)Box.x + 4, (int)Box.y + 4, Color.WHITE);

            Raylib.DrawTextEx(
                    Fon, Text,
                    new Vector2(Box.x + 16, Box.y + 2),
                    12, 1, Color.WHITE);
        }

        public void Update()
        {
            this.Text = updateFunc();
        }
    }
}
