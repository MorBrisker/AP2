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
        public int MazeRows
        {
            get { return MVVM.Properties.Settings.Default.MazeRows; }
            set { MVVM.Properties.Settings.Default.MazeRows = value; }
        }
        public int MazeCols
        {
            get { return MVVM.Properties.Settings.Default.MazeCols; }
            set { MVVM.Properties.Settings.Default.MazeCols = value; }
        }
        public int SearchAlgorithm
        {
            get { return MVVM.Properties.Settings.Default.SearchAlgorithm; }
            set { MVVM.Properties.Settings.Default.SearchAlgorithm = value; }
        }
        public void SaveSettings()
        {
            MVVM.Properties.Settings.Default.Save();
        }
    }
}
