namespace GameEngine
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

    public class GameState
    {
        public static readonly int EarthquakeDamage = 25;
        public List<PlayerCharacter> Players { get; set; } = new();
        public Guid Id { get; } = Guid.NewGuid();

        public GameState()
        {
            CreateGameWorld();
        }

        public void Earthquake()
        {
            foreach (var player in Players)
            {
                player.TakeDamage(EarthquakeDamage);
            }
        }

        public void Reset()
        {
            Players.Clear();
        }

        public void CreateGameWorld()
        {
            // Simulates expensive creation
            Thread.Sleep(2000);
        }
    }
}
