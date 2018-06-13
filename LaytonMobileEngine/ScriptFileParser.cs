using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LaytonMobileEngine
{
    class ScriptFileParser
    {
        string line;

        public ScriptFileParser() {
            Console.WriteLine("Script File Parser initialized"); //for debugging purposes
        }

        public void loadFile(string path) {
            if (File.Exists(path))
            {
                StreamReader File = new StreamReader(path);
                while ((line = File.ReadLine()) != null) {
                    Console.WriteLine(line);
                }
            }
            else
            {
                Console.WriteLine("Path to script file not found"); //more debugging    
            }
        }

    }
}
