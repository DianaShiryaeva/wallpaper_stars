using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oboi_star
{
    public partial class Form1 : Form
    {
        private Star[] stars;
        private Random random = new Random();
        private Graphics graphics;
        private Bitmap bitmap;
        private static Size resolution = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Size;
        private List<Connection> connections;
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.Black;
            this.WindowState = FormWindowState.Maximized;

            connections = new List<Connection>();

            stars = new Star[150];

            for (int i = 0; i < stars.Length; i++)
            {
                stars[i] = new Star(new PointF(random.Next(0, resolution.Width), random.Next(0, resolution.Height)));
            }

            timer1.Enabled = true;

            bitmap = new Bitmap(resolution.Width, resolution.Height);
            graphics = Graphics.FromImage(bitmap);
            this.DoubleBuffered = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {       
            for (int i = 0; i < stars.Length; i++)
            {
                stars[i].Move(this.Size);
                stars[i].Draw(graphics);
            }
            Refresh();
            Refresh();

            for (int i = 0; i < connections.Count;)
            {
                if(connections[i].CheckConnection())
                {
                    connections.RemoveAt(i);
                }
                else
                {
                    i++;
                }
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            graphics.FillRectangle(new SolidBrush(this.BackColor), 0, 0, this.Width, this.Height);
            graphics.FillRectangle(new SolidBrush(this.BackColor), 0, 0, this.Width, this.Height);
            
            this.BackgroundImage = bitmap;
            this.BackgroundImage = bitmap;
            foreach (var item in stars)
            {
                item.Draw(graphics);
            }

            foreach (var item in connections)
            {
                item.DrawLine(graphics);
            }
        }

        private List<Star> Selection(Point e)
        {
            List<Star> starsOfConnection = new List<Star>();
            for (int i = 0; i < stars.Length; i++)
            {
                if (Math.Abs(stars[i].TransformComponent.Point.X - e.X) < 70 && Math.Abs(stars[i].TransformComponent.Point.Y - e.Y) < 70)
                {
                    starsOfConnection.Add(stars[i]);
                }
            }
            return starsOfConnection;
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            List<Star> starsOfConnection = Selection(e.Location);

            for (int i = 0; i < starsOfConnection.Count-1; i++)
            {
                connections.Add(new Connection(starsOfConnection[i], starsOfConnection[i + 1]));   
            }
        }
    }
}
