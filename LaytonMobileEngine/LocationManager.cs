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
        private List<Location> locations = new List<Location>();
        private GraphicsDevice gDevice;
        private int locationIndex = 0;
        private DialogManager dialogManager;

        public LocationManager(GraphicsDevice g, DialogManager dm)
        {
            gDevice = g;
            dialogManager = dm;
        }

        public void addLocation(String path, List<Character> chars)
        {
            Texture2D text = Texture2D.FromStream(gDevice, new FileStream(path, FileMode.Open));
            Location loc = new Location(text, chars, dialogManager);
            locations.Add(loc);
        }

        public Location currentLocation
        {
            get { return locations[locationIndex]; }
        }
    }
}
