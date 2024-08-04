using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TestApp.Tests
{
    [TestFixture]
    public class HotelGuestSystemTests
    {
        HotelGuestSystem _guestSystem;

        [SetUp]
        public void SetUp()
        {
            this._guestSystem = new HotelGuestSystem();
        }
        [Test]
        public void Test_Constructor_CheckInitialEmptyGuestCollectionAndCount()
        {
            // Act
            List<string> actualResult = this._guestSystem.GetAllGuests();

            // Assert
            Assert.That(actualResult, Has.Count.EqualTo(0));
            Assert.That(actualResult, Is.Empty);
            Assert.That(_guestSystem.GuestsCount, Is.EqualTo(0));
            

        }

        [Test]
        public void Test_RegisterGuest_ValidGuestName_AddNewGuest()
        {
            // Arrange
            this._guestSystem.RegisterGuest("Tester1");

            // Act
            List<string> actualResult = this._guestSystem.GetAllGuests();

            // Assert
            Assert.That(actualResult, Has.Count.EqualTo(1));
            Assert.That(actualResult[0], Is.EqualTo("Tester1"));
        }

        [Test]
        public void Test_RegisterGuest_NullOrEmptyGuestName_ThrowsArgumentException()
        {
            // Arrange
            string guestName = string.Empty;
            string guestName2 = null;
            string guestName3 = "    ";

            // Act && Assert
            Assert.That(() => this._guestSystem.RegisterGuest(guestName), Throws.ArgumentException.With.Message.EqualTo("Guest name cannot be empty or whitespace."));
            Assert.That(() => this._guestSystem.RegisterGuest(guestName2), Throws.ArgumentException.With.Message.EqualTo("Guest name cannot be empty or whitespace."));
            Assert.That(() => this._guestSystem.RegisterGuest(guestName3), Throws.ArgumentException.With.Message.EqualTo("Guest name cannot be empty or whitespace."));
        }

        [Test]
        public void Test_RemoveGuest_ValidGuestName_RemoveFirstGuestName()
        {
            // Arrange
            this._guestSystem.RegisterGuest("Tester1");

            this._guestSystem.RemoveGuest("Tester1");

            // Act
            List<string> actualResult = this._guestSystem.GetAllGuests();

            // Assert
            Assert.That(actualResult, Has.Count.EqualTo(0));
            Assert.That(actualResult, Is.Empty);
            
        }

        [Test]
        public void Test_RemoveGuest_NullOrEmptyGuestName_ThrowsArgumentException()
        {
            // Arrange
            string guest1 = "Tester";
            string guest2 = string.Empty;
            string guest3 = null;

            // Act && Assert
            Assert.That(() => this._guestSystem.RemoveGuest(guest1), Throws.ArgumentException.With.Message.EqualTo("Guest not found in the system."));
            Assert.That(() => this._guestSystem.RemoveGuest(guest2), Throws.ArgumentException.With.Message.EqualTo("Guest not found in the system."));
            Assert.That(() => this._guestSystem.RemoveGuest(guest3), Throws.ArgumentException.With.Message.EqualTo("Guest not found in the system."));
        }
            
        [Test]
        public void Test_GetAllGuests_RegisteredAndRemovedGuests_ReturnsExpectedGuestCollection()
        {
            // Arrange
            this._guestSystem.RegisterGuest("Tester1");
            this._guestSystem.RegisterGuest("Tester2");
            this._guestSystem.RegisterGuest("Tester3");

            this._guestSystem.RemoveGuest("Tester1");

            // Act
            List<string> actualResult = this._guestSystem.GetAllGuests();

            // Assert
            Assert.That(actualResult, Has.Count.EqualTo(2));
            Assert.That(actualResult[0], Is.EqualTo("Tester2"));
            Assert.That(actualResult[1], Is.EqualTo("Tester3"));
        }
    }
}

