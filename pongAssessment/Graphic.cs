using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pongAssessment
{
    public abstract class Graphic
    {
        public int BALLSIZE = 20;
        public const int PADDLESIZE_X = 20; 
        public const int PADDLESIZE_Y = 200; 

        //protected Graphics graphics;
        protected Graphics bufferGraphics;
        protected Color color;
        protected Point position;
        protected Point velocity;
        protected Brush brush;
        public Graphic(Graphics bufferGraphics, Color color, Point position, Point velocity)
        {
            this.bufferGraphics = bufferGraphics;
            this.color = color;
            brush = new SolidBrush(color);
            this.position = position;
            this.velocity = velocity;
        }

        public abstract void Draw();    
    }
}
