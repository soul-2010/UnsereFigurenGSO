using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace UnsereFiguren
{
    public class Polygon : Figur
    {
        //private List<Punkt> punkte = new List<Punkt>();

        public Punkt[] punktearray;

        public Polygon(float x, float y, Punkt[] punkte)
            : base(x, y) {
            this.punktearray = punkte;
        }

        // Methoden
        private PointF[] GetPointArray() {
            PointF[] punktef = new PointF[punktearray.Length];
            int i = 0;
            foreach (Punkt punkt in punktearray) {
                PointF tmp = punkt.ToPointf();
                tmp.X += this.X;
                tmp.Y += this.Y;
                punktef[i] = tmp;
                i++;
            }
            return punktef;
        }

        public override void Zeichnen(Graphics g) {
            Brush brush = new SolidBrush(this.Fuellfarbe);
            g.FillPolygon(brush, GetPointArray());

            Pen pen = new Pen(this.Linienfarbe);
            g.DrawPolygon(pen, GetPointArray());

            Brush brushfo = new SolidBrush(this.Fontfarbe);
            Font font = new Font(this.Fontart, this.Fontgroesse);
            g.DrawString(this.Text, font, brushfo, this.X + this.punktearray[0].X, this.Y + this.punktearray[0].Y);
        }

        public override float FlaecheBerechnen() {
            //throw new NotImplementedException();
            int n = punktearray.Length - 1;
            float flaeche = 0;
            for (int i = 0; i < n; i++) {
                flaeche += (GetPointArray()[i + 1].X - GetPointArray()[i].X) * (GetPointArray()[i + 1].Y + GetPointArray()[i].Y) * (float)0.5;
            }
            //flaeche += (GetPointArray()[n].Y + GetPointArray()[0].Y) * (GetPointArray()[n].X - GetPointArray()[0].X);
            //flaeche = flaeche / 2;
            return flaeche;
        }

        public override bool IsInside(float x, float y) {
            float minX = FindX()[0];
            float maxX = FindX()[1];
            float minY = FindY()[0];
            float maxY = FindY()[1];
            if ((x >= minX) &&
                (x <= maxX) &&
                (y >= minY) &&
                (y <= maxY)
               ) {

                return true;
            }
            return false;
        }

        private float[] FindX() {
            if (punktearray.Length < 1) {
                throw new Exception("Fehler, keine Punkte angegeben!");
            }
            float minVal = punktearray[0].X;
            float maxVal = punktearray[0].X;
            foreach (Punkt punkt in punktearray) {
                if (punkt.X < minVal) {
                    minVal = punkt.X;
                }
                if (punkt.X > maxVal) {
                    maxVal = punkt.X;
                }
            }
            float[] Val = new float[2];
            Val[0] = minVal+this.X;
            Val[1] = maxVal+this.X;

            return Val;
        }

        private float[] FindY() {
            if (punktearray.Length < 1) {
                throw new Exception("Fehler, keine Punkte angegeben!");
            }
            float minVal = punktearray[0].Y;
            float maxVal = punktearray[0].Y;
            foreach (Punkt punkt in punktearray) {
                if (punkt.Y < minVal) {
                    minVal = punkt.Y;
                }
                if (punkt.Y > maxVal) {
                    maxVal = punkt.Y;
                }
            }
            float[] Val = new float[2];
            Val[0] = minVal+this.Y;
            Val[1] = maxVal+this.Y;

            return Val;
        }

        public override float GetBreite() {
            throw new NotImplementedException();
        }

        public override float GetHoehe() {
            throw new NotImplementedException();
        }

        public override void VergroessernUm(float dx, float dy) {
            throw new NotImplementedException();
        }


        //public override float FlaecheBerechnen() {
        //    float flaeche = this.Breite * this.Hoehe;
        //    return flaeche;
        //}
    }
}
