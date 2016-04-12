using System;
using System.Drawing;
using System.Collections.Generic;

namespace Arkanoid
{
    class Ball
    {
        private Rectangle ball;
        private SolidBrush brush;
        private int speedX, speedY;
        private bool couldCollide;
      
        public Ball(int x, int y)
        {
            ball = new Rectangle(x, y, 30, 30);
            brush = new SolidBrush(Color.Blue);
            speedX = speedY = 4;
            couldCollide = true;
        }        

        public void Update(Player player, List<Block> blocks, Score score, Score highscore)
        {
            ball.X += speedX;
            ball.Y -= speedY;

            CollisionWithScreen(score, highscore);
            CollisionWithPlayer(player);
            CollisionWithBlocks(blocks, score);
        }

        public void Draw(Graphics g) { g.FillEllipse(brush, ball); }

        public Rectangle GetInfo { get { return ball; } }

        private void CollisionWithScreen(Score score, Score highscore)
        {
            if (ball.X < 0 || ball.X + ball.Width > Game.screenWidth) speedX *= -1;

            if (ball.Y < 0) speedY *= -1;
            else if (ball.Y + ball.Height > Game.screenHeight) SceneManager.GetInstance().CurrScene = new GameOver(false, score, highscore);
        }

        private void CollisionWithPlayer(Player player)
        {
            if (ball.Y < player.GetInfo.Y + player.GetInfo.Height)
            {
                if (ball.X < player.GetInfo.X + player.GetInfo.Width &&
                    ball.X + ball.Width > player.GetInfo.X &&
                    ball.Y < player.GetInfo.Y + player.GetInfo.Height &&
                    ball.Y + ball.Height > player.GetInfo.Y)
                {
                    if (ball.X < player.GetInfo.X && speedX > 0) speedX *= -1;
                    else if (ball.X > player.GetInfo.X + player.GetInfo.Width && speedX < 0) speedX *= -1;

                    speedY *= -1;
                }
            }
        }

        private void CollisionWithBlocks(List<Block> blocks, Score score)
        {
            foreach (Block block in blocks)
            {
                if (!block.IsDead && couldCollide &&
                    ball.X <= block.GetInfo.X + block.GetInfo.Width &&
                    ball.X + ball.Width >= block.GetInfo.X &&
                    ball.Y <= block.GetInfo.Y + block.GetInfo.Height &&
                    ball.Y + ball.Height >= block.GetInfo.Y)
                {
                    speedY *= -1;
                    block.IsDead = true;
                    couldCollide = false;
                    score.Value += 10 * new Random().Next(1,4);
                    break;
                }
                else couldCollide = true;                
            }
        }
    }
}