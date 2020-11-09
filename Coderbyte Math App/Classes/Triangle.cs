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
        public string TriangleType { get; set; } // TODO: implement check so only "Equilateral", "Isosceles", and "Scalene" are accepted
        public double SideA { get; set; }
        public double SideB { get; set; }
        public double SideC { get; set; }

        public void CalculatePerimeter()
        {
            Perimeter = SideA + SideB + SideC;
        }

        public void CalculateSurfaceArea()
        {
            /** Heron's Formula:
             *  s = Perimeter / 2
             *  Area = sqrt(s(s-a)(s-b)(s-c))
             */
            if (Perimeter == 0) CalculatePerimeter();
            
            double s = Perimeter / 2;

            SurfaceArea = Math.Sqrt(s * (s - SideA) * (s - SideB) * (s - SideC));
        }

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
    }
}
