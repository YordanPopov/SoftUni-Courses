using NUnit.Framework;
using Moq;
using ItemManagementApp.Services;
using ItemManagementLib.Repositories;
using ItemManagementLib.Models;
using System.Collections.Generic;
using System.Linq;
using Castle.Components.DictionaryAdapter.Xml;

namespace ItemManagement.Tests
{
    [TestFixture]
    public class ItemServiceTests
    {
        // Field to hold the mock repository and the service being tested
        private ItemService _service;
        private Mock<IItemRepository> _mockItemRepository;

        [SetUp]
        public void Setup()
        {
            // Arrange: Create a mock instance of IItemRepository
            _mockItemRepository = new Mock<IItemRepository>();

            // Instantiate ItemService with the mocked repository
            _service = new ItemService(_mockItemRepository.Object);
            
        }

        [Test]
        public void AddItem_ShouldCallAddItemOnRepository()
        {
            string itemName = "SampleItem";

            _mockItemRepository.Setup(r => r.AddItem(It.IsAny<Item>()));

            _service.AddItem(itemName);

            _mockItemRepository.Verify(r => r.AddItem(It.IsAny<Item>()), Times.Once());
        }

        [Test]
        public void AddItem_ShouldThrowError_IfNameIsInvalid()
        {
            string invalidItemName = "";
            _mockItemRepository.Setup(r => r.AddItem(It.IsAny<Item>())).Throws<ArgumentException>();

            Assert.Throws<ArgumentException>(() => _service.AddItem(invalidItemName));
            _mockItemRepository.Verify(r => r.AddItem(It.IsAny<Item>()), Times.Once);
        }

        [Test]
        public void GetAllItems_ShouldReturnAllItems()
        {
            var items = new List<Item>()
            {
                new Item { Id = 1, Name = "SampleItem1" },
                new Item { Id = 2, Name = "SampleItem2" }
            };

            _mockItemRepository.Setup(s => s.GetAllItems()).Returns(items);

            var result = _service.GetAllItems();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count(), Is.EqualTo(2));

            var firstItem = result.First();
            Assert.That(firstItem.Name, Is.EqualTo(items[0].Name));
            Assert.That(firstItem.Id, Is.EqualTo(items[0].Id));

            _mockItemRepository.Verify(r => r.GetAllItems(), Times.Once());
        }

        [Test]
        public void UpdateItem_ShouldCallUpdateItemOnRepository()
        {
            var item = new Item { Id = 1, Name = "SampleItem" };

            _mockItemRepository.Setup(r => r.GetItemById(item.Id)).Returns(item);

            _service.UpdateItem(item.Id, "Updated");

            Assert.That(item.Name, Is.EqualTo("Updated"));
            _mockItemRepository.Verify(r => r.GetItemById(item.Id), Times.Once());
        }

        [Test]
        public void UpdateItem_ShouldNotCallUpdateItemOnRepository_IfIdDoesNotExists()
        {
            var nonExistentId = 1;

            _mockItemRepository.Setup(r => r.GetItemById(nonExistentId)).Returns<Item>(null);
            _mockItemRepository.Setup(r => r.UpdateItem(It.IsAny<Item>()));

            _service.UpdateItem(nonExistentId, "newName");

            _mockItemRepository.Verify(r => r.GetItemById(nonExistentId), Times.Once());
            _mockItemRepository.Verify(r => r.UpdateItem(It.IsAny<Item>()), Times.Never());
        }
        [Test]
        public void DeleteItem_ShouldCallDeleteItemOnRepository()
        {
            _mockItemRepository.Setup(r => r.DeleteItem(It.IsAny<int>()));

            _service.DeleteItem(1);

            _mockItemRepository.Verify(r => r.DeleteItem(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void ValidateItemName_WhenNameIsValid_ShouldReturnTrue()
        {
            string validItemName = "SampleItem";

            var result = _service.ValidateItemName(validItemName);

            Assert.That(result, Is.True);
        }

        [Test]
        public void ValidateItemName_WhenNameIsTooLong_ShouldReturnFalse()
        {
            string validItemName = "SampleItem1";

            var result = _service.ValidateItemName(validItemName);

            Assert.That(result, Is.False);
        }

        [Test]
        public void ValidateItemName_WhenNameIsEmpty_ShouldReturnFalse()
        {
            string validItemName = "";

            var result = _service.ValidateItemName(validItemName);

            Assert.That(result, Is.False);
        }

        [Test]
        public void GetItemById_ShouldReturnItemById_IfItemExists()
        {
            var item = new Item { Id = 1, Name = "SampleItem" };

            _mockItemRepository.Setup(r => r.GetItemById(item.Id)).Returns(item);

            var returnedItem = _service.GetItemById(item.Id);

            Assert.That(returnedItem, Is.Not.Null);
            Assert.That(returnedItem.Name, Is.EqualTo(item.Name));
            _mockItemRepository.Verify(r => r.GetItemById(item.Id), Times.Once());
        }

        [Test]
        public void GetItemById_ShouldReturnNull_IfItemDoesNotExists()
        {
            _mockItemRepository.Setup(r => r.GetItemById(It.IsAny<int>()))
                               .Returns<Item>(null);

            var result = _service.GetItemById(123);

            Assert.That(result, Is.Null);
            _mockItemRepository.Verify(r => r.GetItemById(It.IsAny<int>()), Times.Once());
        }


    }
}