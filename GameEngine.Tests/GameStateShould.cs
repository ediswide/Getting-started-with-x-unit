namespace GameEngine.Tests
{
    using System;
    using Xunit;
    using Xunit.Abstractions;

    public class GameStateShould : IClassFixture<GameStateFixture>
    {
        private readonly ITestOutputHelper _output;
        private readonly GameState _sut;

        public GameStateShould(ITestOutputHelper output, GameStateFixture sut)
        {
            _output = output;
            _sut = sut.State;
        }

        [Fact]
        public void DamageAllPlayersWhenEarthquake()
        {
            _output.WriteLine($"GameState ID={_sut.Id} {DateTime.Now}");
            var player1 = new PlayerCharacter();
            var player2 = new PlayerCharacter();

            _sut.Players.Add(player1);
            _sut.Players.Add(player2);

            var expectedHealthAfterEarthquake = player1.Health - GameState.EarthquakeDamage;

            _sut.Earthquake();

            Assert.Equal(expectedHealthAfterEarthquake, player1.Health);
            Assert.Equal(expectedHealthAfterEarthquake, player2.Health);
        }

        [Fact]
        public void Reset()
        {
            _output.WriteLine($"GameState ID={_sut.Id} {DateTime.Now}");

            var player1 = new PlayerCharacter();
            var player2 = new PlayerCharacter();

            _sut.Players.Add(player1);
            _sut.Players.Add(player2);

            _sut.Reset();

            Assert.Empty(_sut.Players);
        }
    }
}
