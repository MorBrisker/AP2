﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace MVVM.ViewModel
{
    public class SettingsViewModel : ViewModel
    {
        private ISettingsModel model;
        //private SettingsWindow

        public SettingsViewModel()
        {
            this.model = new ApplicationSettingsModel();
        }
        public string ServerIP
        {
            get { return model.ServerIP; }
            set
            {
                model.ServerIP = value;
                NotifyPropertyChanged("ServerIP");
            }
        }
        public int ServerPort
        {
            get { return model.ServerPort; }
            set
            {
                model.ServerPort = value;
                NotifyPropertyChanged("ServerPort");
            }
        }

        public void SaveSettings()
        {
            model.SaveSettings();
        }
    }
}