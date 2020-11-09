using Coderbyte_Math_App.Classes;
using Coderbyte_Math_App.Exceptions;
using Coderbyte_Math_App.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Shape_Unit_Tests
{
    [TestClass]
    public class CollectionTests
    {
        // test shapes
        Circle bigTestCircle = new Circle("Big Circle", 50);
        Circle smallTestCircle = new Circle("Small Circle", 2);
        Square bigTestSquare = new Square("Big Square", 40);
        Square smallTestSquare = new Square("Small Square", 8);
        Rectangle longTestRectangle = new Rectangle("Long Rectangle", 100, 10);
        Rectangle wideTestRectangle = new Rectangle("Wide Rectangle", 5, 25);
        Triangle equilateralTestTriangle = new Triangle("Equilateral Triangle", 10, 10, 10);
        Triangle isoscelesTestTriangle = new Triangle("Isosceles Triangle", 10, 15, 10);
        Triangle scaleneTestTriangle = new Triangle("Scalene Triangle", 10, 15, 20);


        [TestMethod]
        public void Collection_CanStoreAnyTypeOfShape()
        {
            // Arrange
            Collection testCollection = new Collection("Shape Storage Test Collection");
            double expected = 12.56;

            // Act
            testCollection.ListOfShapes.AddRange(new List<IShape>()
            {
                smallTestCircle,
                bigTestCircle,
                bigTestSquare,
                smallTestSquare,
                longTestRectangle,
                wideTestRectangle,
                equilateralTestTriangle,
                isoscelesTestTriangle,
                scaleneTestTriangle
            });

            // Assert
            double actual = testCollection.ListOfShapes[0].Perimeter;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Collection_SortByPerimeterAscendingWorks()
        {
            // Arrange
            Collection testCollection = new Collection("Ascending Perimeter Sort Test Collection");
            string expected = "Small Circle";
            testCollection.ListOfShapes.AddRange(new List<IShape>()
            {
                bigTestCircle,
                smallTestCircle,
                bigTestSquare,
                smallTestSquare,
                longTestRectangle,
                wideTestRectangle,
                equilateralTestTriangle,
                isoscelesTestTriangle,
                scaleneTestTriangle
            });

            // Act
            testCollection.SortByPerimeter(false);

            // Assert
            string actual = testCollection.ListOfShapes[0].Name;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Collection_SortByPerimeterDescendingWorks()
        {
            // Arrange
            Collection testCollection = new Collection("Descending Perimeter Sort Test Collection");
            string expected = "Big Circle";
            testCollection.ListOfShapes.AddRange(new List<IShape>()
            {
                bigTestCircle,
                smallTestCircle,
                bigTestSquare,
                smallTestSquare,
                longTestRectangle,
                wideTestRectangle,
                equilateralTestTriangle,
                isoscelesTestTriangle,
                scaleneTestTriangle
            });

            // Act
            testCollection.SortByPerimeter(true);

            // Assert
            string actual = testCollection.ListOfShapes[0].Name;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Collection_SortBySurfaceAreaAscendingWorks()
        {
            // Arrange
            Collection testCollection = new Collection("Ascending Surface Area Sort Test Collection");
            string expected = "Small Circle";
            testCollection.ListOfShapes.AddRange(new List<IShape>()
            {
                bigTestCircle,
                smallTestCircle,
                bigTestSquare,
                smallTestSquare,
                longTestRectangle,
                wideTestRectangle,
                equilateralTestTriangle,
                isoscelesTestTriangle,
                scaleneTestTriangle
            });

            // Act
            testCollection.SortByPerimeter(false);

            // Assert
            string actual = testCollection.ListOfShapes[0].Name;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Collection_SortBySurfaceAreaDescendingWorks()
        {
            // Arrange
            Collection testCollection = new Collection("Descending Surface Area Sort Test Collection");
            string expected = "Big Circle";
            testCollection.ListOfShapes.AddRange(new List<IShape>()
            {
                bigTestCircle,
                smallTestCircle,
                bigTestSquare,
                smallTestSquare,
                longTestRectangle,
                wideTestRectangle,
                equilateralTestTriangle,
                isoscelesTestTriangle,
                scaleneTestTriangle
            });

            // Act
            testCollection.SortByPerimeter(true);

            // Assert
            string actual = testCollection.ListOfShapes[0].Name;
            Assert.AreEqual(expected, actual);
        }
    }
}
