using System;
using System.Drawing;

namespace Arkanoid
{
    class Block
    {
        private Rectangle block;
        private SolidBrush brush;
        private bool isDead;

        public Block(int currRow, int currColumn)
        {
            block = new Rectangle(10 + (currColumn * 50) + (currColumn * 5), 
                                  10 + (currRow * 30) + (currRow * 5), 
                                  50, 30);
            brush = new SolidBrush(Color.Green);
            isDead = false;
        }

        public void Draw(Graphics g)
        {
            if(!isDead) g.FillRectangle(brush, block);
        }
        public Rectangle GetInfo
        {
            get { return block; }
        }

        public bool IsDead
        {
            get { return isDead;  }
            set { isDead = value; }
        }
    }
}