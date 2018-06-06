using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Drawing;

namespace LME
{
    class Gengine
    {
        /*--Members--*/
        private Graphics drawHandle;
        private Graphics FrameGraphics;
        private Thread renderThread;
        private Boolean isRunning = false;
        private Boolean Run = false;

        //graphics vars
        const Int32 WindowHeight = 720;
        const Int32 WindowWidth = 1200;
        Bitmap Frame = new Bitmap(WindowWidth, WindowHeight);

        //game vars
        Location CurrentLocation;
        Character TempChar;

        /*--Methods--*/

        public Gengine(Graphics g)
        {
            drawHandle = g;
            CurrentLocation = new Location();
            TempChar = new Character();
        }

        private void LoadAssets()
        {

        }

        public void Init()
        {
            renderThread = new Thread(new ThreadStart(Loop));
            if (!isRunning && false)
            {
                System.Console.WriteLine("Starting game engine");
                isRunning = true;
                Run = true;
                renderThread.Start();
            }
        }

        public void Stop()
        {
            System.Console.WriteLine("Stopping game engine");
            Run = false;
        }

        private void Loop()
        {
            int framesRendered = 0;
            DateTime startTime = DateTime.UtcNow;
            long startFrames = Environment.TickCount;
            FrameGraphics = Graphics.FromImage(Frame);

            while (Run)
            {
                Update();

                if ((DateTime.UtcNow - startTime).TotalMilliseconds >= 16)
                {
                    Render();
                    framesRendered++;
                    startTime = DateTime.UtcNow;
                }

                if (Environment.TickCount >= startFrames + 1000)
                {
                    System.Console.WriteLine("graphics > " + framesRendered + " fps");
                    startFrames = Environment.TickCount;
                    framesRendered = 0;
                }
            }

            System.Console.WriteLine("rendering thread stopped");
        }

        //game logic
        private void Update()
        {

        }

        //render frame
        private void Render()
        {
            DateTime startTimed = DateTime.UtcNow;
            //draw BG
            FrameGraphics.DrawImage(CurrentLocation.LocationBackground, 0, 0, WindowWidth, WindowHeight);
            Console.WriteLine((DateTime.UtcNow - startTimed).TotalMilliseconds + "ms drawing BACKGROUND------");

            startTimed = DateTime.UtcNow;

            //draw CHAR
            FrameGraphics.DrawImage(TempChar.CharacterSprite, TempChar.CharacterPos);
            Console.WriteLine((DateTime.UtcNow - startTimed).TotalMilliseconds + "ms drawing CHAR");

            startTimed = DateTime.UtcNow;
            //draw final
            drawHandle.DrawImage(Frame, 0, 0);
            Console.WriteLine((DateTime.UtcNow - startTimed).TotalMilliseconds + "ms drawing frame");
        }
    }
}
