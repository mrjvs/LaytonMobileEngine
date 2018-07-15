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
        private DialogueManager dm;

        public ScriptLoader(LocationManager loc, CharacterSpriteManager spriteManager, UIManager uiManager, DialogueManager dialogManager, ScriptFileParser fileParser)
        {
            l = loc;
            cs = spriteManager;
            ui = uiManager;
            fp = fileParser;
            dm = dialogManager;
        }

        public void loadScript(String path)
        {
            //jacob's (soon to be implemented) script loading
            fp.loadFile(path + "\\TestScriptFile.txt");

            //debug script loading
            List<Character> list = new List<Character>();
            list.Add(new Character(0, new List<int> {0}, new Rectangle(100, 100, 186, 421)));
            List<GameAction> actionList = new List<GameAction>
            {
                new TextGameAction("This is a test dialog"),
                new TextGameAction("I hope this is gonna work well"),
                new PuzzleGameAction(0)
            };

            dm.addDialog(new Dialogue(actionList));
            cs.addTexture(path + "\\textures\\luke.png");
            l.addLocation(path + "\\textures\\layton-bg.png", list);
            ui.loadTextures(path + "\\textures\\ui\\trunk.png", 0, 0, 50, path + "\\textures\\ui\\cursor.png", 20, path + "\\textures\\ui\\trunk-background.png", path + "\\textures\\ui\\placeholder-button.png", path + "\\textures\\ui\\placeholder-button2.png");
        }
    }
}
