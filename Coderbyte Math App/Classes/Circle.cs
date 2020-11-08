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

        public void CalculatePerimeter()
        {
            Perimeter = Radius * 3.14 * 2;
        }

        public void CalculateSurfaceArea()
        {
            SurfaceArea = 3.14 * Radius * Radius;
        }

        public Circle(string name, double radius)
        {
            Name = name;
            Radius = radius;
            CalculatePerimeter();
            CalculateSurfaceArea();
        }
    }
}
