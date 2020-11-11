using Coderbyte_Math_App.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coderbyte_Math_App.Classes
{
    class Shape : IShape
    {
        public string Name { get; set; }
        public double Perimeter { get; set; }
        public double SurfaceArea { get; set; }

        public void CalculatePerimeter()
        {
            throw new NotImplementedException();
        }

        public void CalculateSurfaceArea()
        {
            throw new NotImplementedException();
        }

        public string ToShapeString()
        {
            throw new NotImplementedException();
        }
    }
}
