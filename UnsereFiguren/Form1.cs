using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UnsereFiguren
{
    public partial class Form1 : Form
    {

        private Pen pen = new Pen(Color.Black, 1);
        private List<Figur> figuren = new List<Figur>();
        private Figur activeFigur = null;
        private Punkt activePoint = null;

        public Form1() {
            DoubleBuffered = true;
            InitializeComponent();
            FigurenErstellen();
        }

        private void FigurenErstellen() {
            Punkt[] polPunkte = new Punkt[3];
            polPunkte[0] = new Punkt(60, 60);
            polPunkte[1] = new Punkt(80, 60);
            polPunkte[2] = new Punkt(80, 10);
            //punkte[3] = new Punkt(100, 200);

            Punkt[] drePunkte = new Punkt[3];
            drePunkte[0] = new Punkt(100, 100);
            drePunkte[1] = new Punkt(120, 100);
            drePunkte[2] = new Punkt(120, 50);
            //punkte[3] = new Punkt(100, 200);

            Punkt[] recPunkte = new Punkt[4];
            recPunkte[0] = new Punkt(50, 50);
            recPunkte[1] = new Punkt(100, 50);
            recPunkte[2] = new Punkt(100, 150);
            recPunkte[3] = new Punkt(50, 150);

            Polygon pol1 = new Polygon(60, 60, polPunkte);
            pol1.Fuellfarbe = Color.Gold;
            pol1.Linienfarbe = Color.Green;
            pol1.Fontfarbe = Color.RoyalBlue;
            float pol1Flaeche = pol1.FlaecheBerechnen();
            pol1.Text = "A=" + pol1Flaeche.ToString();

            Polygon pol2 = new Polygon(100, 100, recPunkte);
            pol2.Fuellfarbe = Color.Gold;
            pol2.Linienfarbe = Color.Green;
            pol2.Fontfarbe = Color.RoyalBlue;
            float pol2Flaeche = pol2.FlaecheBerechnen();
            pol2.Text = "A=" + pol2Flaeche.ToString();

            Dreieck dre1 = new Dreieck(120, 50, drePunkte[0], drePunkte[1], drePunkte[2]);
            dre1.Fuellfarbe = Color.Black;
            dre1.Linienfarbe = Color.Yellow;
            dre1.Fontfarbe = Color.RoyalBlue;
            float dre1Flaeche = dre1.FlaecheBerechnen();
            dre1.Text = "A=" + dre1Flaeche.ToString();

            //PRechteck prec1 = new PRechteck(150, 100, recPunkte[0], recPunkte[1], recPunkte[2], recPunkte[3]);
            //prec1.Fuellfarbe = Color.Black;
            //prec1.Linienfarbe = Color.Yellow;
            //prec1.Fontfarbe = Color.RoyalBlue;
            //float prec1Flaeche = prec1.FlaecheBerechnen();
            //prec1.Text = "A=" + prec1Flaeche.ToString();

            // 
            Rechteck rec1 = new Rechteck(5, 5, 50, 100);
            rec1.Fuellfarbe = Color.LawnGreen;
            rec1.Linienfarbe = Color.Red;
            rec1.Fontfarbe = Color.White;
            float rec1Flaeche = rec1.FlaecheBerechnen();
            rec1.Text = "A=" + rec1Flaeche.ToString();

            //MessageBox.Show("test");

            Ellipse eli1 = new Ellipse(50, 100, 50, 100);
            eli1.Fuellfarbe = Color.Lavender;
            eli1.Linienfarbe = Color.Khaki;
            eli1.Fuellfarbe = Color.Red;
            float eli1Flaeche = eli1.FlaecheBerechnen();
            eli1.Text = "A=" + eli1Flaeche.ToString();
            //figuren.Add(new Rechteck(140, 160, 180, 120));
            figuren.Add(rec1);
            //figuren.Add(new Ellipse(150, 20, 180, 120));
            figuren.Add(pol1);
            figuren.Add(pol2);
            figuren.Add(dre1);
            //figuren.Add(eli1);
            //figuren.Add(prec1);
        }

        private void Form1_Paint(object sender, PaintEventArgs e) {
            foreach (Figur figur in figuren) {
                figur.Zeichnen(e.Graphics);
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e) {
            foreach (Figur figur in figuren) {
                if(figur.IsInside(e.X, e.Y)) {
                    activeFigur = figur;
                    activePoint = new Punkt(e.X, e.Y);
                    Console.WriteLine(figur);
                }
            }
            if (activeFigur != null) {
                figuren.Remove(activeFigur);
                figuren.Add(activeFigur);
                //Invalidate();
                //figuren.Reverse();
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e) {
            if (activeFigur != null) {
                activeFigur.X += e.X - activePoint.X;
                activeFigur.Y += e.Y - activePoint.Y;
                Invalidate();
                activePoint = new Punkt(e.X,e.Y);
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e) {
            //Console.WriteLine("Maus UP loslassen " + activeFigur);
            activeFigur = null;
            activePoint = null;
        }
    }
}