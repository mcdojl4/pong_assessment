using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pongAssessment
{
    public abstract class Graphic
    {
        public int SIZE = 10;

        protected Graphics graphics;
        protected Color color;
        protected Point position;
        protected Point velocity;
        protected Brush brush;
        
        public Graphic(Graphics graphics, Color color, Point position, Point velocity)
        {     
            this.graphics = graphics;
            this.color = color;
            brush = new SolidBrush(color); 
            this.position = position;
            this.velocity = velocity;   
        }

        public abstract void Draw();    
    }
}
