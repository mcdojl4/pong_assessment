using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pongAssessment
{
    public class Controller
    {
        //object positions
        private const int STARTBALL_X = 500 - (10 / 2);
        private const int STARTBALL_Y = (700 / 2) - (10 / 2);
        private const int STARTPADDLE = 20;
        private const int STARTCOMPUTER = (1000 - 40) - Paddle.PADDLESIZE_X;
        private const int STARTPADDLES_Y = (700 / 2) - (Paddle.PADDLESIZE_Y / 2);

        //object velocitys
        private const int PADDLEVELOCITY_Y = 5;
        private const int BALLVELOCITY = 10;

        private Ball ball;
        private Paddle paddle;
        private Computer computer;

        public Controller(Graphics buffergraphics)
        {
            ball = new Ball(buffergraphics, Color.Aqua, new Point(STARTBALL_X, STARTBALL_Y), new Point(BALLVELOCITY, BALLVELOCITY));
            paddle = new Paddle(buffergraphics, Color.White, new Point(STARTPADDLE, STARTPADDLES_Y), new Point(0, PADDLEVELOCITY_Y));
            computer = new Computer(buffergraphics, Color.White, new Point(STARTCOMPUTER, STARTPADDLES_Y), new Point(0, PADDLEVELOCITY_Y));
        }

        public void Run()
        {
            ball.Draw();
            paddle.Draw();
            computer.Draw();
            ball.Move();
            ball.Bounce();
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
