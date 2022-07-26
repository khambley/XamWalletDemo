﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using PassKit;
using XamWalletDemoApp.iOS.CustomRenderers;
using XamWalletDemoApp.CustomControls;
using System.IO;
using Foundation;
using XamWalletDemoApp.Services;
using XamWalletDemoApp.iOS.Services;

[assembly: ExportRenderer(typeof(AddToWalletButton), typeof(AddToWalletButtonRenderer))]
namespace XamWalletDemoApp.iOS.CustomRenderers
{
    public class AddToWalletButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);
            if(Control != null)
            {
                if (PKAddPassesViewController.CanAddPasses)
                {
                    var walletService = new WalletService();

                    PKAddPassButton btn = new PKAddPassButton(PKAddPassButtonStyle.Black);
                    btn.Frame = new CoreGraphics.CGRect(50, 200, 300, 44);
                    Control.Add(btn);
                    btn.TouchUpInside += (sender, e2) =>
                    {
                        walletService.AddPassToWallet();
                    };
                    //var newBtn = DependencyService.Get<IWalletService>().AddPassToWallet(btn);
                    //Control.AddSubview(newBtn);
                }
                
                
                
                
            }
        }

        
    }
}
