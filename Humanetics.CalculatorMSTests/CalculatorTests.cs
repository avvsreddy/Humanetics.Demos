using Humanetics.SimpleCalculator;

namespace Humanetics.CalculatorMSTests
{
    [TestClass]
    public sealed class CalculatorTests
    {
        [TestMethod]
        public void SumTest_WithValidInputs_ReturnsCorrectResult()
        {
            // Arrange
            var target = new Calculator();
            int a = 5;
            int b = 3;
            int expected = 8;

            // Act
            int result = target.Sum(a, b);

            // Assert
            Assert.AreEqual(expected, result);

        }
    }
}
