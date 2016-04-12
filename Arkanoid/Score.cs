using System;
using System.Drawing;

namespace Arkanoid
{
    class Score
    {
        private int value;
        private Font font;
        private SolidBrush brush;
        private Point pos;

        public Score(int x, int y, int value) 
        {
            this.value = 0;
            font = new Font("Arial", 14.0f);
            brush = new SolidBrush(Color.White);
            pos = new Point(x, y);
            this.value = value;
        }        
     
        public int Value
        {
            get { return this.value; }
            set { this.value = value;  }
        }

        public void Draw(System.Drawing.Graphics g, String text) {  g.DrawString(text + " " + value.ToString(), font, brush, pos); }
    }
}