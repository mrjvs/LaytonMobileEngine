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
                while ((line = File.ReadLine()) != null) { //iterate over every line in the file
                    string[] SplitLine = line.Split('='); //splitting command and value
                    string command = SplitLine[0];
                    string CommandValue = SplitLine[1];
                    Console.WriteLine("Command: " + CommandValue); //Debugging purposes
                    Console.WriteLine("Value: " + value); //Debugging purposes
                }
            }
            else
            {
                Console.WriteLine("Path to script file not found"); //more debugging    
            }
        }

    }
}
