using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaytonMobileEngine
{
    class UIManager
    {

        private Texture2D menuIcon;
        private Texture2D mouseTexture;
        private Rectangle menuLocation;
        public UIMouse mouse;
        private GraphicsDevice gDevice;
        public TrunkManager trunkManager;

        private Double alphaIncrement;
        private Action afterFade;
        private double alpha = 255;
        private int fadeWait;
        private bool isFading = false;
        private bool fadeIn = false;
        private Texture2D fadeTexture;

        public UIManager(GraphicsDevice g)
        {
            gDevice = g;
            fadeTexture = new Texture2D(g, 10, 10);
            Color[] data = new Color[100];
            for (int i = 0; i < data.Length; ++i) data[i] = Color.Black;
            fadeTexture.SetData(data);
        }

        public void loadTextures(String menuIconTexturePath, int menuIconX, int menuIconY, int menuIconSize, String mouseCursorTexturePath, int mouseCursorSize, String trunkBackgroundPath, String trunkButton1Path, String trunkButton2Path)
        {
            mouse = new UIMouse(mouseCursorSize);
            menuIcon = Texture2D.FromStream(gDevice, new FileStream(menuIconTexturePath, FileMode.Open));
            mouseTexture = Texture2D.FromStream(gDevice, new FileStream(mouseCursorTexturePath, FileMode.Open));
            menuLocation = new Rectangle(menuIconX, menuIconY, menuIconSize, menuIconSize);
            trunkManager = new TrunkManager(Texture2D.FromStream(gDevice, new FileStream(trunkBackgroundPath, FileMode.Open)),
                Texture2D.FromStream(gDevice, new FileStream(trunkButton1Path, FileMode.Open)),
                Texture2D.FromStream(gDevice, new FileStream(trunkButton2Path, FileMode.Open)));
        }

        public void draw(SpriteBatch canvas, int screenWidth, int screenHeight)
        {
            canvas.Draw(menuIcon, menuLocation, Color.White);
            trunkManager.draw(canvas, screenWidth, screenHeight);

            canvas.Draw(mouseTexture, mouse.mousePos, Color.White);
            if (isFading) canvas.Draw(fadeTexture, new Rectangle(0, 0, screenWidth, screenHeight), new Color(255, 255, 255, (int) alpha));
        }

        public bool click(int mouseX, int mouseY)
        {
            if (isFading) return true;

            if (trunkManager.isOpen)
            {
                //trunk click stuff
                return true;
            }

            if (menuLocation.Contains(new Point(mouseX,mouseY)))
            {
                //open trunk
                transitionScreen(true, 10, trunkManager.openTrunk);
                return true;
            }

            return false;
        }

        public void update()
        {
            if (isFading)
            {   
                if (fadeIn)
                {
                    if (alpha < 255)
                    {
                        alpha += alphaIncrement;
                    }
                    else
                    {
                        alpha = 255;
                        if (fadeWait > 0)
                        {
                            fadeWait--;
                            if (fadeWait == 0) afterFade();
                        }
                        else
                        {
                            fadeIn = false;
                        }
                    }
                } else
                {
                    alpha -= alphaIncrement;
                    if (alpha <= 0)
                    {
                        alpha = 0;
                        isFading = false;
                    }
                }
            }
        }

        //SCREEN TRANSITION
        public void transitionScreen(bool fast, int framesWait, Action callback)
        {
            if (fast)
            {
                alphaIncrement = 10;
            } else
            {
                alphaIncrement = 2;
            }
            fadeWait = framesWait;
            afterFade = callback;
            isFading = true;
            fadeIn = true;
            alpha = 0;
        }

    }

    class UIMouse
    {
        public int mouseX = 0;
        public int mouseY = 0;
        private int cursorSize;

        public Rectangle mousePos {
            get {
                return new Rectangle(mouseX, mouseY, cursorSize, cursorSize);
            }
        }   

        public UIMouse(int cursorSize)
        {
            this.cursorSize = cursorSize;
        }


    }
}
