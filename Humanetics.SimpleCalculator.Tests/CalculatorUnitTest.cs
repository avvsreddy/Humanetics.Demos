namespace Humanetics.SimpleCalculator.Tests
{
    public class CalculatorUnitTest
    {
        //[SetUp]
        //public void Setup()
        //{
        //}

        [TestCase(2, 2, 4)] // Test attribute indicates that this method is a test method
        [TestCase(10, 10, 20)]
        //[TestCase(0, 0, 0)]
        //[TestCase(-1, -1, -2)]
        //[TestCase(-1, 1, 0)]
        public void SumTest_WithValidInputs_ReturnsCorrectResult(int a, int b, int expected) // Positive Test Case
        {
            // Simple code
            // No Conditional Logic/statements
            // No Loops
            // No Try-Catch

            // AAA - Arrange, Act, Assert

            // Arrange
            var target = new Calculator();
            //int a = 5;
            //int b = 3;
            //int expected = 8;

            // Act
            int result = target.Sum(a, b);

            // Assert
            //Assert.AreEqual(expected, result);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(-1, -1)]
        [TestCase(0, 0)]
        [TestCase(5, 3)]
        public void SumTest_WithInvalidInputs_ThrowsArgumentException(int a, int b)
        {
            // Arrange
            var target = new Calculator();
            //int a = -1;
            //int b = -1;
            // Act & Assert
            Assert.Throws<ArgumentException>(() => target.Sum(a, b));
        }
    }
}