using Coderbyte_Math_App.Classes;
using Coderbyte_Math_App.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Shape_Unit_Tests
{
    [TestClass]
    public class RectangleTests
    {
        [TestMethod]
        public void Rectangle_CalculatesCorrectPerimeter()
        {
            // Arrange
            double length = 10;
            double width = 30;
            double expected = 80;

            // Act
            Rectangle testRectangle = new Rectangle("Correct Perimeter Rectangle", length, width);

            // Assert
            double actual = testRectangle.Perimeter;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void testRectangle_CalculatesCorrectSurfaceArea()
        {
            // Arrange
            double length = 5;
            double width = 10.0001;
            double expected = 50.00;

            // Act
            Rectangle testRectangle = new Rectangle("Correct Surface Area Rectangle", length, width);

            // Assert
            double actual = testRectangle.SurfaceArea;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Circle_MeasurementsCannotBeNonPositive()
        {
            // Arrange
            double length = 0;
            double width = -3;
            double expected = 0;

            // Act
            Rectangle testRectangle = new Rectangle("Non-Positive Measurement Rectangle", length, width);

            // Assert
            double actual = testRectangle.Width;
            Assert.AreEqual(expected, actual);
        }
    }
}
