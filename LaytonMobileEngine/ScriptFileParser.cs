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
        private string line;

        public ScriptFileParser() {
            Console.WriteLine("Script File Parser initialized"); //for debugging purposes
        }

        public void loadFile(string path) {
            if (File.Exists(path))
            {
                StreamReader file = new StreamReader(path);
                while ((line = file.ReadLine()) != null) //iterate over every line in the file
                {
                    string[] splitLine = line.Split('='); //splitting command and value
                    string command = splitLine[0];
                    string commandValue = splitLine[1];
                    Console.WriteLine("Command: " + command); //Debugging purposes
                    Console.WriteLine("Value: " + commandValue); //Debugging purposes
                }
            }
            else
            {
                Console.WriteLine("Path to script file not found"); //more debugging    
            }
        }

    }
}
