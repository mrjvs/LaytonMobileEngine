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

        public UIManager(GraphicsDevice g)
        {
            gDevice = g;
        }

        public void loadTextures(String menuIconTexturePath, int menuIconX, int menuIconY, int menuIconSize, String mouseCursorTexturePath, int mouseCursorSize)
        {
            mouse = new UIMouse(mouseCursorSize);
            menuIcon = Texture2D.FromStream(gDevice, new FileStream(menuIconTexturePath, FileMode.Open));
            mouseTexture = Texture2D.FromStream(gDevice, new FileStream(mouseCursorTexturePath, FileMode.Open));
            menuLocation = new Rectangle(menuIconX, menuIconY, menuIconSize, menuIconSize);
        }

        public void draw(SpriteBatch canvas, int screenWidth, int screenHeight)
        {
            canvas.Draw(menuIcon, menuLocation, Color.White);
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
