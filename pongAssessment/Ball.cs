using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pongAssessment
{
    public class Ball : Graphic
    {

        public int ball_position;

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
            position.X -= velocity.X;

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
            //if (position.X < 0)
            //{
            //    velocity.X *= -1;
            //}
        }

        public int Ball_Position()
        {
            ball_position = position.Y + BALLSIZE;

            return ball_position;
        }

        public void Pong()
        {
            velocity.X *= -1;
        }

        public bool Pong1()
        {
            bool query = false;
            if (position.X <= 40)
            {
                query = true;
                
            }
            return query;
        }

    }
}
