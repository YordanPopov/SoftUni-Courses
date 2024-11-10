using RestSharpServices;

namespace TrelloApiTests
{
    public class Tests
    {
        private TrelloApiClient client;
        private static string baseUrl = "https://api.trello.com";
        private static string apiKey = "key";
        private static string apiToken = "token";
        private static string lastCreatedBoardId;
        private static string toDoListId;
        private static string uniqueListId;
        private static string cardId;

        [SetUp]
        public void Setup()
        {
            this.client = new TrelloApiClient(baseUrl, apiKey, apiToken);
        }

        [TearDown]
        public async Task Teardown()
        {
            await Task.Delay(0);
        }

        [Test, Order(10)]
        public void Test_GetAllBoards()
        {
            var boards = client.GetAllBoards();

            Assert.That(boards, Has.Count.EqualTo(0), "Board's count should be 0.");
        }

        [Test, Order(1)]
        public void Test_CreateBoard()
        {
            string boarName = "TestBoard";

            var board = client.CreateBoard(boarName);

            Assert.That(board.Name, Is.Not.Empty, "Board Name should not be empty.");
            Assert.That(board.Id, Is.Not.Empty, "Board ID should not be empty.");
            Assert.That(board.Closed, Is.False, "Board Closed should be false.");

            lastCreatedBoardId = board.Id;
        }

        [Test, Order(9)]
        public void Test_DeleteBoard()
        {
            bool result = client.DeleteBoard(lastCreatedBoardId);

            Assert.IsTrue(result, "Result should be true.");
        }

        [Test, Order(2)]
        public void Test_GetSingleBoard()
        {
            var board = client.GetSingleBoard(lastCreatedBoardId);

            Assert.That(board.Name, Is.Not.Empty, "Board Name should not be empty.");
            Assert.That(board.Id, Is.Not.Empty, "Board ID should not be empty.");
            Assert.That(board.Closed, Is.False, "Board closed should be false.");
        }

        [Test, Order(3)]
        public void Test_CreateToDoList()
        {
            var list = client.CreateToDoList(lastCreatedBoardId);

            Assert.That(list.Id, Is.Not.Empty, "List ID should not be empty.");
            Assert.That(list.Name, Is.EqualTo("To Do"), "List name should match the requested name.");
            Assert.That(list.IdBoard, Is.EqualTo(lastCreatedBoardId), "List IDboard should match last created board ID.");
            Assert.That(list.Closed, Is.False, "List closed should be false.");

            toDoListId = list.Id;
        }

        [Test, Order(4)]
        public void Test_CreateUniqueList()
        {
            var list = client.CreateUniqueList(lastCreatedBoardId);

            Assert.That(list.Id, Is.Not.Empty, "List ID should not be empty.");
            Assert.That(list.IdBoard, Is.EqualTo(lastCreatedBoardId), "List IDboard should match last created board ID.");
            Assert.That(list.Closed, Is.False, "List closed should be false.");
            Assert.That(list.Name, Is.Not.Empty, "List Name should not be empty.");
            StringAssert.Contains("List-", list.Name, "List name should match random generated name.");

            uniqueListId = list.Id;
        }

        [Test, Order(5)]
        public void Test_GetAllLists()
        {
            var lists = client.GetAllLists(lastCreatedBoardId);

            Assert.That(lists.Count, Is.GreaterThan(0));

            foreach (var list in lists)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(list.Id, Is.Not.Empty, "List ID should not be empty.");
                    Assert.That(list.IdBoard, Is.EqualTo(lastCreatedBoardId), "List IDboard should match last created board ID.");
                    Assert.That(list.Closed, Is.False, "List Closed should be false.");
                });
            }
        }

        [Test, Order(6)]
        public void Test_CreateNewCard()
        {
            var card = client.CreateNewCard(toDoListId);

            Assert.That(card.Id, Is.Not.Empty, "Card ID should not be empty.");
            Assert.That(card.Name, Is.Not.Empty, "Card Name should not be empty.");
            Assert.That(card.Name, Is.EqualTo("Sign-up for Trello"), "Card Name should match the requested card name.");
            Assert.That(card.IdBoard, Is.Not.Empty, "Card IDboard should not be empty.");
            Assert.That(card.IdBoard, Is.EqualTo(lastCreatedBoardId), "Card IDboard should match last created bord ID.");
            Assert.That(card.IdList, Is.Not.Empty, "Card IDlist should not be empty.");
            Assert.That(card.IdList, Is.EqualTo(toDoListId), "Card IDlist should match To Do list ID.");

            cardId = card.Id;
        }

        [Test, Order(7)]
        public void Test_MoveCardToUniqueList() 
        {
            var card = client.MoveCardToUniqueList(cardId, uniqueListId);

            Assert.That(card.Id, Is.Not.Empty, "Card ID should not be empty.");
            Assert.That(card.IdList, Is.EqualTo(uniqueListId), "Card IDlist should match unique list ID.");
            Assert.That(card.IdBoard, Is.EqualTo(lastCreatedBoardId), "Card IDboard should match last created board ID.");
        }

        [Test, Order(8)]
        public void Test_DeleteCard()
        {
            bool result = client.DeleteCard(cardId);

            Assert.IsTrue(result, "The result should be true.");
        }
    }
}