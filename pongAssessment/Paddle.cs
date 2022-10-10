using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pongAssessment
{
    public class Paddle : Graphic
    {
        public Paddle(Graphics bufferGraphics, Color color, Point position, Point velocity) : base( bufferGraphics, color, position, velocity)
        {
        }

        public override void Draw()
        {
            bufferGraphics.FillRectangle(brush, new Rectangle(position.X, position.Y, PADDLESIZE_X, PADDLESIZE_Y));
        }

        public void Up()
        {
            if ((position.Y) >= 0)
            {
                position.Y -= velocity.Y;
            }
        }
        public void Down()
        {
            if ((position.Y + PADDLESIZE_Y) <= 700)
            {
                position.Y += velocity.Y;
            }
            
        }
    }
}
