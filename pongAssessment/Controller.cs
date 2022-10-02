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
        private const int STARTPADDLE = 20;
        private const int STARTCOMPUTER = 776;
        private const int STARTPADDLES_Y = 120;

        private Ball ball;
        private Paddle paddle;
        private Computer computer;

        public Controller(Graphics graphics)
        {
            ball = new Ball(graphics, Color.Aqua, new Point(400, STARTBALL), new Point(20, 20));
            paddle = new Paddle(graphics, Color.White, new Point(STARTPADDLE, STARTPADDLES_Y), new Point(10, 10));
            computer = new Computer(graphics, Color.White, new Point(STARTCOMPUTER, STARTPADDLES_Y), new Point(10, 10));
        }

        public void Run()
        {
            ball.Draw();
            paddle.Draw();
            computer.Draw();
        }

        public void PaddleUp()
        {
            paddle.Up();
        }
        public void PaddleDown()
        {
            paddle.Down();
        }
    }
}
