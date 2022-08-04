using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamWalletDemoApp.Services;

namespace XamWalletDemoApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            switch(Device.RuntimePlatform)
            {
                case Device.iOS:
                    AddToWalletButton_iOS.IsVisible = true;
                    break;
            }
            
            
        }

        void AddToWalletButton_Clicked(System.Object sender, System.EventArgs e)
        {
            DependencyService.Get<IWalletService>().AddPassToWallet();
        }

        void AddPassButton_Clicked(System.Object sender, System.EventArgs e)
        {
            DependencyService.Get<IWalletService>().AddPassToWallet();
        }
    }
}
