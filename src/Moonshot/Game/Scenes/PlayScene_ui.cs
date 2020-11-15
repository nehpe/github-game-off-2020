using System.Collections.Generic;
using Moonshot.UI;
using Raylib_cs;

namespace Moonshot.Game.Scenes
{
    public partial class PlayScene
    {
        List<UIEntity> UIElements = new List<UIEntity>();
        MouseCursor mouseCursor;

        private void initUI()
        {
            mouseCursor = new MouseCursor();

            //TODO(np): these need to be addressable for later updating
            // Set up UI elements
            var quarterWidth = MoonVars.RenderWidth / 4;
            var elementHeight = 16;
            UIElements.Add(new Label("Ener " + GameState.Energy, new Rectangle(0, 0, quarterWidth, elementHeight), Color.GREEN));
            UIElements.Add(new Label("Ship " + GameState.Ships, new Rectangle(quarterWidth, 0, quarterWidth, elementHeight), Color.BLUE));
            UIElements.Add(new Label("Fuel " + GameState.Fuel, new Rectangle(quarterWidth * 2, 0, quarterWidth, elementHeight), Color.DARKGREEN));
            UIElements.Add(new Label("Metl " + GameState.Metal, new Rectangle(quarterWidth * 3, 0, quarterWidth, elementHeight), Color.DARKGRAY));

            // Get uiFont
            uiFont = AssetManager.GetFont("alpha_beta");
            uiMeasurement = Raylib.MeasureTextEx(uiFont, "UI Here", uiFontSize, 1);
        }

        private void drawGlobalUI()
        {
            foreach (UIEntity e in UIElements)
            {
                e.Draw();
            }

            //TODO(np): these should be converted into UI elements
            Raylib.DrawRectangle(
                4, MoonVars.RenderHeight - 29,
                MoonVars.RenderWidth - 8,
                25, Color.DARKGRAY
            );

            Raylib.DrawRectangleLines(
                1, MoonVars.RenderHeight - 32,
                MoonVars.RenderWidth - 2,
                31, Color.DARKGRAY
            );

            Raylib.DrawTextEx(
                uiFont, "UI Here",
                new Vector2(
                    Text.Center(MoonVars.RenderWidth, (int)uiMeasurement.X),
                    MoonVars.RenderHeight - 18 - Text.Center(25, (int)uiMeasurement.Y)
                ),
                uiFontSize, 1, Color.GRAY
            );
        }
    }
}
