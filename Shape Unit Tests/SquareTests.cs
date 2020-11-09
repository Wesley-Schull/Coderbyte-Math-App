using Coderbyte_Math_App.Classes;
using Coderbyte_Math_App.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Shape_Unit_Tests
{
    [TestClass]
    public class SquareTests
    {
        [TestMethod]
        public void Square_CalculatesCorrectPerimeter()
        {
            // Arrange
            double length = 10;
            double expected = 40;

            // Act
            Square testSquare = new Square("Correct Perimeter Rectangle", length);

            // Assert
            double actual = testSquare.Perimeter;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void testRectangle_CalculatesCorrectSurfaceArea()
        {
            // Arrange
            double length = 5.25;
            double expected = 27.56;

            // Act
            Square testSquare = new Square("Correct Surface Area Rectangle", length);

            // Assert
            double actual = testSquare.SurfaceArea;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Circle_MeasurementsCannotBeNonPositive()
        {
            // Arrange
            double length = -500;
            double expected = 0;

            // Act
            Square testSquare = new Square("Non-Positive Measurement Rectangle", length);

            // Assert
            double actual = testSquare.Length;
            Assert.AreEqual(expected, actual);
        }
    }
}
