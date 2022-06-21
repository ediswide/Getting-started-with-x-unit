namespace GameEngine.Tests
{
    using System;
    using Xunit;

    [Trait("Category", "Enemy")]
    public class EnemyFactoryShould
    {
        #region Object Types Asserts

        [Fact]
        public void CreateNormalEnemyByDefault()
        {
            EnemyFactory sut = new();

            Enemy enemy = sut.Create("Zombie");

            Assert.IsType<NormalEnemy>(enemy);
        }

        [Fact(Skip = "Don't need to run this")]
        public void CreateNormalEnemyByDefault_NotTypeExample()
        {
            EnemyFactory sut = new();

            Enemy enemy = sut.Create("Zombie");

            Assert.IsNotType<DateTime>(enemy);
        }

        [Fact]
        public void CreateBossEnemy()
        {
            EnemyFactory sut = new();

            Enemy enemy = sut.Create("Zombie King", true);

            Assert.IsType<BossEnemy>(enemy);
        }

        [Fact]
        public void CreateBossEnemy_CastReturnedTypeExample()
        {
            EnemyFactory sut = new();

            Enemy enemy = sut.Create("Zombie King", true);

            // Assert and get cast result
            BossEnemy boss = Assert.IsType<BossEnemy>(enemy);

            // Additional asserts on typed object
            Assert.Equal("Zombie King", boss.Name);
        }

        [Fact]
        public void CreateBossEnemy_AssertAssignableTypes()
        {
            EnemyFactory sut = new();

            Enemy enemy = sut.Create("Zombie King", true);

            Assert.IsType<BossEnemy>(enemy); // Explicit type
            Assert.IsAssignableFrom<Enemy>(enemy); // Derived type
        }

        #endregion

        #region Object Instances Asserts

        [Fact]
        public void CreateSeparateInstances()
        {
            EnemyFactory sut = new();

            Enemy enemy1 = sut.Create("Zombie");
            Enemy enemy2 = sut.Create("Zombie");

            Assert.NotSame(enemy1, enemy2);
        }

        #endregion

        #region Throw Exceptions Asserts

        [Fact]
        public void NotAllowNullName()
        {
            EnemyFactory sut = new();

            Assert.Throws<ArgumentNullException>(() => sut.Create(null));
            Assert.Throws<ArgumentNullException>("name", () => sut.Create(null));
        }

        [Fact]
        public void OnlyAllowKingOrQueenBossEnemies()
        {
            EnemyFactory sut = new();

            EnemyCreationException ex = Assert.Throws<EnemyCreationException>(() => sut.Create("Zombie", true));

            Assert.Equal("Zombie", ex.RequestedEnemyName);
        }

        #endregion
    }
}
