using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pongAssessment
{
    public class Paddle : Graphic
    {
        public Paddle(Graphics graphics, Color color, Point position, Point velocity) : base(graphics, color, position, velocity)
        {
        }

        public override void Draw()
        {
            graphics.FillRectangle(brush, new Rectangle(position.X, position.Y, PADDLESIZE_X, PADDLESIZE_Y));
        }

        public void Up()
        {
            if ((position.Y) >= 0)
            {
                position.Y -= 10;
            }
        }
        public void Down()
        {
            if ((position.Y + PADDLESIZE_Y) <= 700)
            {
                position.Y += 10;
            }
            
        }
    }
}
