using Coderbyte_Math_App.Exceptions;
using Coderbyte_Math_App.Interfaces;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using static Coderbyte_Math_App.Interfaces.IShape;

namespace Coderbyte_Math_App.Classes
{
    public class Circle : IShape
    {
        public double Radius { get; set; }
        public string Name { get; set; }
        public double Perimeter { get; set; }
        public double SurfaceArea { get; set; }

        /// <summary>
        /// Class <c>Circle</c> represents a circle in a two-dimensional plane.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="radius"></param>
        public Circle(string name, double radius)
        {
            Name = name;

            try
            {
                if (radius <= 0) 
                {
                    throw new InvalidMeasurementException("Measurements must be greater than 0.");
                }
                else
                {
                    Radius = radius;
                }
            } 
            catch (Exception e)
            {
                Console.WriteLine("Input Error: {0}", e.Message);
            }

            CalculatePerimeter();
            CalculateSurfaceArea();
        }

        /// <summary>
        /// Method <c>CalculatePerimeter</c> calculates the circumference of our Circle given the radius. (P = 2 * Pi * R)
        /// </summary>
        public void CalculatePerimeter()
        {
            Perimeter = Math.Round((2 * 3.14 * Radius), 2);
        }

        /// <summary>
        /// Method <c>CalculateSurfaceArea</c> calculates the surface area of our circle. (A = Pi * R^2)
        /// </summary>
        public void CalculateSurfaceArea()
        {
            SurfaceArea = Math.Round((3.14 * Radius * Radius), 2);
        }

        /// <summary>
        /// Method <c>ToShapeString</c> will return a string containing the Name, Radius,
        /// Circumference (Perimeter), and Surface Area in a readable format.
        /// </summary>
        /// <returns></returns>
        public string ToShapeString()
        {
            return ($"Circle Name: {Name} | Radius: {Radius} | Circumference: {Perimeter} | Surface Area: {SurfaceArea}"); 
        }
    }
}
