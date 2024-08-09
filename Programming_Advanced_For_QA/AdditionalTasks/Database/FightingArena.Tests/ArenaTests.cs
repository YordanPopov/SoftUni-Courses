namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class ArenaTests
    {
        private Arena _arena;

        [SetUp]
        public void SetUp()
        {
            this._arena = new Arena();
        }

        [Test]
        public void Test_Arena_Constructor()
        {
            // Assert
            Assert.IsNotNull(this._arena);
            Assert.That(this._arena.Count,Is.EqualTo(0));
            Assert.That(this._arena.Warriors is IReadOnlyCollection<Warrior>);
        }

        [Test]
        public void Test_Arena_Enroll_Method_Add_Warrior_To_Warriors()
        {
            // Arrange
            Warrior warrior1 = new Warrior("Tester1", 100, 100);
            Warrior warrior2 = new Warrior("Tester2", 100, 100);
            Warrior warrior3 = new Warrior("Tester3", 100, 100);

            // Act
            this._arena.Enroll(warrior1);
            this._arena.Enroll(warrior2);
            this._arena.Enroll(warrior3);
            

            // Assert
            Assert.That(this._arena.Warriors.Count, Is.EqualTo(3));
            Assert.That(this._arena.Count, Is.EqualTo(3));
            Assert.That(this._arena.Warriors.ElementAt<Warrior>(0), Is.EqualTo(warrior1));
            Assert.That(this._arena.Warriors.ElementAt<Warrior>(1), Is.EqualTo(warrior2));
            Assert.That(this._arena.Warriors.ElementAt<Warrior>(2), Is.EqualTo(warrior3));  
        }

        [Test]
        public void Test_Arena_Enroll_Method_ExistingName_Return_InvalidOperationException()
        {
            // Arrange
            Warrior warrior1 = new Warrior("Tester1", 100, 100);
            Warrior warrior2 = new Warrior("Tester2", 100, 100);
            Warrior warrior3 = new Warrior("Tester1", 100, 100);

            this._arena.Enroll(warrior1);
            this._arena.Enroll(warrior2);

            // Act && Assert
            Assert.That(() => this._arena.Enroll(warrior3), Throws.InvalidOperationException.With.Message.EqualTo("Warrior is already enrolled for the fights!"));
        }

        [Test]
        public void Test_Arena_Fight_Method()
        {
            // Arrange
            Warrior warrior1 = new Warrior("Tester1", 50, 100);
            Warrior warrior2 = new Warrior("Tester2", 100, 100);
            Warrior warrior3 = new Warrior("Tester3", 20, 100);

            this._arena.Enroll(warrior1);
            this._arena.Enroll(warrior2);
            this._arena.Enroll(warrior3);

            // Act
            this._arena.Fight("Tester1", "Tester3");

            // Assert
            Assert.That(warrior1.HP, Is.EqualTo(80));
            Assert.That(warrior3.HP, Is.EqualTo(50));
        }

        [Test]
        public void Test_Arena_Fight_Method_NoExist_AttackerName()
        {
            // Arrange
            Warrior warrior1 = new Warrior("Tester1", 50, 100);
            Warrior warrior2 = new Warrior("Tester2", 100, 100);
            Warrior warrior3 = new Warrior("Tester3", 20, 100);

            this._arena.Enroll(warrior1);
            this._arena.Enroll(warrior2);
            this._arena.Enroll(warrior3);

            // Act && Assert
            Assert.That(() => this._arena.Fight("invalid", "Tester3"), Throws.InvalidOperationException.With.Message.EqualTo("There is no fighter with name invalid enrolled for the fights!"));
        }

        [Test]
        public void Test_Arena_Fight_Method_NoExist_DefenderName()
        {
            // Arrange
            Warrior warrior1 = new Warrior("Tester1", 50, 100);
            Warrior warrior2 = new Warrior("Tester2", 100, 100);
            Warrior warrior3 = new Warrior("Tester3", 20, 100);

            this._arena.Enroll(warrior1);
            this._arena.Enroll(warrior2);
            this._arena.Enroll(warrior3);

            // Act && Assert
            Assert.That(() => this._arena.Fight("Tester1", "invalid"), Throws.InvalidOperationException.With.Message.EqualTo("There is no fighter with name invalid enrolled for the fights!"));
        }
    }
}
