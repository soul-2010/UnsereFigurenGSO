using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace UnsereFiguren
{
    class Dreieck : Polygon
    {
        // Attribute
        
        // Konstruktoren
        public Dreieck(float x, float y, Punkt a, Punkt b, Punkt c)
            : base(x, y, new Punkt[3]{a,b,c}) {
        }
        // Methoden
    }
}
