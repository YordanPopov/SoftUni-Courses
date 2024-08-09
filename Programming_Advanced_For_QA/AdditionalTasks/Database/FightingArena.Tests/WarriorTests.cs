namespace FightingArena.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class WarriorTests
    {
        private Warrior _warrior;

        [Test]
        public void Test_Warrior_Constructor()
        {
            // Arrange
            this._warrior = new Warrior("Tester1", 81, 100);

            // Assert
            Assert.That(this._warrior.Name, Is.EqualTo("Tester1"));
            Assert.That(this._warrior.HP, Is.EqualTo(100));
            Assert.That(this._warrior.Damage, Is.EqualTo(81));
        }

        [Test]
        public void Test_Warrior__EmptyWarriorName_Return_ArgumentException()
        {
            // Arrange
            void GetArgumentException()
            {
                string warriorName = string.Empty;

                this._warrior = new Warrior(warriorName, 81, 100);
            }

            // Act && Assert

            Assert.That(() => GetArgumentException(), Throws.ArgumentException.With.Message.EqualTo("Name should not be empty or whitespace!"));
        }

        [Test]
        public void Test_Warrior__NullWarriorName_Return_ArgumentException()
        {
            // Arrange
            void GetArgumentException()
            {
                string warriorName = null;

                this._warrior = new Warrior(warriorName, 81, 100);
            }

            // Act && Assert

            Assert.That(() => GetArgumentException(), Throws.ArgumentException.With.Message.EqualTo("Name should not be empty or whitespace!"));
        }

        [Test]
        public void Test_Warrior__WhiteSpacesWarriorName_Return_ArgumentException()
        {
            // Arrange
            void GetArgumentException()
            {
                string warriorName = "   ";

                this._warrior = new Warrior(warriorName, 81, 100);
            }

            // Act && Assert

            Assert.That(() => GetArgumentException(), Throws.ArgumentException.With.Message.EqualTo("Name should not be empty or whitespace!"));
        }

        [Test]
        public void Test_Warrior_Constructor_ZeroDemage_Return_ArgumentException()
        {
            // Arrange
            void GetArgumentException()
            {
                int damage = 0;

                this._warrior = new Warrior("Tester", damage, 100);
            }

            // Act && Assert

            Assert.That(() => GetArgumentException(), Throws.ArgumentException.With.Message.EqualTo("Damage value should be positive!"));
        }

        [Test]
        public void Test_Warrior_Constructor_NegativeDemage_Return_ArgumentException()
        {
            // Arrange
            void GetArgumentException()
            {
                int damage = -1;

                this._warrior = new Warrior("Tester", damage, 100);
            }

            // Act && Assert

            Assert.That(() => GetArgumentException(), Throws.ArgumentException.With.Message.EqualTo("Damage value should be positive!"));
        }

        [Test]
        public void Test_Warrior_Constructor_NegativeHP_Return_ArgumentException()
        {
            // Arrange
            void GetArgumentException()
            {
                int hp = -1;

                this._warrior = new Warrior("Tester", 81, hp);
            }

            // Act && Assert

            Assert.That(() => GetArgumentException(), Throws.ArgumentException.With.Message.EqualTo("HP should not be negative!"));
        }

        [Test]
        public void Test_Warrior_Attack_Method_Reduce_Defender_And_Attacker_HP()
        {
            // Arrange
            Warrior attacker = new Warrior("Attacker", 50, 100);
            Warrior defender = new Warrior("Defender", 80, 100);

            // Act
            attacker.Attack(defender);

            // Assert
            Assert.That(defender.HP, Is.EqualTo(50));
            Assert.That(attacker.HP, Is.EqualTo(20));
        }

        [Test]
        public void Test_Warrior_Attack_Method_AttackerDamage_Bigger_Than_DefenderHP_Reduce_HP_To_Zero()
        {
            // Arrange
            Warrior attacker = new Warrior("Attacker", 100, 100);
            Warrior defender = new Warrior("Defender", 20, 90);

            // Act
            attacker.Attack(defender);

            // Assert
            Assert.That(defender.HP, Is.EqualTo(0));
            Assert.That(attacker.HP, Is.EqualTo(80));
        }

        [Test]
        public void Test_Warrior_Attack_Method_AttackerHP_EqualTo_MinAttackHp_Return_InvalidOperationException()
        {
            // Arrange
            Warrior attacker = new Warrior("Attacker", 50, 30);
            Warrior defender = new Warrior("Defender", 80, 100);

            // Act && Assert
            Assert.That(() => attacker.Attack(defender), Throws.InvalidOperationException.With.Message.EqualTo("Your HP is too low in order to attack other warriors!"));
        }

        [Test]
        public void Test_Warrior_Attack_Method_AttackerHP_LessThan_MinAttackHp_Return_InvalidOperationException()
        {
            // Arrange
            Warrior attacker = new Warrior("Attacker", 50, 29);
            Warrior defender = new Warrior("Defender", 80, 100);

            // Act && Assert
            Assert.That(() => attacker.Attack(defender), Throws.InvalidOperationException.With.Message.EqualTo("Your HP is too low in order to attack other warriors!"));
        }

        [Test]
        public void Test_Warrior_Attack_Method_DefenderHP_EqualTo_MinAttackHp_Return_InvalidOperationException()
        {
            // Arrange
            Warrior attacker = new Warrior("Attacker", 50, 100);
            Warrior defender = new Warrior("Defender", 80, 30);

            // Act && Assert
            Assert.That(() => attacker.Attack(defender), Throws.InvalidOperationException.With.Message.EqualTo("Enemy HP must be greater than 30 in order to attack him!"));
        }

        [Test]
        public void Test_Warrior_Attack_Method_DefenderHP_LessThan_MinAttackHp_Return_InvalidOperationException()
        {
            // Arrange
            Warrior attacker = new Warrior("Attacker", 50, 100);
            Warrior defender = new Warrior("Defender", 80, 29);

            // Act && Assert
            Assert.That(() => attacker.Attack(defender), Throws.InvalidOperationException.With.Message.EqualTo("Enemy HP must be greater than 30 in order to attack him!"));
        }

        [Test]
        public void Test_Warrior_Attack_Method_AttackerHp_LessThan_DefenderDamage_Return_InvalidOperationException()
        {
            // Arrange
            Warrior attacker = new Warrior("Attacker", 50, 79);
            Warrior defender = new Warrior("Defender", 80, 100);

            // Act && Assert
            Assert.That(() => attacker.Attack(defender), Throws.InvalidOperationException.With.Message.EqualTo("You are trying to attack too strong enemy"));
        }
    }
}