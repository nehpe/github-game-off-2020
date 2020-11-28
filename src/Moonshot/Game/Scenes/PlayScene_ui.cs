using System.Collections.Generic;
using System.Numerics;
using Moonshot.Game.Entities;
using Moonshot.UI;
using Moonshot.Utilities;
using Raylib_cs;

namespace Moonshot.Game.Scenes
{
    public partial class PlayScene
    {
        List<UIEntity> UIElements = new List<UIEntity>();
        MouseCursor mouseCursor;

        Font uiFont;
        int uiFontSize = 12;
        Vector2 uiMeasurement = Vector2.Zero;

        private void InitUi()
        {
            mouseCursor = new MouseCursor();

            //TODO(np): these need to be addressable for later updating
            // Set up UI elements
            int quarterWidth = MoonVars.RenderWidth / 4;
            int elementHeight = 16;
            UIElements.Add(
                new Label(
                    "Ener " + GameState.Energy,
                    new Rectangle(0, 0, quarterWidth, elementHeight),
                    Color.GREEN,
                    (() => "Ener " + GameState.Energy)
                )
            );
            UIElements.Add(
                new Label(
                    "Ship " + GameState.Ships,
                    new Rectangle(quarterWidth, 0, quarterWidth, elementHeight),
                    Color.BLUE,
                    (() => "Ship " + GameState.Ships)
                )
            );
            UIElements.Add(
                new Label(
                    "Fuel " + GameState.Fuel,
                    new Rectangle(quarterWidth * 2, 0, quarterWidth, elementHeight),
                    Color.DARKGREEN,
                    (() => "Fuel " + GameState.Fuel)
                )
            );
            UIElements.Add(
                new Label(
                    "Metl " + GameState.Metal,
                    new Rectangle(quarterWidth * 3, 0, quarterWidth, elementHeight),
                    Color.DARKGRAY,
                    (() => "Metl " + GameState.Metal)
                )
            );

            // Get uiFont
            uiFont = AssetManager.GetFont("alpha_beta");
            uiMeasurement = Raylib.MeasureTextEx(uiFont, "UI Here", uiFontSize, 1);
        }

        private void DrawGlobalUi()
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
                    Text.Center(MoonVars.RenderWidth, (int) uiMeasurement.X),
                    MoonVars.RenderHeight - 18 - Text.Center(25, (int) uiMeasurement.Y)
                ),
                uiFontSize, 1, Color.GRAY
            );
        }

        private void UpdateGlobalUi()
        {
            foreach (UIEntity e in UIElements)
            {
                e.Update();
            }
        }
    }
}