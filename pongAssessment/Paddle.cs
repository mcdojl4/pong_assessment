using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pongAssessment
{
    public class Paddle : Graphic
    {
        public int paddle_position;
        public int paddle_position_size;

        public Paddle(Graphics bufferGraphics, Color color, Point position, Point velocity) : base( bufferGraphics, color, position, velocity)
        {
        }

        public override void Draw()
        {
            bufferGraphics.FillRectangle(brush, new Rectangle(position.X, position.Y, PADDLESIZE_X, PADDLESIZE_Y));
        }

        public void Restart()
        {
            position.X = 20;
            position.Y = (700 / 2) - (PADDLESIZE_Y / 2);
        }

        public void Up()
        {
            if (position.Y >= 0)
            {
                position.Y -= velocity.Y;
            }
        }
        public void Down()
        {
            if ((position.Y + PADDLESIZE_Y) <= Boundaries.Height - 50)
            {
                position.Y += velocity.Y;
            }
            
        }

        public int Position_Paddle()
        {
            paddle_position = position.Y;

            return paddle_position;
        }

        public int Position_Paddle_Size()
        {
            paddle_position_size = position.Y + PADDLESIZE_Y;

            return paddle_position_size;
        }

    }
}
