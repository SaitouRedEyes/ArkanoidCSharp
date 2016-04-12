using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading;

namespace Arkanoid
{
    class Load : Scene
    {
        private Image background;        
        private Thread thread;
        private Dictionary<string, string> parameters;
        private string serverResponse;
        private bool loadingComplete;        
        
        public Load(Dictionary<string, string> parameters) 
        { 
            this.background = Image.FromFile(@"..\..\Images\LoadingBackground.jpg");
            loadingComplete = false;
            
            this.parameters = parameters;

            thread = new Thread(new ThreadStart(GetServerResponse));            
            thread.Start();
        }
 
        public override void Update() 
        {
            if (loadingComplete)
            {
                if (!serverResponse.Equals(""))
                {
                    switch (int.Parse(parameters["sID"]))
                    {
                        case (int)Http.Services.GET_HIGHSCORE: 
                            SceneManager.GetInstance().CurrScene = new Level(int.Parse(serverResponse)); break;
                        case (int)Http.Services.SET_HIGHSCORE: 
                            SceneManager.GetInstance().CurrScene = new Menu(); break;
                    }
                }
                else
                {
                    Console.WriteLine("Problemas em conectar com o server!!");
                    SceneManager.GetInstance().CurrScene = new Menu();
                }
            }            
        }

        public override void Draw(Graphics g) { g.DrawImage(this.background, new Point(0, 0)); }

        public override void KeyboardInputHandler(System.Windows.Forms.KeyEventArgs e, bool keyDown) {}

        private void GetServerResponse()
        {
            serverResponse = Http.GetInstance.SendToServer(parameters);
            loadingComplete = true;
            thread.Interrupt();
        }
    }
}