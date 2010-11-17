using System;
using System.Collections.Generic;
using System.Text;

namespace UnsereFiguren
{
    class PRechteck:Polygon
    {
        // Konstruktoren
        public PRechteck(float x, float y, Punkt a, Punkt b, Punkt c, Punkt d)
            : base(x, y, new Punkt[4]{a,b,c,d}) {
        }

    }
}
