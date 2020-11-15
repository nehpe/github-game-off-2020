namespace Moonshot.Game
{
    public class GameState
    {
        private static bool _gameOver = false;
        public static bool IsGameOver() => _gameOver;

        public static EGamePhase CurrentPhase = EGamePhase.InitialPlacement;

    }
}
