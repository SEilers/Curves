using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Curves;
using System.Windows.Forms.DataVisualization.Charting;

namespace CurvesDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int seriesIndex = 0;

        private void DrawCurve( Curve curve, int numPoints, System.Drawing.Color color )
        {
            List<Point2D> pl = curve.GetPoints(numPoints);

            var series = new System.Windows.Forms.DataVisualization.Charting.Series
            {
                Name = "Series" + "_" + seriesIndex.ToString(),
                Color = color,
                IsVisibleInLegend = false,
                IsXValueIndexed = false,
                ChartType = SeriesChartType.Line
            };

            seriesIndex++;

            foreach (Point2D p in pl)
            {
                series.Points.AddXY(p.X, p.Y);
            }

            this.chart1.Series.Add(series);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();

            double deg45 = Math.PI / 4.0;

            LineSegment ls1 = new LineSegment(1, 3, deg45, 5);
            LineSegment ls2 = new LineSegment(3, 0, deg45, 5);
            LineSegment ls3 = new LineSegment(0, 0,  0, 3);
            LineSegment ls4 = new LineSegment(0, 0, -deg45, 5);
            LineSegment ls5 = new LineSegment(2, 2, deg45, 5);

            DrawCurve(ls1, 2, Color.Green);
            DrawCurve(ls2, 2, Color.Green);
            DrawCurve(ls3, 2, Color.Green);
            DrawCurve(ls4, 2, Color.Green);
            DrawCurve(ls5, 2, Color.Green);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();

            Arc arc1 = new Arc(0, 0, 0, 1, Math.PI);

            DrawCurve(arc1, 33, Color.Green);
            DrawCurve(arc1, 9, Color.Blue);
            DrawCurve(arc1, 5, Color.Red);

            Arc arc2 = new Arc(0, 1, 0,  2, 0.7);
            Arc arc3 = new Arc(0, 1, 0,  1, 0.7);
            Arc arc4 = new Arc(0, 1, 0, -1, 0.7);
            Arc arc5 = new Arc(0, 1, 0, -2, 0.7);

            DrawCurve(arc2, 32, Color.Orange);
            DrawCurve(arc3, 32, Color.Orange);
            DrawCurve(arc4, 32, Color.OrangeRed);
            DrawCurve(arc5, 32, Color.OrangeRed);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();

            Clothoid cl0 = new Clothoid(0, 0, 0, 0, 1.5, Math.PI / 2);
            DrawCurve(cl0, 33, Color.Green);
            Clothoid cl1 = new Clothoid(0, 0, 0, 0, 2, Math.PI / 2);
            DrawCurve(cl1, 33, Color.Green);
            Clothoid cl2 = new Clothoid(0, 0, 0, 0, 3, Math.PI / 2);
            DrawCurve(cl2, 33, Color.Green);
            Clothoid cl3 = new Clothoid(0, 0, 0, 0, -1.5, Math.PI / 2);
            DrawCurve(cl3, 33, Color.LimeGreen);
            Clothoid cl4 = new Clothoid(0, 0, 0, 0, -2, Math.PI / 2);
            DrawCurve(cl4, 33, Color.LimeGreen);
            Clothoid cl5 = new Clothoid(0, 0, 0, 0, -3, Math.PI / 2);
            DrawCurve(cl5, 33, Color.LimeGreen);

            Clothoid cl6 = new Clothoid(0, 0, 0, 0, 1, 5);
            DrawCurve(cl6, 257, Color.Blue);
            Clothoid cl6_1 = new Clothoid(0, 0, 0, 0, 1, -5);
            DrawCurve(cl6_1, 257, Color.Blue);

            Clothoid cl7 = new Clothoid(0, 0, 0, -1, 1, 5);
            DrawCurve(cl7, 257, Color.DarkRed);

            Clothoid cl8 = new Clothoid(0, 0, 0, -1.5, 1, 5);
            DrawCurve(cl8, 257, Color.Blue);

            Clothoid cl10 = new Clothoid(0, 0, 0, 0, 1, Math.PI);
            DrawCurve(cl10, 257, Color.DarkGoldenrod);

            Clothoid cl11 = new Clothoid(0, 0, 0, 0, -1, Math.PI);
            DrawCurve(cl11, 257, Color.DarkGoldenrod);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();

            PolynomialSpiral ps0 = new PolynomialSpiral(0, 0, 0, new double[] { 1, 0, 0, 0 }, Math.PI / 2);
            DrawCurve(ps0, 33, Color.Green);

            PolynomialSpiral ps1 = new PolynomialSpiral(0, 0, 0, new double[] { 0, 1, 0, 0 }, Math.PI / 2);
            DrawCurve(ps1, 33, Color.Green);

            PolynomialSpiral ps2 = new PolynomialSpiral(0, 0, 0, new double[] { 0, 0, 1, 0 }, Math.PI / 2);
            DrawCurve(ps2, 33, Color.Green);

            PolynomialSpiral ps3 = new PolynomialSpiral(0, 0, 0, new double[] { 0, 0, 0, 1 }, Math.PI / 2);
            DrawCurve(ps3, 33, Color.Green);

            PolynomialSpiral ps4 = new PolynomialSpiral(0, 0, 0, new double[] { 0, 0, 1, 1 }, Math.PI / 2);
            DrawCurve(ps4, 33, Color.Green);

            PolynomialSpiral ps5 = new PolynomialSpiral(0, 0, 0, new double[] { -1, 1, 0, 0 }, 3.8);
            DrawCurve(ps5, 1025, Color.Green);

            PolynomialSpiral ps6 = new PolynomialSpiral(0, 0, 0, new double[] { 0, 33, -82, 41.5 }, 1.5);
            DrawCurve(ps6, 1025, Color.Green);
        }
    }
}
