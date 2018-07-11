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
        private List<Character> chars;
        private Texture2D bgText;

        public Location(Texture2D texture, List<Character> charList)
        {
            bgText = texture;
            chars = charList;
        }

        public List<Character> getCharacters()
        {
            return chars;
        }

        public void draw(SpriteBatch canvas, CharacterSpriteManager sprites, int screenWidth, int screenHeight)
        {
            canvas.Draw(bgText, new Rectangle(0, 0, screenWidth, screenHeight), Color.White);

            foreach(Character c in chars)
            {
                canvas.Draw(sprites.spriteList[c.characterSpriteIndex], c.spriteArea, Color.White);
            }
        }

        public bool click(int mouseX, int mouseY)
        {
            foreach (Character c in chars)
            {
                if (c.spriteArea.Contains(new Point(mouseX, mouseY)))
                {
                    


                    return true;
                }
            }

            //hint coin click detection

            //location action click detection

            return false;
        }
    }
}
