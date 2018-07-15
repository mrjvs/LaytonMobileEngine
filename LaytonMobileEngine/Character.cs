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
        public List<int> dialogList;
        public Rectangle spriteArea;

        public string characterName;

        public Character(int spriteIndex, List<int> dialogList, Rectangle area, string cName)
        {
            characterSpriteIndex = spriteIndex;
            this.dialogList = dialogList;
            spriteArea = area;
            characterName = cName;
        }
    }
}
