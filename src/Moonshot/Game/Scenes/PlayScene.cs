using System;
using Moonshot.Game.Entities;
using Raylib_cs;
using System.Collections.Generic;
using System.Numerics;

namespace Moonshot.Game.Scenes
{
    public partial class PlayScene : IScene
    {
        MoonshotGame g;
        List<IEntity> Entities = new List<IEntity>();
        private Camera2D _camera;
        private Cursor _cursor;

        float speed = 100f;

        public PlayScene(MoonshotGame g)
        {
            this.g = g;

            Init();
            InitGlobal();
            InitUi();
            InitPlacement();
        }

        private void Init()
        {
            // Create cursor
            _cursor = new Cursor();

            // Create camera
            _camera = new Camera2D
            {
                target = _cursor.Position,
                offset = new Vector2(MoonVars.RenderWidth / 2, MoonVars.RenderHeight / 2),
                rotation = 0f,
                zoom = 1.0f
            };
        }

        public void Draw(RenderTexture2D target)
        {
            Raylib.BeginDrawing();
            {
                Raylib.BeginTextureMode(target);

                Raylib.ClearBackground(new Color(36, 36, 36, 255));

                Raylib.BeginMode2D(_camera);

                DrawGlobal();

                switch (GameState.CurrentPhase)
                {
                    case EGamePhase.InitialPlacement:
                        DrawInitialPlacementCamera();
                        break;
                    case EGamePhase.Expanding:
                        DrawExpandingCamera();
                        DrawConnections();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                Raylib.EndMode2D();

                DrawGlobalUi();

                switch (GameState.CurrentPhase)
                {
                    case EGamePhase.InitialPlacement:
                        DrawInitialPlacementUi();
                        break;
                    case EGamePhase.Expanding:
                        DrawExpandingUi();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                Raylib.EndTextureMode();
            }

            Raylib.EndDrawing();
        }

        public void Update()
        {
            Input();
            UpdateCamera();

            UpdateGlobal();
            foreach (IEntity e in Entities)
            {
                e.Update();
            }

            _mouseCursor.Update();

            switch (GameState.CurrentPhase)
            {
                case EGamePhase.InitialPlacement:
                    CheckForPlacement();
                    break;
                case EGamePhase.Expanding:
                    CheckForHover();
                    CheckForAttack();
                    CheckForSelection();
                    CheckForConnection();
                    ReplacePlanets();
                    UpdateGlobalUi();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void AddConnection(OwnedPlanet op)
        {
            HomePlanet hp = GetHomePlanet();
            _connectedPlanets.Add(
                new Connection(
                    hp.Pos, op.Position, op.Type
                    )
                );
        }

        private void DrawConnections()
        {
            HomePlanet hp = GetHomePlanet();
            
            foreach (Connection c in _connectedPlanets)
            {
                c.Draw();
            }
        }
    }
}