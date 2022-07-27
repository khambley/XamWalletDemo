using System;
using System.IO;
using Foundation;
using PassKit;
using UIKit;
using Xamarin.Forms;
using XamWalletDemoApp.iOS.Services;
using XamWalletDemoApp.Services;

[assembly: Dependency(typeof(WalletService))]
namespace XamWalletDemoApp.iOS.Services
{
    public class WalletService : UIViewController, IWalletService
    {
        
        public void AddPassToWallet()
        {
            //new UIAlertView("Wallet Service", "You clicked the Add to Wallet Button", null, "OK", null).Show();

            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var newFilePath = Path.Combine(documentsPath, "IDCard2.pkpass");
            var builtInPassPath = Path.Combine(System.Environment.CurrentDirectory, "IDCard2.pkpass");

            if (!System.IO.File.Exists(newFilePath))
            {
                System.IO.File.Copy(builtInPassPath, newFilePath);
            }

            byte[] filebytes = File.ReadAllBytes(newFilePath);

            NSData nsdata = NSData.FromArray(filebytes);
            
            var error = new NSError(new NSString("42"), -42);

            PKPass newPass = new PKPass(nsdata, out error);

            var pkAddPassVC = new PKAddPassesViewController(newPass);

            UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewControllerAsync(pkAddPassVC, true);

        }
    }
}
