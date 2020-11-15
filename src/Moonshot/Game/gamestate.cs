using System;

namespace Moonshot.Game
{
    public class GameState
    {
        private static bool _gameOver = false;
        public static bool IsGameOver() => _gameOver;

        public static EGamePhase CurrentPhase = EGamePhase.InitialPlacement;

        public static Random Rand = new Random();

        public static int Ships = 40;
        public static int Energy = 20;
        public static int Fuel = 25;
        public static int Metal = 25;
    }
}
