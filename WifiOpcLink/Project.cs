using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows.Forms;

namespace WifiOpcLink
{
    public class Project
    {
        public string FilePath { get; set; }

        public OpcServer Server { get; set; }

        public Project()
        {
            Server = new OpcServer();
        }

        public void New()
        {
            var r = MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo);

            if (r == DialogResult.Yes)
            {
                Server = new OpcServer();
            }
        }

        public Project Open()
        {
            var d = new OpenFileDialog()
            {
                Filter = "Wifi Opc Link Project|*.wop"
            };

            if(d.ShowDialog() == DialogResult.OK)
            {
                var file = d.FileName;
                try
                {
                    var content = File.ReadAllText(file);
                    return JsonConvert.DeserializeObject<Project>(content);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return null;
        }

        public void Save()
        {
            if (File.Exists(FilePath))
            {
                SaveFile();
            }
            else
            {
                SaveAs();
            }
        }

        private void SaveFile()
        {
            if(FilePath != "")
            {
                try
                {
                    File.WriteAllText(FilePath, JsonConvert.SerializeObject(this, Formatting.Indented));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void SaveAs()
        {
            var d = new SaveFileDialog()
            {
                Filter = "Wifi Opc Link Project|*.wop"
            };

            if (d.ShowDialog() == DialogResult.OK)
            {
                FilePath = d.FileName;
                SaveFile();
            }
        }
    }
}
