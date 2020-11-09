﻿using Coderbyte_Math_App.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coderbyte_Math_App.Classes
{
    public class Square : IQuadrilateral
    {
        public string Name { get; set; }
        public double Perimeter { get; set; }
        public double SurfaceArea { get; set; }
        public double Length { get; set; }

        /// <summary>
        /// Class <c>Square</c> models a square in a two-dimensional plane.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="length"></param>
        public Square(string name, double length)
        {
            Name = name;
            Length = length;

            CalculatePerimeter();
            CalculateSurfaceArea();
        }

        /// <summary>
        /// Method <c>CalculatePerimeter</c> will calculate the 
        /// perimeter given the Square already has a Length. (P = L * 4)
        /// </summary>
        public void CalculatePerimeter()
        {
            Perimeter = Length * 4;
        }

        /// <summary>
        /// Method <c>CalculateSurfaceArea</c> will calculate the 
        /// surface area given the Square already has a Length. (A = P^2)
        /// </summary>
        public void CalculateSurfaceArea()
        {
            SurfaceArea = Length * Length;
        }
    }
}