namespace pongAssessment
{
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
            button4.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Refresh();
            controller.Run();
            controller.Reload();
            graphics.DrawImage(bufferImage, 0, 0);

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
                    //button4.Hide();
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
            //button4.Show();
            timer1.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            controller.Restart();
            label1.Hide();
            button1.Hide();
            button2.Hide();
            button3.Hide();
            //button4.Show();
            timer1.Enabled = true;
        }

        //private void button4_Click(object sender, EventArgs e)
        //{
        //    timer1.Enabled = false;
        //    label1.Show();
        //    button1.Show();
        //    button2.Show();
        //    button3.Show();
        //    button4.Hide();
        //}
    }
}