using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using PassKit;
using XamWalletDemoApp.iOS.CustomRenderers;
using XamWalletDemoApp.CustomControls;

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
                PKAddPassButton btn = new PKAddPassButton(PKAddPassButtonStyle.Black);
                btn.Frame = new CoreGraphics.CGRect(20, 200, 280, 44);
                Control.Add(btn);
            }
        }
    }
}
