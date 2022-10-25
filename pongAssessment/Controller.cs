using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace pongAssessment
{
    public class Controller
    {
        //object positions
        private const int STARTBALL_X = 500 - (10 / 2);
        private const int STARTBALL_Y = (500 / 2) - (10 / 2);
        private const int STARTPADDLE = 20;
        private const int STARTCOMPUTER = (1000 - 40) - Paddle.PADDLESIZE_X;
        private const int STARTPADDLES_Y = (500 / 2) - (Paddle.PADDLESIZE_Y / 2);

        //object velocitys
        private const int PADDLEVELOCITY_Y = 20;
        private const int BALLVELOCITY = 30;

        //bool queries
        public int paddleScoreboard;
        public int computerScoreboard;

        private Ball ball;
        private Paddle paddle;
        private Computer computer;

        public Controller(Graphics buffergraphics)
        {
            //Sets objects variables
            ball = new Ball(buffergraphics, Color.Aqua, new Point(STARTBALL_X, STARTBALL_Y), new Point(BALLVELOCITY, BALLVELOCITY));
            paddle = new Paddle(buffergraphics, Color.White, new Point(STARTPADDLE, STARTPADDLES_Y), new Point(0, PADDLEVELOCITY_Y));
            computer = new Computer(buffergraphics, Color.White, new Point(STARTCOMPUTER, STARTPADDLES_Y), new Point(0, PADDLEVELOCITY_Y));

            paddleScoreboard = 0;
            computerScoreboard = 0;
        }

        public void Run()
        {
            //Used to make all game run
            ball.Draw();
            paddle.Draw();
            computer.Draw();
            ball.Move();
            ball.Bounce();
            Computer_Movement();
            Paddle_Hit();
            Computer_Hit();
            Score();
        }

        public void Reload()
        {
            //Resets every tick of clock to keep position accurate
            paddle.Position_Paddle();
            paddle.Position_Paddle_Size();
            computer.Position_Computer_Middle();
            ball.Ball_Position();
        }

        public void Restart()
        {
            //Reset after point scored
            ball.Restart();
            paddle.Restart();
            computer.Restart();
        }

        public void Restart_Game()
        {
        //Fully resets game
            Convert.ToString(paddleScoreboard = 0);
            Convert.ToString(computerScoreboard = 0);
            ball.Restart();
            paddle.Restart();
            computer.Restart();
        }

        public void Score()
        {
            //Updates scoreboard
            if (ball.Computer_Score() == true)
            {
                computerScoreboard += 1;
                Restart();
            } 
            else if (ball.Paddle_Score() == true)
            {
                paddleScoreboard += 1;
                Restart();
            }
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
            //Checks for collision with ball
            if (ball.Paddle_Pong() == true) {
                if (paddle.Position_Paddle() <= ball.Ball_Position() && paddle.Position_Paddle_Size() >= ball.Ball_Position())
                {
                    ball.Hit();
                    using (var soundPlayer = new SoundPlayer(Properties.Resources.pongHit))
                    {
                        soundPlayer.Play();
                    }
                }
            }
        }

        //Computer paddle
        public void Computer_Hit()
        {
            //Checks for collision with ball
            if (ball.Computer_Pong() == true)
            {
                if (computer.Position_Computer() <= ball.Ball_Position() && computer.Position_Computer_Size() >= ball.Ball_Position())
                {
                    ball.Hit();
                    using (var soundPlayer = new SoundPlayer(Properties.Resources.pongHit))
                    {
                        soundPlayer.Play(); 
                    }
                }
            }
        }

        //Computer movement
        public void Computer_Movement()
        {
            //Updates players movement through ball position
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
