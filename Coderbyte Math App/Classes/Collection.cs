using Coderbyte_Math_App.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coderbyte_Math_App.Classes
{
    class Collection
    {
        public List<IShape> ListOfShapes { get; set; }

        public Collection()
        {
            ListOfShapes = new List<IShape>();
        }
    }
}
