using Coderbyte_Math_App.Classes;
using Coderbyte_Math_App.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shape_Unit_Tests
{
    [TestClass]
    public class TriangleTests
    {
        [TestMethod]
        public void Triangle_CalculatesCorrectPerimeter()
        {
            // Arrange
            double a = 3;
            double b = 5;
            double c = 7;
            double expected = 15;

            // Act
            Triangle testTriangle = new Triangle("Perimeter Test Triangle", a, b, c);
            testTriangle.CalculatePerimeter();

            // Assert
            double actual = testTriangle.Perimeter;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Triangle_CalculatesCorrectSurfaceArea()
        {
            // Arrange
            double a = 3;
            double b = 5;
            double c = 7;
            double expected = 6.50;

            // Act
            Triangle testTriangle = new Triangle("Surface Area Test Triangle", a, b, c);
            testTriangle.CalculateSurfaceArea();

            // Assert
            double actual = testTriangle.SurfaceArea;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Triangle_TriangleTypeIsEquilateral()
        {
            // Arrange
            double a = 5;
            double b = 5;
            double c = 5;
            string expected = "Equilateral";

            // Act
            Triangle testTriangle = new Triangle("Equilateral Type Test Triangle", a, b, c);
            testTriangle.CheckTriangleType();

            // Assert
            string actual = testTriangle.TriangleType;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Triangle_TriangleTypeIsIsosceles()
        {
            // Arrange
            double a = 5;
            double b = 5;
            double c = 7;
            string expected = "Isosceles";

            // Act
            Triangle testTriangle = new Triangle("Isosceles Type Test Triangle", a, b, c);
            testTriangle.CheckTriangleType();

            // Assert
            string actual = testTriangle.TriangleType;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Triangle_TriangleTypeIsScalene()
        {
            // Arrange
            double a = 3;
            double b = 5;
            double c = 7;
            string expected = "Scalene";

            // Act
            Triangle testTriangle = new Triangle("Scalene Type Test Triangle", a, b, c);
            testTriangle.CheckTriangleType();

            // Assert
            string actual = testTriangle.TriangleType;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Triangle_TriangleCannotBeImpossible()
        {
            // Arrange
            double a = 3;
            double b = 3;
            double c = 7; // <-- 7 > (3 + 3)
            double expected = 0;

            // Act
            Triangle testTriangle = new Triangle("Impossible Test Triangle", a, b, c);

            // Assert
            double actual = testTriangle.SideA; // If the triangle is impossible, no measurements are set and remain at 0
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Triangle_MeasurementsCannotBeNonPositive()
        {
            // Arrange
            double a = 3;
            double b = 0;
            double c = -2;
            double expected = 0;

            // Act
            Triangle testTriangle = new Triangle("Non-Positive Test Triangle", a, b, c);

            // Assert
            double actual = testTriangle.SideA; // If any measurements are non-positive (x <= 0), no measurements are set and remain at 0
            Assert.AreEqual(expected, actual);
        }
    }
}
