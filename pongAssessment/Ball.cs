using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace pongAssessment
{
    public class Ball : Graphic
    {

        public int ball_position;

        public bool playerScore;
        public bool computerScore;

        public Ball(Graphics bufferGraphics, Color color, Point position, Point velocity) : base(bufferGraphics, color, position, velocity)
        {
        }

        public override void Draw()
        {
            //Draws ball
            bufferGraphics.FillEllipse(brush, new Rectangle(position.X, position.Y, BALLSIZE, BALLSIZE));
        }

        public void Move()
        {
            //Moves ball
                position.Y += velocity.Y;
                position.X += velocity.X;
        }


        public void Restart()
        {
            //Restarts ball at different positions
            Random rand = new Random();
            int random = rand.Next(1, 10);
            for (int i = 0; i < random; i++)
            {
                velocity.X *= -1;
            }
            random = rand.Next(1, 10);
            for (int i = 0; i < random; i++)
            {
                velocity.Y *= -1;
            }

            position.X = 500 - (10 / 2);
            position.Y = (700 / 2) - (10 / 2);
        }

        public void Bounce()
        {
            //Makes ball bounce of walls
            if ((position.Y + BALLSIZE) + 65 >= Boundaries.Height)
            {
                velocity.Y *= -1;
                using (var soundPlayer = new SoundPlayer(Properties.Resources.pongHit))
                {
                    soundPlayer.Play();
                }
            }
            if (position.Y - 15 <= 0)
            {
                velocity.Y *= -1;
                using (var soundPlayer = new SoundPlayer(Properties.Resources.pongHit))
                {
                    soundPlayer.Play();
                }
            }
        }

        public int Ball_Position()
        {
            //Allows ball position to be used in controller
            ball_position = position.Y + BALLSIZE;

            return ball_position;
        }

        public void Hit()
        {
            //Changes direction
            velocity.X *= -1;
        }

        public bool Paddle_Pong()
        {
            //Checks if it collides with player
            bool player = false;
            if (position.X <= 60)
            {
                player = true;
                
            }
            return player;
        }

        public bool Computer_Pong()
        {
            //checks if collides with computer
            bool computer = false;
            if (position.X + BALLSIZE >= Boundaries.Width - 65)
            {
                computer = true;

            }
            return computer;
        }

        public bool Paddle_Score()
        {
            //Checks if paddle wins
            playerScore = false;
            if (position.X + BALLSIZE >= Boundaries.Width + 20)
            {
                playerScore = true;

            }
            return playerScore;
        }

        public bool Computer_Score()
        {
            //checks if computer wins
            computerScore = false;
            if (position.X <= -20)
            {
                computerScore = true;

            }
            return computerScore;
        }

    }
}
