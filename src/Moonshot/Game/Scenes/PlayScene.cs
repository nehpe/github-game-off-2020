using Moonshot.Game.Entities;
using Moonshot.Game.Generative;
using Moonshot.UI;
using Moonshot.Utilities;
using Raylib_cs;
using System.Collections.Generic;
using System.Numerics;

namespace Moonshot.Game.Scenes
{
    public partial class PlayScene : IScene
    {
        MoonshotGame g;
        List<IEntity> Entities = new List<IEntity>();
        Camera2D camera;
        Cursor cursor;

        Font uiFont;
        int uiFontSize = 12;
        Vector2 uiMeasurement = Vector2.Zero;

        float speed = 100f;

        public PlayScene(MoonshotGame g)
        {
            this.g = g;

            init();
            initGlobal();
            initUI();
            initPlacement();
        }

        private void init()
        {
            // Create cursor
            cursor = new Cursor();

            // Create camera
            camera = new Camera2D();
            camera.target = cursor.Position;
            camera.offset = new Vector2(MoonVars.RenderWidth / 2, MoonVars.RenderHeight / 2);
            camera.rotation = 0f;
            camera.zoom = 1.0f;
        }

        public void Draw(RenderTexture2D target)
        {
            Raylib.BeginDrawing();
            {
                Raylib.BeginTextureMode(target);

                Raylib.ClearBackground(new Color(36, 36, 36, 255));

                Raylib.BeginMode2D(camera);

                drawGlobal();
                switch (GameState.CurrentPhase)
                {
                    case EGamePhase.InitialPlacement:
                        drawInitialPlacementCamera();
                        break;
                    case EGamePhase.Expanding:
                        drawExpandingCamera();
                        break;
                }

                Raylib.EndMode2D();

                drawGlobalUI();

                switch (GameState.CurrentPhase)
                {
                    case EGamePhase.InitialPlacement:
                        drawInitialPlacementUI();
                        break;
                }

                Raylib.EndTextureMode();
            }

            Raylib.EndDrawing();
        }

        public void Update()
        {
            input();
            updateCamera();

            updateGlobal();
            foreach (IEntity e in Entities)
            {
                e.Update();
            }

            mouseCursor.Update();

            if (GameState.CurrentPhase == EGamePhase.InitialPlacement)
            {
                checkForPlacement();
            }
        }
    }
}
