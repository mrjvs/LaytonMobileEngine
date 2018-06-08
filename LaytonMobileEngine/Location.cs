using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaytonMobileEngine
{
    class Location
    {
        private Character chars = new Character();
        private Texture2D bgText;

        public Location(Texture2D texture)
        {
            bgText = texture;
        }

        public Character getCharacters()
        {
            return chars;
        }

        public void draw(SpriteBatch canvas, int screenWidth, int screenHeight)
        {
            canvas.Draw(bgText, new Rectangle(0, 0, screenWidth, screenHeight), Color.White);
        }
    }
}
