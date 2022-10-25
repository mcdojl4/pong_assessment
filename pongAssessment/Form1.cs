namespace pongAssessment
{
    using System.Media;

    public partial class Form1 : Form
    {
        public Graphics graphics;
        private Graphics bufferGraphics;
        private Bitmap bufferImage;
        public Controller controller;

        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
            graphics = CreateGraphics();
            bufferImage = new Bitmap(Width, Height);
            bufferGraphics = Graphics.FromImage(bufferImage);
            controller = new Controller(graphics);

            label4.Hide();
            listBox1.Hide();
            button4.Hide();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //When timer ticks game runs
            Refresh();
            controller.Run();
            controller.Reload();
            graphics.DrawImage(bufferImage, 0, 0);
            label2.Text = (controller.paddleScoreboard.ToString());
            label3.Text = (controller.computerScoreboard.ToString());


            if (controller.paddleScoreboard == 10)
            {
                timer1.Enabled = false;
                label4.Text = "Congrats you won " + controller.computerScoreboard.ToString() + " to " + controller.paddleScoreboard.ToString() + ".";
                label4.Show();
                using (var soundPlayer = new SoundPlayer(Properties.Resources.Victory_Sound))
                {
                    soundPlayer.Play();
                }
                Thread.Sleep(5000);
                label4.Hide();
                label1.Show();
                button1.Show();
                button2.Show();
                button3.Show();

                using (StreamWriter sw = File.AppendText("Highscore.txt"))
                {
                    sw.WriteLine("WIN: " + controller.computerScoreboard.ToString() + " to " + controller.paddleScoreboard.ToString());
                }

            }
            else if (controller.computerScoreboard == 10)
            {
                timer1.Enabled = false;
                using (var soundPlayer = new SoundPlayer(Properties.Resources.Losing_Horn))
                {
                    soundPlayer.Play();
                }
                //label4.Text = "Sorry you lost " + controller.computerScoreboard.ToString() + " to " + controller.paddleScoreboard.ToString() + ".";
                Thread.Sleep(3000);
                label4.Text = "Please Say something";
                label4.Show();
                
                label4.Hide();
                label1.Show();
                button1.Show();
                button2.Show();
                button3.Show();

                using (StreamWriter sw = File.AppendText("Highscore.txt"))
                {
                    sw.WriteLine("LOSS: " + controller.computerScoreboard.ToString() + " to " + controller.paddleScoreboard.ToString());
                }

            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //Lets player press buttons to move
            switch (e.KeyCode)
            {
                case Keys.Up:
                    controller.PaddleUp();
                    break;

                case Keys.Down:
                    controller.PaddleDown();
                    break;

                case Keys.Escape:
                    timer1.Enabled = false;
                    label1.Show();
                    button1.Show();
                    button2.Show();
                    button3.Show();
                    break;

                default:
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Makes game play and unpause
            label1.Hide();
            button1.Hide();
            button2.Hide();
            button3.Hide();
            timer1.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Makes game restart
            controller.Restart_Game();
            label1.Hide();
            button1.Hide();
            button2.Hide();
            button3.Hide();
            timer1.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Makes it return from highscore screen
            listBox1.Hide();
            label1.Show();
            label2.Show();
            label3.Show();
            button1.Show();
            button2.Show();
            button3.Show();
            button4.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Makes high score screen
            label1.Hide();
            label2.Hide();
            label3.Hide();
            button1.Hide();
            button2.Hide();
            button3.Hide();
            button4.Show();

            int lineCounter = 0;
            using (var reader = new StreamReader("Highscore.txt"))
            {
                while (reader.ReadLine() != null)
                {
                    lineCounter++;
                }
            }

            using (StreamReader sr = new StreamReader("Highscore.txt"))
            {
                int Five = lineCounter - 5;
                for (int i = 0; i < lineCounter; i++)
                    if (i >= Five)
                    {
                        string temp = sr.ReadLine();
                        listBox1.Items.Add(temp);
                    }
                    else
                    {
                        sr.ReadLine();
                    }
            }
            listBox1.Show();
        }
    }
}