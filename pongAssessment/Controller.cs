using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pongAssessment
{
    public class Controller
    {
        private const int STARTBALL = 200;

        private Ball ball;

        public Controller(Graphics graphics)
        {
            ball = new Ball(graphics, Color.Aqua, new Point(400, STARTBALL), new Point(20, 20));
        }

        public void Run()
        {
            ball.Draw();
        }
    }
}
