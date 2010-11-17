using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Text;
using System.Drawing.Drawing2D;

namespace UnsereFiguren
{
    public class Rechteck : Figur
    {
        // Attribute
        public float Breite = 0;
        public float Hoehe = 0;

        
        // Konstruktoren
        public Rechteck(float x, float y, float breite, float hoehe)
            : base(x,y) {
            this.Breite = breite;
            this.Hoehe = hoehe;
        }
        
        
        // Methoden
        public override float FlaecheBerechnen() {
            float flaeche = this.Breite * this.Hoehe;
            return flaeche;
        }

        public override void Zeichnen(Graphics g) {

            Brush brushfi = new SolidBrush(this.Fuellfarbe);
            g.FillRectangle(brushfi, this.X, this.Y, Breite, Hoehe);

            Pen pen = new Pen(this.Linienfarbe);
            g.DrawRectangle(pen, this.X, this.Y, Breite, Hoehe);

            Brush brushfo = new SolidBrush(this.Fontfarbe);
            Font font = new Font(this.Fontart, this.Fontgroesse);
            g.DrawString(this.Text, font, brushfo, this.X, this.Y);
        }

        public override void VergroessernUm(float dx, float dy) {
            this.Breite += dx;
            this.Hoehe += dy;
        }

        public override float GetBreite() {
            return this.Breite;
        }

        public override float GetHoehe() {
            return this.Hoehe;
        }

        public override bool IsInside(float x, float y) {
            if( (x >= this.X) && 
                (x <= this.X + GetBreite()) &&  
                ( y >= this.Y ) &&  
                ( y <= this.Y + GetHoehe()) 
               ) {

                return true;
            }
            return false;
        }
        //GraphicsPath _path;

        //public override GraphicsPath Path {
        //    get { return _path; }
        //}
    }
}
