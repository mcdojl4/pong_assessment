using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pongAssessment
{
    internal class Images
    {
        private Graphics graphics;
        private Brush brush;
        private Point position;
        private Color color;
        public int SIZE = 10;

        public Images(Graphics graphics, Brush brush, Color color, Point position)
        {
            this.position = position;
            this.graphics = graphics;
            this.brush = brush;
            this.color = color;

            brush = new SolidBrush(color);

        }

        public void Draw()
        {
            graphics.FillRectangle(brush, new Rectangle(position.X, position.Y, SIZE, SIZE));
        }
    }
}
