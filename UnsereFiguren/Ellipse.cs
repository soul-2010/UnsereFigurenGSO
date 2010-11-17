using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Text;

namespace UnsereFiguren
{
    public class Ellipse : Rechteck
    {
        // Attribute

        // Konstruktoren
        public Ellipse(float x, float y, float breite, float hoehe)
            : base(x, y, breite, hoehe) {
        }


        // Methoden
        public override float FlaecheBerechnen() {
            float flaeche = (float)Math.PI / 4 * this.Breite * this.Hoehe;
            return flaeche;
        }

        public override void Zeichnen(Graphics g) {
            Brush brush = new SolidBrush(this.Fuellfarbe);
            g.FillEllipse(brush, this.X, this.Y, Breite, Hoehe);

            Pen pen = new Pen(this.Linienfarbe);
            g.DrawEllipse(pen, this.X, this.Y, Breite, Hoehe);

            Brush brushfo = new SolidBrush(this.Fontfarbe);
            Font font = new Font(this.Fontart, this.Fontgroesse);
            g.DrawString(this.Text, font, brushfo, this.X, this.Y);
        }
    }
}
