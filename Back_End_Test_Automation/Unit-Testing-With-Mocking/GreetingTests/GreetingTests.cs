using GetGreeting;
using Moq;

namespace GreetingTests
{
    public class GreetingTests
    {
        private Mock<ITimeProvider> mockTimeProvider;
        private GreetingProvider greetingProvider;

        [SetUp]
        public void Setup()
        {
            mockTimeProvider = new Mock<ITimeProvider>();
            greetingProvider = new GreetingProvider(mockTimeProvider.Object);
        }

        [TestCase(5, "Good morning!")]
        [TestCase(8, "Good morning!")]
        [TestCase(11, "Good morning!")]
        [TestCase(12, "Good afternoon!")]
        [TestCase(15, "Good afternoon!")]
        [TestCase(17, "Good afternoon!")]
        [TestCase(18, "Good evening!")]
        [TestCase(20, "Good evening!")]
        [TestCase(21, "Good evening!")]
        [TestCase(22, "Good night!")]
        [TestCase(0, "Good night!")]
        [TestCase(4, "Good night!")]
        public void Greeting_Should_Be_Correct_BasedOnTime(int currentHour, string expectedMessage)
        {
            mockTimeProvider.Setup(tp => tp.GetCurrentTime())
                .Returns(new DateTime(2024, 12, 21, currentHour, 0, 0));

            var result = greetingProvider.GetGreeting();

            Assert.That(result, Is.EqualTo(expectedMessage));
            mockTimeProvider.Verify(tp => tp.GetCurrentTime(), Times.Once);
        }
    }
}