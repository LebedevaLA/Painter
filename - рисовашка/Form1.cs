using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetSize();
            
            btnClear.Enabled = false;
        }

        private class ArrayPoint
        {
            public int index = 0;

            //public List<Point> pointsList;

            public Point[] points;
            //public ArrayPoint()
            //{

            //}
            public ArrayPoint(int size)
            {
                if (size <= 0) size = 2;
                points = new Point[size];
            }



            public void SetPoint(int x, int y)
            {

                if (index >= points.Length) index = 0;
                //points[index] = new Point(x, y);
                points[index] = new Point(x, y);
                index++;
            }

            public void ResetIndex()
            {
                index = 0;
            }

            public int GetCountPoints()
            {
                return index;
            }

            public Point[] GetPoints()
            {
                return points;
            }
        
        }

        private ArrayPoint arrayPoint = new ArrayPoint(2);

        Bitmap map;// = new Bitmap(100, 100);
        Graphics graphics;
        Pen pen = new Pen(Color.Black, 3f);


        private void SetSize()
        {
            Rectangle rectangle = Screen.PrimaryScreen.Bounds;
            map = new Bitmap(rectangle.Width, rectangle.Height);
            graphics = Graphics.FromImage(map);

            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

        }



        private void label1_Click(object sender, EventArgs e)
        {

        }




        private bool isMouse = false;
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            isMouse = true;
            btnClear.Enabled = false;
            //timer1.Start();
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isMouse = false;
            //arrayPoint.ResetIndex();
            pictureBox1.Enabled = false;
            btnClear.Enabled = true;

            //timer1.Stop();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            
            
            if (!isMouse) { return; }
            arrayPoint.SetPoint(e.X, e.Y);
            //label3.Text = arrayPoint.GetCountPoints().ToString();
            if (arrayPoint.GetCountPoints() >= 2)
            {
                graphics.DrawLines(pen, arrayPoint.GetPoints());
                pictureBox1.Image = map;
                arrayPoint.SetPoint(e.X, e.Y);
            }

        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color color = colorDialog1.Color;
                btnColor.BackColor = color;
                pen.Color = color;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            graphics.Clear(pictureBox1.BackColor);
            pictureBox1.Image = map;

            

            btnClear.Enabled = false;
            arrayPoint.ResetIndex();
            pictureBox1.Enabled = true;
            
        }
        private int index2 = 1;
        private void timer1_Tick(object sender, EventArgs e)
        {
            //label1.Text = index2.ToString();
            ////graphics.DrawLine(pen, arrayPoint.points[0], arrayPoint.points[index2]);

            //if (index2 == arrayPoint.index) timer1.Stop();

            //graphics.DrawLine(pen, arrayPoint.points[index2 - 1], arrayPoint.points[index2]);
            //index2++;
            //pictureBox1.Image = map;

            index2++;
            label1.Text = index2.ToString();

        }
    }
}
