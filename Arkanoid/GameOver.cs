using System;
using System.Drawing;
using System.Collections.Generic;

namespace Arkanoid
{
    class GameOver : Scene
    {
        private Image background;
        private Score score;
        private Score highscore;

        public GameOver(bool win, Score score, Score highscore)
        { 
            if(win) this.background = Image.FromFile(@"..\..\Images\Win.jpg");
            else this.background = Image.FromFile(@"..\..\Images\Lose.jpg");

            this.score = score;
            this.highscore = highscore;
        }
 
        public override void Update() { }
        
        public override void Draw(Graphics g) 
        { 
            g.DrawImage(this.background, new Point(0, 0));
            score.Draw(g, "Score:");
            highscore.Draw(g, "Highscore:");
        }

        public override void KeyboardInputHandler(System.Windows.Forms.KeyEventArgs e, bool keyDown)
        {
            if (keyDown && e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                if (score.Value > highscore.Value)
                {
                    highscore.Value = score.Value;
                    Dictionary<string, string> d = new Dictionary<string, string>();
                    d.Add("sID", ((int)Http.Services.SET_HIGHSCORE).ToString());
                    d.Add("value", highscore.Value.ToString());

                    SceneManager.GetInstance().CurrScene = new Load(d);
                }
                else SceneManager.GetInstance().CurrScene = new Menu();
            }
        }
    }
}