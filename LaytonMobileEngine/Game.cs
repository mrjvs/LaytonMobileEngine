using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LME
{
    class Game
    {
        private Gengine engine;

        public void StartGraphics(Graphics g)
        {
            if (engine == null)
            {
                System.Console.WriteLine("Loading game engine");
                engine = new Gengine(g);
                engine.Init();
            }

        }

        public void StopGame()
        {
            engine.Stop();
        }
    }
}
