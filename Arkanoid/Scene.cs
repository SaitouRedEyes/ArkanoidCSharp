using System;

namespace Arkanoid
{
    abstract class Scene
    {
        public abstract void Update();
        public abstract void Draw(System.Drawing.Graphics g);
        public abstract void KeyboardInputHandler(System.Windows.Forms.KeyEventArgs e, bool keyDown);
    }
}
