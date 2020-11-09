using System;
using System.Collections.Generic;
using System.Text;

namespace Coderbyte_Math_App.Interfaces
{
    public interface IShape
    {
        public string Name { get; set; }
        public double Perimeter { get; set; }
        public double SurfaceArea { get; set; }

        void CalculatePerimeter();
        void CalculateSurfaceArea();
        string ToShapeString();
    }
}
