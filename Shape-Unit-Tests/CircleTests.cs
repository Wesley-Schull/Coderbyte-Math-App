using Microsoft.VisualStudio.TestTools.UnitTesting;
using Program.Circle;

namespace Shape_Unit_Tests
{
    [TestClass]
    public class CircleTests
    {
        [TestMethod]
        public void Circle_WithValidRadius_HasCorrectPerimeter()
        {
            // Arrange
            Circle testCircle = new Circle("Valid Radius Test Circle", 5);

            // Act

            // Assert
        }
    }
}
