using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WifiOpcLink
{
    public class WifiOpcLinkApp
    {

        public Project Project { get; set; }

        private string defaultFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\WifiOpcLink.wop";

        public WifiOpcLinkApp()
        {
            if (File.Exists(defaultFile))
            {
                string data = File.ReadAllText(defaultFile);
                Project = JsonConvert.DeserializeObject<Project>(data);
            }
            else
            {
                Project = new Project();
            }
        }

        public void SaveDefaultFile()
        {
            string data = JsonConvert.SerializeObject(Project);
            File.WriteAllText(defaultFile, data);
        }
    }
}
