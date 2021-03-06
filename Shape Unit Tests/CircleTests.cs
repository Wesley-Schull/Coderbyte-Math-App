using Coderbyte_Math_App.Classes;
using Coderbyte_Math_App.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Shape_Unit_Tests
{
    [TestClass]
    public class CircleTests
    {
        [TestMethod]
        public void Circle_CalculatesCorrectCircumference()
        {
            // Arrange
            double radius = 10;
            double expected = 62.8;
            Circle testCircle = new Circle("Correct Circumference Circle", radius);

            // Act
            testCircle.CalculatePerimeter();

            // Assert
            double actual = testCircle.Perimeter;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Circle_CalculatesCorrectSurfaceArea()
        {
            // Arrange
            double radius = 5;
            double expected = 78.5;
            Circle testCircle = new Circle("Correct Surface Area Circle", radius);

            // Act
            testCircle.CalculateSurfaceArea();

            // Assert
            double actual = testCircle.SurfaceArea;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Circle_CannotHaveNegativeRadius()
        {
            // Arrange
            double radius = -20;
            double expected = 0;

            // Act
            Circle testCircle = new Circle("Negative Radius Circle", radius);

            // Assert
            double actual = testCircle.Radius;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Circle_ToShapeStringReturnsCorrectInformation()
        {
            // Arrange
            double radius = 10;
            string expected = $"Circle Name: ToShapeString Test Circle | Radius: {radius} | Circumference: 62.8 | Surface Area: 314";

            // Act
            Circle testCircle = new Circle("ToShapeString Test Circle", radius);

            // Assert
            string actual = testCircle.ToShapeString();
            Assert.AreEqual(expected, actual);
        }
    }
}
