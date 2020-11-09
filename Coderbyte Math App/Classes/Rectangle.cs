using Coderbyte_Math_App.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coderbyte_Math_App.Classes
{
    class Rectangle : IQuadrilateral
    {
        public string Name { get; set; }
        public double Perimeter { get; set; }
        public double SurfaceArea { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }

        /// <summary>
        /// Class <c>Rectangle</c> models a rectangle in a two-dimensional plane.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="length"></param>
        /// <param name="width"></param>
        public Rectangle(string name, double length, double width)
        {
            Name = name;
            Length = length;
            Width = width;

            CalculatePerimeter();
            CalculateSurfaceArea();
        }

        /// <summary>
        /// Method <c>CalculatePerimeter</c> calculates the perimeter of our rectangle. (P = (L + W) * 2)
        /// </summary>
        public void CalculatePerimeter()
        {
            Perimeter = (Length + Width) * 2;
        }

        /// <summary>
        /// Method <c>CalculateSurfaceArea</c> calculates the surface area of our rectangle. (A = L * W)
        /// </summary>
        public void CalculateSurfaceArea()
        {
            SurfaceArea = Length * Width;
        }
    }
}
