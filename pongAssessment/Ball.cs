using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pongAssessment
{
    public class Ball : Graphic
    {
        public Ball(Graphics bufferGraphics, Color color, Point position, Point velocity) : base(bufferGraphics, color, position, velocity)
        {
        }

        public override void Draw()
        {
            bufferGraphics.FillEllipse(brush, new Rectangle(position.X, position.Y, BALLSIZE, BALLSIZE));
        }
    }
}
