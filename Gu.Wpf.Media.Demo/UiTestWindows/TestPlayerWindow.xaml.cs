﻿namespace Gu.Wpf.Media.Demo.UiTestWindows
{
    using System.Windows;

    public partial class TestPlayerWindow : Window
    {
        public TestPlayerWindow()
        {
            this.InitializeComponent();
            this.DataContext = new TestPlayerViewModel(this.MediaElement);
        }
    }
}