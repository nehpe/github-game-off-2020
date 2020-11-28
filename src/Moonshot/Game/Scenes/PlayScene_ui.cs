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
        private readonly List<UIEntity> _uiElements = new List<UIEntity>();
        private Font _uiFont;
        private const int UiFontSize = 12;
        private Vector2 _uiMeasurement = Vector2.Zero;
        private MouseCursor _mouseCursor;

        private void InitUi()
        {
            _mouseCursor = new MouseCursor();

            // Set up UI elements
            const int quarterWidth = MoonVars.RenderWidth / 4;
            const int elementHeight = 16;
            
            _uiElements.Add(
                new Label(
                    "Ship " + GameState.Ships,
                    new Rectangle(0, 0, quarterWidth, elementHeight),
                    Color.BLUE,
                    (() => "Ship " + GameState.Ships)
                )
            );
            
            _uiElements.Add(
                new Label(
                    "Fuel " + GameState.Fuel,
                    new Rectangle(quarterWidth * 2, 0, quarterWidth, elementHeight),
                    Color.DARKGREEN,
                    (() => "Fuel " + GameState.Fuel)
                )
            );
            
            _uiElements.Add(
                new Label(
                    "Metl " + GameState.Metal,
                    new Rectangle(quarterWidth * 3, 0, quarterWidth, elementHeight),
                    Color.DARKGRAY,
                    (() => "Metl " + GameState.Metal)
                )
            );

            // Get uiFont
            _uiFont = AssetManager.GetFont("alpha_beta");
            _uiMeasurement = Raylib.MeasureTextEx(_uiFont, "UI Here", UiFontSize, 1);
        }

        private void DrawGlobalUi()
        {
            foreach (UIEntity e in _uiElements)
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
                _uiFont, "UI Here",
                new Vector2(
                    Text.Center(MoonVars.RenderWidth, (int) _uiMeasurement.X),
                    MoonVars.RenderHeight - 18 - Text.Center(25, (int) _uiMeasurement.Y)
                ),
                UiFontSize, 1, Color.GRAY
            );
        }

        private void UpdateGlobalUi()
        {
            foreach (UIEntity e in _uiElements)
            {
                e.Update();
            }
        }
    }
}