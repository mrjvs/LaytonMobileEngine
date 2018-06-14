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
        private UIManager ui;
        private ScriptFileParser fp;

        public ScriptLoader(LocationManager loc, CharacterSpriteManager spriteManager, UIManager uiManager, ScriptFileParser fileParser)
        {
            l = loc;
            cs = spriteManager;
            ui = uiManager;
            fp = fileParser;
        }

        public void loadScript(String path)
        {
            //jacob's (soon to be implemented) script loading
            fp.loadFile(path + "\\TestScriptFile.txt");

            //debug script loading
            List<Character> list = new List<Character>();
            list.Add(new Character(0, null, new Rectangle(100, 100, 186, 421)));
            cs.addTexture(path + "\\textures\\luke.png");
            l.addLocation(path + "\\textures\\layton-bg.png", list);
            ui.loadTextures(path + "\\textures\\ui\\trunk.png", 0, 0, 50, path + "\\textures\\ui\\cursor.png", 20);
        }
    }
}
