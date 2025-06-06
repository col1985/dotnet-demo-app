// ConsoleAppPAC.Tests/CalculatorTests.cs
using Xunit;
using ConsoleAppPAC; // This is crucial to access your ConsoleAppPAC's classes

namespace ConsoleAppPAC.Tests
{
    public class CalculatorTests
    {
        [Fact]
        public void Add_ShouldReturnCorrectSum()
        {
            // Arrange
            Calculator calculator = new Calculator();
            int a = 5;
            int b = 3;
            int expected = 8;

            // Act
            int actual = calculator.Add(a, b);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(10, 5, 5)]
        [InlineData(0, 0, 0)]
        [InlineData(-5, -2, -3)]
        public void Subtract_ShouldReturnCorrectDifference(int a, int b, int expected)
        {
            // Arrange
            Calculator calculator = new Calculator();

            // Act
            int actual = calculator.Subtract(a, b);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}