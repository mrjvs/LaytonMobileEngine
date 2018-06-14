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
        private string objectKind;
        private Dictionary<string, string> commands = new Dictionary<string, string>();

        public ScriptFileParser() {
            Console.WriteLine("Script File Parser initialized"); //for debugging purposes
        }

        public void loadFile(string path) {
            if (File.Exists(path))
            {
                StreamReader file = new StreamReader(path);
                while ((line = file.ReadLine()) != null) //iterate over every line in the file
                {
                    handleLine(line);
                }
            }
            else
            {
                Console.WriteLine("Path to script file not found"); //more debugging    
            }
        }

        private void handleLine(string line)
        {

            if (line[0] != '[')
            {
                string[] splitLine = line.Split('='); //splitting command and value
                string command = splitLine[0];
                string commandValue = splitLine[1];

                commands.Add(command, commandValue);
            }
            else if (line[0] == '[' && line[1] != '/')
            {

                //Isolating the object name from the square braces
                string halfIsolatedLine = line.Replace("[", String.Empty);
                string isolatedLine = halfIsolatedLine.Replace("]", String.Empty);

                objectKind = isolatedLine.ToLower();
            }
            else if (line[0] == '[' && line[1] == '/')
            {
                createObject(objectKind, commands);
                objectKind = "";
                commands.Clear(); //Clears dictionary of commands to make it ready for the next object
            }
            else
            {
                Console.WriteLine("Could not read line.");
            }
        }

        private void createObject(string objectKind, Dictionary<string, string> commands) 
        {
            switch (objectKind)
            {
                case "location":
                    Console.WriteLine("List of commands for object location:");
                    foreach (KeyValuePair<string, string> commandPair in commands)
                    {
                        Console.WriteLine(commandPair.Key + " has the value " + commandPair.Value);
                    }
                    break;
            }
        }

    }
}