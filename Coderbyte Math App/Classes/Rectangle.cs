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

        public void CalculatePerimeter()
        {
            Perimeter = (Length * 2) + (Width * 2);
        }

        public void CalculateSurfaceArea()
        {
            SurfaceArea = Length * Width;
        }

        public Rectangle(string name, double length, double width)
        {
            Name = name;
            Length = length;
            Width = width;

            CalculatePerimeter();
            CalculateSurfaceArea();
        }
    }
}
