using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        Dummy _dummyAlive;
        Dummy _dummyDead;
        Axe _axe;

        [SetUp]
        public void SetUp()
        {
            this._dummyAlive = new(10,10);
            this._dummyDead = new(0,10);
             this._axe = new Axe(1, 10);
        }
        [Test]
        public void Test_Alive_Dummy_Lose_Health_If_Attacked()
        {
            // Act
            _axe.Attack(_dummyAlive);

            // Assert
            Assert.That(_dummyAlive.Health, Is.EqualTo(9));
        }

        [Test]
        public void Test_Dead_Dummy_Throws_An_Exceprion_If_Attacked()
        {
            // Act && Assert
            Assert.That(() => _axe.Attack(_dummyDead), Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."));
        }

        [Test]
        public void Test_Dead_Dummy_Can_Give_XP()
        {
            // Arrange
            int expected = 10;

            // Act
            int actual = this._dummyDead.GiveExperience();

            // Assert
            Assert.That(actual, Is.EqualTo(expected));

        }

        [Test]
        public void Test_Alive_Dummy_Cant_Give_XP()
        {
            // Act && Assert
            Assert.That(() => this._dummyAlive.GiveExperience(), Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."));
        }
    }
}