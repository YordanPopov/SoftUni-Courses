namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Database _database;
        private Person _person;
        private Person[] _initialData;

        [SetUp]
        public void SetUp()
        {
            this._initialData = new Person[]
            {
                new Person(0001, "Tester1"),
                new Person(0002, "Tester2"),
                new Person(0003, "Tester3"),
                new Person(0004, "Tester4"),
                new Person(0005, "Tester5"),
                new Person(0006, "Tester6")
            };

            this._database = new Database(_initialData);    
        }

        [Test]
        public void Test_Person_Constructor()
        {
            // Arrange
            this._person = new Person(00112233, "Tester1");

            // Assert
            Assert.IsNotNull(this._person);
            Assert.That(this._person.Id, Is.EqualTo(00112233));
            Assert.That(this._person.UserName, Is.EqualTo("Tester1"));
        }

        [Test]
        public void Test_Database_Constructor()
        {
            // Arrange
            this._person = new Person(0001, "Tester1");

            // Act
            this._database = new Database(_person);

            // Assert
            Assert.IsNotNull(this._database);
            Assert.That(this._database, Has.Count.EqualTo(1));
            Assert.That(this._database.Count, Is.EqualTo(1));
        }

        [Test]
        public void Test_Database_Constructor_Add_More_Than_Sixteen_Elements_Should_Return_ArgumentException()
        {
            // Arrange
            Person[] data = new Person[]
            {
                new Person(0001, "Tester1"),
                new Person(0002, "Tester2"),
                new Person(0003, "Tester3"),
                new Person(0004, "Tester4"),
                new Person(0005, "Tester5"),
                new Person(0006, "Tester6"),
                new Person(0007, "Tester7"),
                new Person(0008, "Tester8"),
                new Person(0009, "Tester9"),
                new Person(0010, "Tester10"),
                new Person(0011, "Tester11"),
                new Person(0012, "Tester12"),
                new Person(0013, "Tester13"),
                new Person(0014, "Tester14"),
                new Person(0015, "Tester15"),
                new Person(0016, "Tester16"),
                new Person(0018, "Tester17"),
            };

            // Act
            void GetArgumentException()
            {
                this._database = new Database(data);
            }

            // Assert
            Assert.That(() => GetArgumentException(), Throws.ArgumentException.With.Message.EqualTo("Provided data length should be in range [0..16]!"));
        }

        [Test]
        public void Test_Database_Add_Method_Should_Add_Person()
        {
            // Arrange
            this._person = new Person(1111, "Tester");

            // Act
            this._database.Add(_person);

            // Assert
            Assert.That(this._database, Has.Count.EqualTo(7));
            Assert.That(this._database.Count, Is.EqualTo(7));
        }

        [Test]
        public void Test_Database_Add_Method_Adding_Seventeenth_Person_Should_Return_InvalidOperationException()
        {
            // Arrange
            Person[] data = new Person[]
            {
                new Person(0001, "Tester1"),
                new Person(0002, "Tester2"),
                new Person(0003, "Tester3"),
                new Person(0004, "Tester4"),
                new Person(0005, "Tester5"),
                new Person(0006, "Tester6"),
                new Person(0007, "Tester7"),
                new Person(0008, "Tester8"),
                new Person(0009, "Tester9"),
                new Person(0010, "Tester10"),
                new Person(0011, "Tester11"),
                new Person(0012, "Tester12"),
                new Person(0013, "Tester13"),
                new Person(0014, "Tester14"),
                new Person(0015, "Tester15"),
                new Person(0016, "Tester16"),
            };

            this._database = new Database(data);
            this._person = new Person(1111, "Tester");

            // Act && Assert
            Assert.That(() => this._database.Add(this._person), Throws.InvalidOperationException.With.Message.EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        [Test]
        public void Test_Database_Add_Method_Adding_Person_With_Existing_Name_Should_Return_InvalidOperationException()
        {
            // Arrange
            this._person = new Person(0007, "Tester2");

            // Act && Assert
            Assert.That(() => this._database.Add(this._person), Throws.InvalidOperationException.With.Message.EqualTo("There is already user with this username!"));
        }

        [Test]
        public void Test_Database_Add_Method_Adding_Person_With_Existing_ID_Should_Return_InvaliOperationException()
        {
            // Arrange
            this._person = new Person(0002, "Tester7");

            // Act && Assert
            Assert.That(() => this._database.Add(this._person), Throws.InvalidOperationException.With.Message.EqualTo("There is already user with this Id!"));
        }

        [Test]
        public void Test_Database_Remove_Method()
        {
            // Act
            this._database.Remove();

            // Assert
            Assert.That(this._database, Has.Count.EqualTo(5));
            Assert.That(this._database.Count, Is.EqualTo(5));
        }
        [Test]
        public void Test_Database_Remove_Method_Empty_Database_Should_Return_InvalidOperationException()
        {
            // Arrange
            this._database = new Database();

            // Act && Assert
            Assert.Throws<InvalidOperationException>(() => this._database.Remove());
        }

        [Test]
        public void Test_Database_FindByUsername_Method_Should_Return_User_With_Existing_Name()
        {
            // Arrange  
            this._database = new Database(_initialData);

            // Act
            Person result = this._database.FindByUsername("Tester5");

            // Assert
            Assert.That(result.UserName, Is.EqualTo("Tester5"));
            Assert.That(result.Id, Is.EqualTo(0005));
        }

        [Test]
        public void Test_Database_FindByUsername_Method_Non_Existent_Username_Should_Return_InvalidOperationException()
        {
            // Act && Assert
            Assert.That(() => this._database.FindByUsername("Tester"), Throws.InvalidOperationException.With.Message.EqualTo("No user is present by this username!"));
        }

        [Test]
        public void Test_Database_FindByUsername_Method_Null_Username_Should_Return_ArgumentNullException()
        {
            // Arrange
            string name = null;

            // Act && Assert
            Assert.That(() => this._database.FindByUsername(name), Throws.ArgumentNullException);
        }

        [Test]
        public void Test_Database_FindById_Method_Should_Return_User_With_Existing_Id()
        {
            // Act
            Person result = this._database.FindById(0005);

            // Assert
            Assert.That(result.UserName, Is.EqualTo("Tester5"));
            Assert.That(result.Id, Is.EqualTo(0005));
        }

        [Test]
        public void Test_Database_FindById_Method_No_User_With_This_Id_Should_Return_InvalidOperationException()
        {
            // Act && Assert
            Assert.That(() => this._database.FindById(0000), Throws.InvalidOperationException);
        }

        [Test]
        public void Test_Database_FindById_Method_Negative_Id_Should_Return_ArgumentOutOfRangeException()
        {
            // Act && Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => this._database.FindById(-1));
        }
    }
}