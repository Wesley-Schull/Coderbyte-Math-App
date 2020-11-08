using System;
using System.Collections.Generic;
using System.Text;

namespace Coderbyte_Math_App.Interfaces
{
    interface IShape
    {
        public string Name { get; set; }
        public float Perimeter { get; set; }
        public float SurfaceArea { get; set; }

        int CalculatePerimeter();
        int CalculateSurfaceArea();
    }
}
