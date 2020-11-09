using Coderbyte_Math_App.Exceptions;
using Coderbyte_Math_App.Interfaces;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace Coderbyte_Math_App.Classes
{
    public class Triangle : IShape
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

            try
            {
                if (a >= (b + c) || b >= (a + c) || c >= (a + b))
                {
                    throw new ImpossibleTriangleException("No one side can be longer than both of the other sides on a triangle.");
                }
                else if (a <= 0 || b <= 0 || c <= 0)
                {
                    throw new InvalidMeasurementException("Measurements must be greater than 0.");
                }
                else
                {
                    SideA = a;
                    SideB = b;
                    SideC = c;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Input error: {0}", e.Message);
            }

            CheckTriangleType();
            CalculatePerimeter();
            CalculateSurfaceArea();
        }

        /// <summary>
        /// Method <c>CalculatePerimeter</c> calculates the perimeter of our input triangle. 
        /// <br/>(a + b + c)
        /// </summary>
        public void CalculatePerimeter()
        {
            Perimeter = Math.Round((SideA + SideB + SideC), 2);
        }

        /// <summary>
        /// Method <c>CalculateSurfaceArea</c> calculates the surface area using Heron's Formula.
        /// In the formula, s = 1/2 the triangle's perimeter.
        /// <br/>s = (a + b + c)/2 
        /// <br/>A = sqrt(s(s - a)(s - b)(s - c))
        /// </summary>
        public void CalculateSurfaceArea()
        {
            if (Perimeter == 0) CalculatePerimeter();
            
            double s = Perimeter / 2;

            SurfaceArea = Math.Round(Math.Sqrt(s * (s - SideA) * (s - SideB) * (s - SideC)), 2);
        }

        /// <summary>
        /// Method <c>CheckTriangleType</c> checks which sides are (or aren't) equal to one another
        /// to determine if the triangle is equilateral, isosceles, or scalene.
        /// </summary>
        public void CheckTriangleType()
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

        /// <summary>
        /// Method <c>ToShapeString</c> will return a string containing the Name, sides A, B and C,
        /// Triangle Type, Perimeter, and Surface Area in a readable format.
        /// </summary>
        /// <returns></returns>
        public string ToShapeString()
        {
            return ($"Triangle Name: {Name} | a: {SideA} | b: {SideB} | c: {SideC} | " +
                $"Triangle Type: {TriangleType} | Perimeter: {Perimeter} | Surface Area: {SurfaceArea}");
        }
    }
}
