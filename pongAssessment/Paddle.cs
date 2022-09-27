using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pongAssessment
{
    internal class Paddle : Graphic
    {
        public Paddle(Graphics graphics, Color color, Point position, Point velocity) : base(graphics, color, position, velocity)
        {
        }

        public override void Draw()
        {
            throw new NotImplementedException();
        }
    }
}
