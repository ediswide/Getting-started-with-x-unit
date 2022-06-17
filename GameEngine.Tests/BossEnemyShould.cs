namespace GameEngine.Tests
{
    using Xunit;

    public class BossEnemyShould
    {
        #region Floating Point Values Asserts

        [Fact]
        public void HaveCorrectPower()
        {
            BossEnemy sut = new BossEnemy();
            
            Assert.Equal(166.667, sut.SpecialAttackPower, 3);
        }

        #endregion
    }
}
