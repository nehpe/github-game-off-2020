using System;

namespace Moonshot.Game
{
    public static class GameState
    {
        private static bool _gameOver = false;
        public static bool IsGameOver() => _gameOver;

        public static EGamePhase CurrentPhase = EGamePhase.InitialPlacement;

        public static readonly Random Rand = new Random();

        public static int Ships = 40;
        public static int Fuel = 0;
        public static int Metal = 0;
    }
}
