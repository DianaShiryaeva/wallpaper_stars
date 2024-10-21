using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace oboi_star
{
    class Connection
    {
        private Star star1, star2;
        private Pen pen;
        private int count = 0;
        public Connection(Star star1, Star star2)
        {
            this.star1 = star1;
            this.star2 = star2;

            LinearGradientBrush gradientBrush = new LinearGradientBrush(new Point(0, 10), new Point(200, 10), star1.DrawComponent.Color, star2.DrawComponent.Color);
            pen = new Pen(gradientBrush);  
        }

        public void DrawLine(Graphics graphics)
        {
            graphics.DrawLine(pen, star1.TransformComponent.Point, star2.TransformComponent.Point);
        }

        public bool CheckConnection()
        {
            int max = 10;
            if(count>max)
            {
                return true;
            }
            else
            {
                count++;
                return false;
            }
            //if(starOut1 == star1 && starOut2 == star2)
            //{
            //    return false;
            //}
            //else if (starOut2 == star1 && starOut1 == star2)
            //{
            //    return false;
            //}
            //else
            //{
            //    return true;
            //}
        }

    }
}
