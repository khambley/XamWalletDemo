using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PassKit;
using Xamarin.Forms;
using XamWalletDemoApp.Services;

namespace XamWalletDemoApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            
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
