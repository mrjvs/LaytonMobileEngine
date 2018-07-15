using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaytonMobileEngine
{
    class CharacterSpriteManager
    {
        public List<Texture2D> spriteList = new List<Texture2D>();
        private GraphicsDevice gDevice;

        public CharacterSpriteManager(GraphicsDevice g)
        {
            gDevice = g;
        }

        public void addTexture(String path)
        {
          Texture2D text = Texture2D.FromStream(gDevice, new FileStream(path, FileMode.Open));
            spriteList.Add(text);
        }

    }
}
