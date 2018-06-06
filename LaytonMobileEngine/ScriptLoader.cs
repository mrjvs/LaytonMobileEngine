using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LME
{
    class ScriptLoader
    {
    }

    class Location
    {
        public Bitmap LocationBackground;

        public Location()
        {
            LocationBackground = new Bitmap(Image.FromFile("C:\\Users\\jelle\\Downloads\\layton-bg.png"));
        }

        public Image GetBackground()
        {
            return LocationBackground;
        }
    }

    class Character
    {
        public Bitmap CharacterSprite;
        public Point CharacterPos;

        public Character()
        {
            CharacterSprite = new Bitmap(Image.FromFile("C:\\Users\\jelle\\Downloads\\luke.png"));
            CharacterPos = new Point(400, 300);
        }
    }
}
