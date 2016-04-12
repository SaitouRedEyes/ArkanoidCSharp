using System;
using System.Drawing;

namespace Arkanoid
{
    class Player
    {
        private Rectangle player;
        private SolidBrush brush;
        private bool moveLeft, moveRight;
        private int speedX;

        public Player(int x, int y)
        {
            player = new Rectangle(x - 50, y, 100, 20);
            brush = new SolidBrush(Color.Red);
            moveLeft = moveRight = false;
            speedX = 5;
        }

        public void Update()
        {
            if (moveLeft) player.X -= speedX;
            if (moveRight) player.X += speedX;
            
            if (player.X < 0) player.X = 0;
            else if (player.X + player.Width >= Game.screenWidth) player.X = Game.screenWidth - player.Width;
        }

        public void Draw(Graphics g) { g.FillRectangle(brush, player); }
        
        public Rectangle GetInfo { get{ return player; } }

        public void PreUpdate(System.Windows.Forms.KeyEventArgs e, bool keyDown)
        {
            switch (e.KeyCode)
            {
                case System.Windows.Forms.Keys.Left: moveLeft = keyDown ? true : false; break;
                case System.Windows.Forms.Keys.Right: moveRight = keyDown ? true : false; break;
            }
        }
    }
}