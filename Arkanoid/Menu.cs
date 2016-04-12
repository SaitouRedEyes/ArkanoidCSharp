using System;
using System.Drawing;
using System.Collections.Generic;

namespace Arkanoid
{
    class Menu : Scene
    {
        private Image background;
        
        public Menu() { this.background = Image.FromFile(@"..\..\Images\MenuBackground.jpg"); }
 
        public override void Update() { }
        
        public override void Draw(Graphics g) { g.DrawImage(this.background, new Point(0, 0)); }

        public override void KeyboardInputHandler(System.Windows.Forms.KeyEventArgs e, bool keyDown)
        {
            if (keyDown && e.KeyCode == System.Windows.Forms.Keys.Return)
            {                
                Dictionary<string, string> d = new Dictionary<string, string>();
                d.Add("sID", ((int)Http.Services.GET_HIGHSCORE).ToString());

                SceneManager.GetInstance().CurrScene = new Load(d);
            }
        }
    }
}