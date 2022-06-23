namespace GameEngine.Tests
{
    using System;
    using Xunit;
    using Xunit.Abstractions;

    public class PlayerCharacterShould : IDisposable
    {
        private readonly ITestOutputHelper _output;

        private readonly PlayerCharacter _sut;

        public PlayerCharacterShould(ITestOutputHelper output)
        {
            _output = output;
            _output.WriteLine("Creating new PlayerCharacter");

            _sut = new();
        }

        #region Boolean Asserts

        [Fact]
        public void BeInexperiencedWhenNew()
        {
            _output.WriteLine("Player boolean test started");

            Assert.True(_sut.IsNoob);
            _output.WriteLine("Player boolean test finished");
        }

        #endregion

        #region String Asserts

        [Fact]
        public void CalculateFullName()
        {
            _sut.FirstName = "Sarah";
            _sut.LastName = "Smith";

            Assert.Equal("Sarah Smith", _sut.FullName);
        }

        [Fact]
        public void HaveFullNameStartingWithFirstName()
        {
            _sut.FirstName = "Sarah";
            _sut.LastName = "Smith";

            Assert.StartsWith("Sarah", _sut.FullName);
        }

        [Fact]
        public void HaveFullNameEndingWithLastName()
        {
            _sut.FirstName = "Sarah";
            _sut.LastName = "Smith";

            Assert.EndsWith("Smith", _sut.FullName);
        }

        [Fact]
        public void CalculateFullName_IgnoreCaseAssertExample()
        {
            PlayerCharacter sut = new PlayerCharacter();

            sut.FirstName = "SARAH";
            sut.LastName = "SMITH";

            Assert.Equal("Sarah Smith", sut.FullName, ignoreCase: true);
        }

        [Fact]
        public void CalculateFullName_SubstringAssertExample()
        {
            _sut.FirstName = "Sarah";
            _sut.LastName = "Smith";

            Assert.Contains("ah Sm", _sut.FullName);
        }

        [Fact]
        public void CalculateFullNameWithTitleCase()
        {
            _sut.FirstName = "Sarah";
            _sut.LastName = "Smith";

            Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", _sut.FullName);
        }

        #endregion

        #region Numeric Asserts

        [Fact]
        public void StartWithDefaultHealth()
        {
            Assert.Equal(100, _sut.Health);
        }

        [Fact]
        public void StartWithDefaultHealth_NotEqualExample()
        {
            Assert.NotEqual(0, _sut.Health);
        }

        [Fact]
        public void IncreaseHealthAfterSleeping()
        {
            _sut.Sleep();

            Assert.InRange(_sut.Health, 101, 200);
        }

        #endregion

        #region Null Asserts

        [Fact]
        public void NotHaveNickNameByDefault()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.Null(sut.Nickname);
        }

        #endregion

        #region Collection Asserts

        [Fact]
        public void HaveALongBow()
        {
            Assert.Contains("Long Bow", _sut.Weapons);
        }

        [Fact]
        public void NotHaveAStaffOfWonder()
        {
            Assert.DoesNotContain("Staff of Wonder", _sut.Weapons);
        }

        [Fact]
        public void HaveAtLeastOneKindOfSword()
        {
            PlayerCharacter sut = new();

            Assert.Contains(sut.Weapons, weapon => weapon.Contains("Sword"));
        }

        [Fact]
        public void HaveAllExpectedWeapons()
        {
            var expectedWeapons = new[]
            {
                "Long Bow",
                "Short Bow",
                "Short Sword",
            };

            Assert.Equal(expectedWeapons, _sut.Weapons);
        }

        [Fact]
        public void HaveNoEmptyDefaultWeapons()
        {
            Assert.All(_sut.Weapons, weapon => Assert.False(string.IsNullOrWhiteSpace(weapon)));
        }

        #endregion

        #region Events Raised Asserts

        [Fact]
        public void RaiseSleptEvent()
        {
            Assert.Raises<EventArgs>(
                handler => _sut.PlayerSlept += handler,
                handler => _sut.PlayerSlept -= handler,
                () => _sut.Sleep());
        }

        [Fact]
        public void RaisePropertyChangedEvent()
        {
            Assert.PropertyChanged(_sut, "Health", () => _sut.TakeDamage(10));
        }

        #endregion

        #region Data Driven Tests

        [Fact]
        public void TakeZeroDamage()
        {
            _sut.TakeDamage(0);

            Assert.Equal(100, _sut.Health);
        }

        [Fact]
        [Trait("Category (to refactor)", "Data Driven Tests")]
        public void TakeSmallDamage()
        {
            _sut.TakeDamage(1);

            Assert.Equal(99, _sut.Health);
        }

        [Fact]
        [Trait("Category (to refactor)", "Data Driven Tests")]
        public void TakeMediumDamage()
        {
            _sut.TakeDamage(50);

            Assert.Equal(50, _sut.Health);
        }

        [Fact]
        [Trait("Category (to refactor)", "Data Driven Tests")]
        public void HaveMinimumHealth()
        {
            _sut.TakeDamage(101);

            Assert.Equal(1, _sut.Health);
        }

        #endregion

        public void Dispose()
        {
            _output.WriteLine($"Disposing PlayerCharacter {_sut.FullName}");
        }
    }
}
