using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaytonMobileEngine
{
    class Character
    {
        public int characterSpriteIndex;
        private List<Dialog> dialogList;
        public Rectangle spriteArea;

        public Character(int spriteIndex, List<Dialog> dialog, Rectangle area)
        {
            characterSpriteIndex = spriteIndex;
            dialogList = dialog;
            spriteArea = area;
        }
    }
}
