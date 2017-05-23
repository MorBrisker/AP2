﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MVVM.ViewModel;

namespace MVVM
{
    public partial class SinglePlayer : UserControl
    {

        public SinglePlayer()
        {
            InitializeComponent();
        }

        public string MName
        {
            get { return (string)GetValue(MNameProperty); }
            set { SetValue(MNameProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Rows. This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MNameProperty =
         DependencyProperty.Register("MName", typeof(string), typeof(SinglePlayer));

        public int Rows
        {
            get { return (int)GetValue(RowsProperty); }
            set { SetValue(RowsProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Rows. This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RowsProperty =
         DependencyProperty.Register("Rows", typeof(int), typeof(SinglePlayer));

        public int Cols
        {
            get { return (int)GetValue(ColsProperty); }
            set { SetValue(ColsProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Rows. This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ColsProperty =
         DependencyProperty.Register("Cols", typeof(int), typeof(SinglePlayer));


    }
}
