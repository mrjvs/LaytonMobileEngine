using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaytonMobileEngine
{
    class TrunkManager
    {
        public bool isOpen = false;
        private Texture2D backgroundTexture;
        private Texture2D button1Texture;
        private Texture2D button2Texture;

        public TrunkManager(Texture2D bg, Texture2D but1, Texture2D but2)
        {
            backgroundTexture = bg;
            button1Texture = but1;
            button2Texture = but2;
        }
    
        public void draw(SpriteBatch canvas, int screenWidth, int screenHeight)
        {
            canvas.Draw(backgroundTexture, new Rectangle(0, 0, screenWidth, screenHeight), Color.White);
            canvas.Draw(button1Texture, new Rectangle(50, 50, 200, 200), Color.White);
            canvas.Draw(button2Texture, new Rectangle(300, 50, 200, 200), Color.White);
        }
    }
}
