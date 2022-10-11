using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pongAssessment
{
    public class Ball : Graphic
    {
        private bool collision_y = true;


        public Ball(Graphics bufferGraphics, Color color, Point position, Point velocity) : base(bufferGraphics, color, position, velocity)
        {
        }

        public override void Draw()
        {
            bufferGraphics.FillEllipse(brush, new Rectangle(position.X, position.Y, BALLSIZE, BALLSIZE));
        }

        public void Move()
        {
            position.Y += velocity.Y;
            position.X += velocity.X;

        }

        public void Bounce()
        {
            if (position.Y + 80 >= Boundaries.Height)
            {
                velocity.Y *= -1;
            }
            if (position.Y < 0)
            {
                velocity.Y *= -1;
            }
            if (position.X + 120 >= Boundaries.Width)
            {
                velocity.X *= -1;
            }
            if (position.X < 0)
            {
                velocity.X *= -1;
            }
        }
    }
}
