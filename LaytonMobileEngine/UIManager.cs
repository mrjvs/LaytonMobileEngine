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

        public UIManager(GraphicsDevice g)
        {
            gDevice = g;
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
