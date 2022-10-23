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
                //Thread.Sleep(10000);
                label4.Hide();
                label1.Show();
                button1.Show();
                button2.Show();
                button3.Show();

                StreamWriter sw = new StreamWriter(Properties.Resources.Highscore);
                sw.WriteLine("WIN: " + controller.computerScoreboard.ToString() + " to " + controller.paddleScoreboard.ToString());
                sw.Close();

            }
            else if (controller.computerScoreboard == 10)
            {
                timer1.Enabled = false;
                label4.Text = "Sorry you lost " + controller.computerScoreboard.ToString() + " to " + controller.paddleScoreboard.ToString() + ".";
                label4.Show();
                using (var soundPlayer = new SoundPlayer(Properties.Resources.Losing_Horn))
                {
                    soundPlayer.Play();
                }
                //Thread.Sleep(10000);
                label4.Hide();
                label1.Show();
                button1.Show();
                button2.Show();
                button3.Show();

                StreamWriter sw = new StreamWriter(Properties.Resources.Highscore);
                sw.WriteLine("LOSS: " + controller.computerScoreboard.ToString() + " to " + controller.paddleScoreboard.ToString());
                sw.Close();

            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
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
            label1.Hide();
            button1.Hide();
            button2.Hide();
            button3.Hide();
            timer1.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            controller.Restart_Game();
            label1.Hide();
            button1.Hide();
            button2.Hide();
            button3.Hide();
            timer1.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
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
            label1.Hide(); 
            label2.Hide();
            label3.Hide();
            button1.Hide();
            button2.Hide();
            button3.Hide();
            button4.Show();
            listBox1.Show();
        }
    }
}