using System;
using Xamarin.Forms;

namespace MediaCustomTransport
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnPlayButtonClicked(object sender, EventArgs e)
        {
            MediaPlayer.Play();
        }

        private void OnPauseButtonClicked(object sender, EventArgs e)
        {
            MediaPlayer.Pause();
        }

        private void OnSetPositionClicked(object sender, EventArgs e)
        {
            MediaPlayer.Position = TimeSpan.FromSeconds(120);
        }
    }
}