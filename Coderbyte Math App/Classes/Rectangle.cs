﻿using Coderbyte_Math_App.Exceptions;
using Coderbyte_Math_App.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coderbyte_Math_App.Classes
{
    public class Rectangle : IQuadrilateral
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
            
            try
            {
                if (length <= 0 || width <= 0)
                {
                    throw new InvalidMeasurementException("Measurements must be greater than 0.");
                }
                else
                {
                    Length = length;
                    Width = width;
                }
            } 
            catch (Exception e)
            {
                Console.WriteLine("Input error: {0}", e.Message);
            }

            CalculatePerimeter();
            CalculateSurfaceArea();
        }

        /// <summary>
        /// Method <c>CalculatePerimeter</c> calculates the perimeter of our rectangle. (P = (L + W) * 2)
        /// </summary>
        public void CalculatePerimeter()
        {
            Perimeter = Math.Round(((Length + Width) * 2), 2);
        }

        /// <summary>
        /// Method <c>CalculateSurfaceArea</c> calculates the surface area of our rectangle. (A = L * W)
        /// </summary>
        public void CalculateSurfaceArea()
        {
            SurfaceArea = Math.Round((Length * Width), 2);
        }

        /// <summary>
        /// Method <c>ToShapeString</c> will return a string containing the Name, Length, Width,
        /// Perimeter, and Surface Area in a readable format.
        /// </summary>
        /// <returns></returns>
        public string ToShapeString()
        {
            return ($"Rectangle Name: {Name} | Length: {Length} | Width: {Width} | " +
                $"Perimeter: {Perimeter} | Surface Area: {SurfaceArea}");
        }
    }
}
