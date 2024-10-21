using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oboi_star
{
    class Star
    {      
        private Draw draw;
        private Transform transformer;

        public Star(PointF point)
        {
            draw = new Draw();
            transformer = new Transform(point, 2);
        }

        public void Draw(Graphics graphics)
        {
            draw.Painting(graphics, transformer.Point);
        }

        public void Move(SizeF size)
        {
            transformer.Move(size);
        }

        public Transform TransformComponent
        {
            get
            {
                return transformer;
            }
        }

        public Draw DrawComponent
        {
            get
            {
                return draw;
            }
        }
    }

    class Draw
    {
        private static Random random = new Random();
        private Pen pen;

        public Draw()
        {
            pen = new Pen(Color.FromArgb(random.Next(255), random.Next(255), random.Next(255)));
        }

        public void Painting(Graphics graphics, PointF point)
        {
            graphics.DrawRectangle(pen, point.X, point.Y, 1, 1);
        }

        public Color Color
        {
            get
            {
                return pen.Color;
            }
        }
    }

    class Transform
    {
        private static Random random = new Random();
        private PointF point;
        private float speed;
        private float stepX, stepY;
        public Transform(PointF point, float speed)
        {
            this.point = point;
            this.speed = speed;
            int r = random.Next(-3, 3);
            if(r != 0)
            { 
                stepX = r;
                stepY = r;
            }
            else
            {
                stepX = 1;
                stepY = 1;
            }
        }

        public PointF Move(SizeF size)
        {
            if (point.X > size.Width || point.X < 0)
                stepX *= -1;
            if (point.Y > size.Height || point.Y < 0)
                stepY *= -1;

            point = new PointF(point.X + stepX * speed, point.Y + stepY * speed);

            return point;
        }

        public PointF Point
        {
            get
            {
                return point;
            }
        }
    }
}
