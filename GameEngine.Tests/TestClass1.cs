namespace GameEngine.Tests
{
    using Xunit;
    using Xunit.Abstractions;

    [Collection("GameState collection")]
    public class TestClass1
    {
        private readonly GameStateFixture _gameStateFixture;
        private readonly ITestOutputHelper _output;

        public TestClass1(GameStateFixture gameStateFixture, ITestOutputHelper output)
        {
            _gameStateFixture = gameStateFixture;
            _output = output;
        }

        [Fact]
        public void Test1()
        {
            _output.WriteLine($"GameState ID={this._gameStateFixture.State.Id}");
        }
        
        [Fact]
        public void Test2()
        {
            _output.WriteLine($"GameState ID={this._gameStateFixture.State.Id}");
        }
    }
}
