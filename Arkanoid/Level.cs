using System;
using System.Drawing;
using System.Collections.Generic;


namespace Arkanoid
{
    class Level: Scene
    {
        private Image background;
        private Player player;
        private Ball ball;
        private BlockManager blockManager;
        private Score score, highScore;

        public Level(int highscore)
        {
            this.background = Image.FromFile(@"..\..\Images\Level1Background.jpg");
            
            player = new Player(Game.screenWidth / 2, (int)(Game.screenHeight * 0.85f));
            ball = new Ball(Game.screenWidth / 2, Game.screenHeight / 2);
            blockManager = new BlockManager();
            score = new Score(10, 570, 0);            
            this.highScore = new Score(630, 570, highscore); 
        }        
 
        public override void Update()
        {
            player.Update();
            ball.Update(player, blockManager.GetBlocks, score, highScore);

            EndGame();
        }
        
        public override void Draw(Graphics g)
        {            
            g.DrawImage(this.background, new Point(0, 0));            

            player.Draw(g);
            ball.Draw(g);
            blockManager.Draw(g);
            score.Draw(g, "Score:");
            highScore.Draw(g, "HighScore:");
        }

        public override void KeyboardInputHandler(System.Windows.Forms.KeyEventArgs e, bool keyDown) { player.PreUpdate(e, keyDown); }

        private void EndGame()
        {
            foreach (Block block in blockManager.GetBlocks)
            {
                if (!block.IsDead) break;
                else
                {
                    if (blockManager.GetBlocks.IndexOf(block) == blockManager.GetBlocks.Count - 1)
                        SceneManager.GetInstance().CurrScene = new GameOver(true, score, highScore);                    
                }
            }
        }
    }
}