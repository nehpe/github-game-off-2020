using Moonshot.Game.Entities;
using Moonshot.Utilities;
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace Moonshot.Game.Scenes
{
    public class PlayScene : IScene
    {
        MoonshotGame g;
        List<IEntity> Entities = new List<IEntity>();
        Camera2D camera;
        Cursor cursor;

        Font uiFont;
        int uiFontSize = 12;
        Vector2 uiMeasurement = Vector2.Zero;

        float speed = 50f;

        public PlayScene(MoonshotGame g)
        {
            this.g = g;
            _init();
        }

        private void _init()
        {
            // Create cursor
            cursor = new Cursor();

            // Create camera
            camera = new Camera2D();
            camera.target = cursor.Position;
            camera.offset = new Vector2(MoonVars.RenderWidth / 2, MoonVars.RenderHeight / 2);
            camera.rotation = 0f;
            camera.zoom = 1.0f;

            // Create entities
            Entities.Add(new Planet(50, 50, 10));
            Entities.Add(new Planet(128, 112, 5));
            Entities.Add(new Planet(200, 200, 7));

            // Get uiFont
            uiFont = AssetManager.GetFont("alpha_beta");

            uiMeasurement = Raylib.MeasureTextEx(uiFont, "UI Here", uiFontSize, 1);
        }

        public void Draw(RenderTexture2D target)
        {
            Raylib.BeginDrawing();
            {
                Raylib.BeginTextureMode(target);

                Raylib.ClearBackground(new Color(36, 36, 36, 255));

                Raylib.BeginMode2D(camera);

                _draw();

                Raylib.EndMode2D();

                _drawUI();

                Raylib.EndTextureMode();
            }

            Raylib.EndDrawing();
        }

        private void _drawUI()
        {
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

        private void _draw()
        {
            foreach (IEntity e in Entities)
            {
                e.Draw();
            }
        }

        public void Update()
        {
            _input();
            _updateCamera();
            foreach (IEntity e in Entities)
            {
                e.Update();
            }
        }

        private void _updateCamera()
        {
            camera.offset = new Vector2(MoonVars.RenderWidth / 2, MoonVars.RenderHeight / 2);
            camera.target = cursor.Position;
        }

        private void _input()
        {
            if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
            {
                cursor.Position.X -= speed * Raylib.GetFrameTime();
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
            {
                cursor.Position.X += speed * Raylib.GetFrameTime();
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
            {
                cursor.Position.Y -= speed * Raylib.GetFrameTime();
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
            {
                cursor.Position.Y += speed * Raylib.GetFrameTime();
            }
        }
    }
}
