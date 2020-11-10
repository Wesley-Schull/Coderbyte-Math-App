using Coderbyte_Math_App.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coderbyte_Math_App.Classes
{
    public class ShapeCollection
    {
        public string Name { get; set; }
        public List<IShape> ListOfShapes { get; set; }

        public ShapeCollection(string name)
        {
            Name = name;
            ListOfShapes = new List<IShape>();
        }

        /// <summary>
        /// Method <c>SortByPerimeter</c> will order all shapes in our Collection by perimeter smallest to largest.
        /// <br/>The <c>descending</c> parameter will reverse the order if toggle to true."
        /// </summary>
        /// <param name="descending"></param>
        public void SortByPerimeter(bool descending)
        {
            ListOfShapes.Sort((x, y) => x.Perimeter.CompareTo(y.Perimeter));
            
            if (descending == true)
            {
                ListOfShapes.Reverse();
            }
        }

        /// <summary>
        /// Method <c>SortBySurfaceArea</c> will order all shapes in our Collection by surface area smallest to largest.
        /// <br/>The <c>descending</c> parameter will reverse the order if toggle to true."
        /// </summary>
        /// <param name="descending"></param>
        public void SortBySurfaceArea(bool descending)
        {
            ListOfShapes.Sort((x, y) => x.SurfaceArea.CompareTo(y.SurfaceArea));

            if (descending == true)
            {
                ListOfShapes.Reverse();
            }
        }

        /// <summary>
        /// Method <c>ToCollectionString</c> returns all of the shapes contained within the
        /// collection (each using their ToShapeString methods). If the ListOfShapes is empty,
        /// the method will say that it's empty.
        /// </summary>
        /// <returns></returns>
        public string ToCollectionString()
        {
            string output = $"Collection {Name}:";

            if (ListOfShapes.Count > 0)
            {
                foreach (IShape shape in this.ListOfShapes)
                {
                    output += $"\n{shape.ToShapeString()}";
                }
            }
            else
            {
                output += $" It appears {Name} is empty...";
            }

            return output;
        }
    }
}
