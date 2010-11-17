using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace UnsereFiguren
{
    public class Punkt
    {
        // Attribute
        public float X = 0;
        public float Y = 0;

        // Konstruktoren
        public Punkt() {
            this.X = 0;
            this.Y = 0;
        }

        public Punkt(float x, float y) {
            this.X = x;
            this.Y = y;
        }


        // Methoden
        public PointF ToPointf() {
            PointF punktf = new PointF(this.X, this.Y);
            return punktf;
        }
        //public void VerschiebeZu(Punkt pos);

        //public float VerschiebenUm(float dx, float dy);
    }
}
