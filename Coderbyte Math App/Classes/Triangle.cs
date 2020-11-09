using Coderbyte_Math_App.Interfaces;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace Coderbyte_Math_App.Classes
{
    class Triangle : IShape
    {
        public string Name { get; set; }
        public double Perimeter { get; set; }
        public double SurfaceArea { get; set; }
        public string TriangleType { get; set; } 
        public double SideA { get; set; }
        public double SideB { get; set; }
        public double SideC { get; set; }

        /// <summary>
        /// Class <c>Triangle</c> models a triangle in a two-dimensional plane.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        public Triangle(string name, double a, double b, double c)
        {
            Name = name;
            SideA = a;
            SideB = b;
            SideC = c;

            CheckTriangleType();
            CalculatePerimeter();
            CalculateSurfaceArea();
        }

        /// <summary>
        /// Method <c>CalculatePerimeter</c> calculates the perimeter of our input triangle. (a + b + c)
        /// </summary>
        public void CalculatePerimeter()
        {
            Perimeter = SideA + SideB + SideC;
        }

        /// <summary>
        /// Method <c>CalculateSurfaceArea</c> calculates the surface area using Heron's Formula. In the formula, s = 1/2 the triangle's perimeter.
        /// <br/>s = (a + b + c)/2 
        /// <br/>A = sqrt(s(s - a)(s - b)(s - c))
        /// </summary>
        public void CalculateSurfaceArea()
        {
            if (Perimeter == 0) CalculatePerimeter();
            
            double s = Perimeter / 2;

            SurfaceArea = Math.Sqrt(s * (s - SideA) * (s - SideB) * (s - SideC));
        }

        /// <summary>
        /// Method <c>CheckTriangleType</c> checks which sides are (or aren't) equal to one another to determine if the triangle is equilateral, isosceles, or scalene.
        /// </summary>
        private void CheckTriangleType()
        {
            if (SideA == SideB && SideB == SideC)
            {
                TriangleType = "Equilateral";
            } else if (SideA == SideB || SideB == SideC || SideC == SideA)
            {
                TriangleType = "Isosceles";
            } else
            {
                TriangleType = "Scalene";
            }
        }
    }
}
