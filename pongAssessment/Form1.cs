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
            graphics = CreateGraphics();
            bufferImage = new Bitmap(Width, Height);
            bufferGraphics = Graphics.FromImage(bufferImage);
            controller = new Controller(graphics);
            timer1.Enabled = true;
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

                default:

                    break;
            }
        }
    }
}