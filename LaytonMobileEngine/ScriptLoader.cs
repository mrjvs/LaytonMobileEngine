using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaytonMobileEngine
{
    class ScriptLoader
    {

        private LocationManager l;
        private CharacterSpriteManager cs;

        public ScriptLoader(LocationManager loc, CharacterSpriteManager spriteManager)
        {
            l = loc;
            cs = spriteManager;
        }

        public void loadScript(String path)
        {
            List<Character> list = new List<Character>();
            list.Add(new Character(0, null, new Rectangle(100, 100, 186, 421)));
            cs.addTexture("C:\\Users\\jelle\\Downloads\\luke.png");
            l.addLocation("C:\\Users\\jelle\\Downloads\\layton-bg.png", list);
        }
    }
}
