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

        public ScriptLoader(LocationManager loc)
        {
            l = loc;
        }

        public void loadScript(String path)
        {
            l.addLocation("C:\\Users\\jelle\\Downloads\\layton-bg.png");
        }
    }
}
