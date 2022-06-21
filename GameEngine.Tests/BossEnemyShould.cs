namespace GameEngine.Tests
{
    using Xunit;
    using Xunit.Abstractions;

    public class BossEnemyShould
    {
        private readonly ITestOutputHelper _output;

        public BossEnemyShould(ITestOutputHelper output)
        {
            _output = output;
        }

        #region Floating Point Values Asserts

        [Fact]
        [Trait("Category", "Boss")]
        public void HaveCorrectPower()
        {
            _output.WriteLine("Creating Boss Enemy");
            BossEnemy sut = new BossEnemy();
            
            Assert.Equal(166.667, sut.SpecialAttackPower, 3);
        }

        #endregion
    }
}
