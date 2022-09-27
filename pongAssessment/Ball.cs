using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pongAssessment
{
    public class Ball : Graphic
    {
        public Ball(Graphics graphics, Color color, Point position, Point velocity) : base(graphics, color, position, velocity)
        {
        }

        public override void Draw()
        {
            graphics.FillEllipse(brush, new Rectangle(position.X, position.Y, SIZE, SIZE));
        }
    }
}
