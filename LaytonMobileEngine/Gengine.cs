using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Drawing;
using System.Diagnostics;

namespace LME
{
    class Gengine
    {
        /*--Members--*/
        private Graphics drawHandle;
        private Thread renderThread;
        private Boolean isRunning = false;

        /*--Methods--*/

        public Gengine(Graphics g)
        {
            drawHandle = g;
        }

        public void Init()
        {
            renderThread = new Thread(new ThreadStart(Loop));
            if (!isRunning)
            {
                System.Console.WriteLine("Starting game engine");
                isRunning = true;
                renderThread.Start();
            }
        }

        public void Stop()
        {
            System.Console.WriteLine("Stopping game engine");
            renderThread.Abort();
        }

        private void Loop()
        {
            int framesRendered = 0;
            DateTime startTime = DateTime.UtcNow;
            long startFrames = Environment.TickCount;

            while (true)
            {
                Update();

                if ((DateTime.UtcNow - startTime).TotalMilliseconds >= 16.666)
                {
                    Render();
                    framesRendered++;
                    startTime = DateTime.UtcNow;
                }

                if (Environment.TickCount >= startFrames + 1000)
                {
                    Debug.WriteLine("graphics > " + framesRendered + " fps");
                    startFrames = Environment.TickCount;
                    framesRendered = 0;
                }
            }
        }

        //game logic
        private void Update()
        {

        }

        //render frame
        private void Render()
        {
            drawHandle.DrawRectangle(new Pen(Brushes.Aqua), 10, 10, 500, 500);
        }
    }
}
