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
            bufferGraphics.FillEllipse(brush, new Rectangle(position.X, position.Y, BALLSIZE, BALLSIZE));
        }

        public void Move()
        {
                position.Y += velocity.Y;
                position.X += velocity.X;
        }


        public void Restart()
        {
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
            ball_position = position.Y + BALLSIZE;

            return ball_position;
        }

        public void Hit()
        {
            velocity.X *= -1;
        }

        public bool Paddle_Pong()
        {
            bool player = false;
            if (position.X <= 70)
            {
                player = true;
                
            }
            return player;
        }

        public bool Computer_Pong()
        {
            bool computer = false;
            if (position.X + BALLSIZE >= Boundaries.Width - 70)
            {
                computer = true;

            }
            return computer;
        }

        public bool Paddle_Score()
        {
            playerScore = false;
            if (position.X + BALLSIZE >= Boundaries.Width)
            {
                playerScore = true;

            }
            return playerScore;
        }

        public bool Computer_Score()
        {
            computerScore = false;
            if (position.X < 0)
            {
                computerScore = true;

            }
            return computerScore;
        }

    }
}
