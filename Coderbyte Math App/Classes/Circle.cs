using Coderbyte_Math_App.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using static Coderbyte_Math_App.Interfaces.IShape;

namespace Coderbyte_Math_App.Classes
{
    class Circle : IShape
    {
        public double Radius { get; set; }
        public string Name { get; set; }
        public double Perimeter { get; set; }
        public double SurfaceArea { get; set; }

        /// <summary>
        /// Class <c>Circle</c> represents a circle in a two-dimensional plane.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="radius"></param>
        public Circle(string name, double radius)
        {
            Name = name;
            Radius = radius;

            CalculatePerimeter();
            CalculateSurfaceArea();
        }

        /// <summary>
        /// Method <c>CalculatePerimeter</c> calculates the circumference of our Circle given the radius. (P = 2 * Pi * R)
        /// </summary>
        public void CalculatePerimeter()
        {
            Perimeter = 2 * 3.14 * Radius;
        }

        /// <summary>
        /// Method <c>CalculateSurfaceArea</c> calculates the surface area of our circle. (A = Pi * R^2)
        /// </summary>
        public void CalculateSurfaceArea()
        {
            SurfaceArea = 3.14 * Radius * Radius;
        }
    }
}
