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
        public void Square_CalculatesCorrectSurfaceArea()
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
        public void Square_MeasurementsCannotBeNonPositive()
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

        [TestMethod]
        public void Square_ToShapeStringReturnsCorrectInformation()
        {
            // Arrange
            double length = 10;
            string expected = $"Square Name: ToShapeString Test Square | Length: {length} | Perimeter: 40 | Surface Area: 100";

            // Act
            Square testSquare = new Square("ToShapeString Test Square", length);

            // Assert
            string actual = testSquare.ToShapeString();
            Assert.AreEqual(expected, actual);
        }
    }
}
