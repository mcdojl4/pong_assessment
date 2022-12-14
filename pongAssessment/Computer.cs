using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pongAssessment
{
    public class Computer : Graphic
    {

        public int computer_position;
        public int computer_position_size;
        public int computer_position_middle;

        public Computer(Graphics bufferGraphics, Color color, Point position, Point velocity) : base(bufferGraphics, color, position, velocity)
        {
        }

        public override void Draw()
        {
            //Draws computer paddle
            bufferGraphics.FillRectangle(brush, new Rectangle(position.X, position.Y, PADDLESIZE_X, PADDLESIZE_Y));
        }

        public void Restart()
        {
            //Resets position
            position.X = (1000 - 40) - PADDLESIZE_X;
            position.Y = (500 / 2) - (PADDLESIZE_Y / 2);
        }

        //Computer paddle position
        public int Position_Computer()
        {
            computer_position = position.Y;

            return computer_position;
        }

        public int Position_Computer_Size()
        {
            computer_position_size = position.Y + PADDLESIZE_Y;

            return computer_position_size;
        }

        public int Position_Computer_Middle()
        {
            computer_position_middle = position.Y + (PADDLESIZE_Y / 2);

            return computer_position_middle;
        }

        //Computer paddle movement
        public void Up()
        {
            //Makes computer go up
            if (position.Y >= 0) 
            {
                position.Y -= velocity.Y;
            }
        }
        public void Down()
        {
            //Makes computer go down
            if ((position.Y + PADDLESIZE_Y) <= Boundaries.Height - 50)
            {
                position.Y += velocity.Y;
            }
        }
    }
}
