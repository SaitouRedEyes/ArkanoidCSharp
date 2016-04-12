using System;
using System.Windows.Forms;

namespace Arkanoid
{
    public partial class Game : Form
    {
        public static int screenWidth;
        public static int screenHeight;        
        private SceneManager sceneManager;
        
        public Game()
        {
            InitializeComponent();
            CenterToScreen();

            screenWidth = this.Width;
            screenHeight = this.Height;
            sceneManager = SceneManager.GetInstance();
            sceneManager.CurrScene = new Menu();

            //Turn on double-buffering to eliminate flickering
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);

            //Create Event Handler for Timer Tick. Every time timer Ticks run UpdateGame method
            Timer timer = new Timer(); 
            timer.Interval = 1;
            timer.Start();            
            timer.Tick += new EventHandler(UpdateGame);
             
            //Create Event Handler for Paint run. Every time Windows says it's time to repaint the canvas, run DrawGame method
            Paint += new PaintEventHandler(DrawGame);
        }

        /// <summary>
        /// Main Update of the game.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateGame(object sender, EventArgs e)
        {
            sceneManager.CurrScene.Update();
            Invalidate();
        }

        /// <summary>
        /// Main draw of the game.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="PaintNow"></param>
        private void DrawGame(Object sender, PaintEventArgs PaintNow) { sceneManager.CurrScene.Draw(PaintNow.Graphics); }       

        /// <summary>
        /// Input keyboard down handler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnKeyDownHandler(object sender, KeyEventArgs e) 
        {
            if (e.KeyCode != Keys.Escape) sceneManager.CurrScene.KeyboardInputHandler(e, true);
            else
            {
                GC.Collect(0);
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// Input keyboard up handler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnKeyupHandler(object sender, KeyEventArgs e) { sceneManager.CurrScene.KeyboardInputHandler(e, false); }
    }
}