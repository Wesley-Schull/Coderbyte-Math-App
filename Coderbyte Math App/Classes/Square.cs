using Coderbyte_Math_App.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coderbyte_Math_App.Classes
{
    class Square : IQuadrilateral
    {
        public string Name { get; set; }
        public double Perimeter { get; set; }
        public double SurfaceArea { get; set; }
        public double Length { get; set; }

        public void CalculatePerimeter()
        {
            Perimeter = Length * 4;
        }

        public void CalculateSurfaceArea()
        {
            SurfaceArea = Length * Length;
        }

        public Square(string name, double length)
        {
            Name = name;
            Length = length;

            CalculatePerimeter();
            CalculateSurfaceArea();
        }
    }
}
