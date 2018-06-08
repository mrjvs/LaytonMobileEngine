using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaytonMobileEngine
{
    class LocationManager
    {
        private Location locations;

        public LocationManager(ContentManager content, GraphicsDevice g)
        {
            FileStream fileStream = new FileStream("C:\\Users\\jelle\\Downloads\\layton-bg.png", FileMode.Open);
            locations = new Location(Texture2D.FromStream(g, fileStream));
        }

        public Location currentLocation
        {
            get { return locations; }
        }
    }
}
