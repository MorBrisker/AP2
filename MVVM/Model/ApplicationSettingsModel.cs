using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace MVVM
{
    public class ApplicationSettingsModel : ISettingsModel
    {
        public string ServerIP
        {
            get { return MVVM.Properties.Settings.Default.ServerIP; }
            set { MVVM.Properties.Settings.Default.ServerIP = value; }
        }
        public int ServerPort
        {
            get { return MVVM.Properties.Settings.Default.ServerPort; }
            set { MVVM.Properties.Settings.Default.ServerPort = value; }
        }
        public void SaveSettings()
        {
            MVVM.Properties.Settings.Default.Save();
        }
        public int MazeRows { get; set; }
        public int MazeCols { get; set; }
        public int SearchAlgorithm { get; set; }

    }
}
