namespace pongAssessment
{
    public partial class Form1 : Form
    {
        public Graphics graphics;
        public Controller controller;
        public Form1()
        {
            InitializeComponent();

            graphics = CreateGraphics();
            controller = new Controller(graphics);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Refresh();
            controller.Run();
        }
    }
}