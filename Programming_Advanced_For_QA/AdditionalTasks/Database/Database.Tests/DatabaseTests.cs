namespace Database.Tests
{
    using NUnit.Framework;
    using System;
    using System.Security.Cryptography.X509Certificates;

    [TestFixture]
    public class DatabaseTests
    {
        private Database _database; 

        [Test]
        public void Test_Database_Constructor_Return_Array_With_Elements()
        {
            // Act
             this._database = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);

            //Assert
            Assert.That(_database, Has.Count.EqualTo(16));
        }

        [Test]
        public void Test_Database_Count_Field()
        {
            // Act
            this._database = new Database(1, 2, 3);

            // Assert
            Assert.That(_database.Count, Is.EqualTo(3));
        }

        [Test]
        public void Test_Database_Constructor_With_More_Than_Sixteen_Elements_Should_Return_InvalidOperationException()
        {
            // Arrange
            void GetException()
            {
                this._database = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17);
            }

            // Act
            Assert.Throws<InvalidOperationException>(() => GetException());
        }

        [Test]
        public void Test_Database_Add_Method_Add_An_Element_At_The_Next_Free_Cell()
        {
            // Arrange
            this._database = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);

            // Act
            this._database.Add(16);

            // Assert
            Assert.That(_database, Has.Count.EqualTo(16));
            Assert.That(_database.Count, Is.EqualTo(16));
        }

        [Test]
        public void Test_Database_Add_Method_Add_Seventeenth_Element_Should_Return_InvalidOperationException()
        {
            // Arrange
            this._database = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);

            // Act && Assert
            Assert.That(() => this._database.Add(17), Throws.InvalidOperationException.With.Message.EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        [Test]
        public void Test_Database_Remove_Method_Should_Remove_Element_From_Last_Index()
        {
            // Arrange
            this._database = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);

            // Act
            _database.Remove();

            // Assert
            Assert.That(_database, Has.Count.EqualTo(15));
            Assert.That(_database.Count, Is.EqualTo(15));
        }

        [Test]
        public void Test_Database_Remove_Method_With_Empty_Array_Should_Return_InvalidOperationException()
        {
            // Arrange
            this._database = new Database();

            // Act && Assert
            Assert.That(() => _database.Remove(), Throws.InvalidOperationException.With.Message.EqualTo("The collection is empty!"));
        }

        [Test]
        public void Test_Database_Fetch_Method_Should_Return_Elements_As_An_Array()
        {
            // Arrange
            this._database = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);

            int[] expectedResult = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // Act
            int[] actualResult = _database.Fetch();

            // Assert
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }
    }
}
