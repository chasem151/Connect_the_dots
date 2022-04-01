using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;


namespace Lab3
{
    public partial class Form1 : Form
    {
        private List<PointF> coordinates = new List<PointF>();
        bool flag = false;
        
        public Form1()
        {
            this.DoubleBuffered = true;
            
            //this.AutoScroll = true;
            InitializeComponent();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

                PointF p = new PointF(e.X, e.Y);
                
                this.coordinates.Add(p);
                this.Invalidate();
            }
            if (e.Button == MouseButtons.Right)
            {
                this.coordinates.Clear();
                this.Invalidate();
            }
        }

        

        private void Linebutton_Click(object sender, EventArgs e)
        {

            if (Linebutton.Text == "Show Lines")
            {
                Linebutton.Text = "Hide Lines";

                //this.Invalidate();
            }
            else if (Linebutton.Text == "Hide Lines")
            {
                Linebutton.Text = "Show Lines";

                //this.Invalidate();
            }

            if (flag)
            {
                flag = false;
                //this.Invalidate();
            }
            else
            {
                flag = true;
                //this.Invalidate(); 
            }
            Invalidate();  

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Pen blk = new Pen(Brushes.Black);
            blk.Width = 2.0F;
            //blk.LineJoin = System.Drawing.Drawing2D.LineJoin.Bevel;
            if (flag)
            {
                for(int i=0; i < this.coordinates.Count; i++)
                {
                    if (i != 0)
                        --i;
                    e.Graphics.DrawLine(blk, this.coordinates[i], this.coordinates[++i]);
                    Invalidate();
                    //e.Graphics.DrawString("heck", Font, Brushes.Black, this.coordinates[i].X, this.coordinates[i].Y);
                }
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            const int WIDTH = 15;
            const int HEIGHT = 15;
            Graphics g = e.Graphics;
           
            foreach (PointF p in this.coordinates)
            {
                g.FillEllipse(Brushes.Red, p.X - WIDTH / 2, p.Y - WIDTH / 2, WIDTH, HEIGHT);
                Invalidate();
            }
           //this.Invalidate();

            //base.OnPaint(e);
            
            //Point p2 = new Point(100, 100);
            //int ct = coordinates.Count;
            /*
            
            */

        }

        protected override Point ScrollToControl(Control activeControl)
        {
            Point pt = this.AutoScrollPosition;
            return pt;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
