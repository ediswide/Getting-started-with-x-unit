namespace GameEngine.Tests
{
    using System;

    public class GameStateFixture : IDisposable
    {
        public GameState State { get; }

        public GameStateFixture()
        {
            State = new();
        }

        public void Dispose()
        {
            // Cleanup
        }
    }
}
