﻿using System;
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
        private const int PADDLEVELOCITY_Y = 7;
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
            Computer_Movement();
            Paddle_Hit();
            Computer_Hit();
        }

        public void Reload()
        {
            paddle.Position_Paddle();
            paddle.Position_Paddle_Size();
            computer.Position_Computer_Middle();
            ball.Ball_Position();
        }

        public void Restart()
        {
            ball.Restart();
            paddle.Restart();
            computer.Restart();
        }

        //Player move methods
        public void PaddleUp()
        {
            paddle.Up();
        }
        public void PaddleDown()
        {
            paddle.Down();
        }

        //Player paddle
        public void Paddle_Hit()
        {
            if (ball.Paddle_Pong() == true) {
                //ball.Pong();
                if (paddle.Position_Paddle() <= ball.Ball_Position() && paddle.Position_Paddle_Size() >= ball.Ball_Position())
                {
                    ball.Hit();
                }
            }
        }

        //Computer paddle
        public void Computer_Hit()
        {
            if (ball.Computer_Pong() == true)
            {
                //ball.Pong();
                if (computer.Position_Computer() <= ball.Ball_Position() && computer.Position_Computer_Size() >= ball.Ball_Position())
                {
                    ball.Hit();
                }
            }
        }

        //Computer movement
        public void Computer_Movement()
        {
            if (ball.Ball_Position() + 20 < computer.Position_Computer_Middle())
            {
                computer.Up();
            }
            if (ball.Ball_Position() > computer.Position_Computer_Middle())
            {
                computer.Down();
            }
        }
    }
}
