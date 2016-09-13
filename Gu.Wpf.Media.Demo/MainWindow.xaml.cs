﻿namespace Gu.Wpf.Media.Demo
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Controls.Primitives;
    using System.Windows.Input;

    using Microsoft.Win32;

    public partial class MainWindow : Window
    {
        private MediaState mediaState;

        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void OpenExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = $"Media files|{this.MediaElement.VideoFormats}|All files (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                this.MediaElement.Source = new Uri(openFileDialog.FileName);
            }
        }

        private void OnProgressSliderDragStarted(object sender, DragStartedEventArgs e)
        {
            this.mediaState = this.MediaElement.State;
            this.MediaElement.Pause();
        }

        private void OnProgressSliderDragCompleted(object sender, DragCompletedEventArgs e)
        {
            if (this.mediaState == MediaState.Play)
            {
                this.MediaElement.Play();
            }
        }

        private void OnMediaOpened(object sender, RoutedEventArgs e)
        {
        }
    }
}
