using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Text;

namespace UnsereFiguren
{
    public abstract class Figur : Punkt
    {
        // Attribute
        public Color Fuellfarbe = Color.Beige;
        public Color Linienfarbe = Color.Black;
        public Color Fontfarbe = Color.Black;
        public string Text = "";
        public string Fontart = "Arial";
        public float Fontgroesse = 10;
        //public Font font = new Font("Arial", 40);
        //public Punkt Position = new Punkt();

        // Konstruktoren
        public Figur(){
        }

        public Figur(float x, float y)
            : base(x,y) {
        }

        // Methoden
        public abstract void Zeichnen(Graphics g);

        public abstract void VergroessernUm(float dx, float dy);

        public abstract float FlaecheBerechnen();

        public abstract float GetBreite();

        public abstract float GetHoehe();

        public abstract bool IsInside(float x, float y);
    }
}
