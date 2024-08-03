using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private Axe _axe;
        private Axe _axeBroken;
        int health = 10;
        int experience = 10;

        [SetUp]
        public void SetUp()
        {
            this._axe = new(10, 10);
            this._axeBroken = new(10, 0);
        }

        [Test]
        public void Test_If_Weapon_Loses_Durability_After_Attack()
        {
            // Arrange
            Dummy dummy = new Dummy(health, experience);

            // Act
            this._axe.Attack(dummy);

            // Assert
            Assert.That(this._axe.DurabilityPoints, Is.EqualTo(9), "Axe Durability doesn't change after attack.");
        }
        [Test]
        public void Test_Attacking_With_ABroken_Weapon()
        {
            // Arrange
            Dummy dummy = new Dummy(health, experience);

            // Act && Assert
            Assert.That(() => this._axeBroken.Attack(dummy), Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."));
            
        }
    }
}