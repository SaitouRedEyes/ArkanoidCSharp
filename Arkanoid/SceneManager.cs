using System;

namespace Arkanoid
{
    class SceneManager
    {
        private static SceneManager instance;
        private Scene currScene;

        private SceneManager(){}

        public static SceneManager GetInstance()
        {
            if (instance == null) instance = new SceneManager();

            return instance;
        }

        public Scene CurrScene
        {
            get { return this.currScene; }
            set { this.currScene = value; }
        }
    }
}