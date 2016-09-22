using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Security.Credentials;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace pwd
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }


        async private void save(object sender, RoutedEventArgs e)
        {
            var vault = new Windows.Security.Credentials.PasswordVault();
            vault.Add(new Windows.Security.Credentials.PasswordCredential(Resource.Text, user.Text, pwd.Password));
            var dialog = new MessageDialog("Credentials Saved succesfully");
            await dialog.ShowAsync();
            Resource.Text = string.Empty;
            user.Text = string.Empty;
            pwd.Password = string.Empty;

        }

       async private void retrieve(object sender, RoutedEventArgs e)
        {

            PasswordVault vault = new PasswordVault();
            foreach (var cred in vault.RetrieveAll())
            {
                cred.RetrievePassword();
                if (cred.Resource == Resource.Text || cred.UserName == user.Text || cred.Password == pwd.Password)
                {
                    output.Text = "Name :" + cred.Resource + "\n" + "Password :" + cred.Password + "\n" + "UserName :" + cred.UserName;
                }
                else
                {
                    var dialog = new MessageDialog("Credentials Does Not Exist");
                    await dialog.ShowAsync();
                }
                /* Console.WriteLine("Resource: {0}", cred.Resource);
                 Console.WriteLine("UserName: {0}", cred.UserName);
                 Console.WriteLine("Password: {0}", cred.Password);*/
            }
        }

        async private void delete(object sender, RoutedEventArgs e)
        {
            PasswordVault vault = new PasswordVault();
            foreach (var cred in vault.RetrieveAll())
            {
                cred.RetrievePassword();
                if (cred.Resource == Resource.Text || cred.UserName == user.Text || cred.Password == pwd.Password)
                {
                    var vaul = new Windows.Security.Credentials.PasswordVault();
                    vaul.Remove(new Windows.Security.Credentials.PasswordCredential(cred.Resource, cred.UserName, cred.Password));
                    var dialog = new MessageDialog("Done!!!!");
                    await dialog.ShowAsync();
                }

                else
                {
                    var dialog = new MessageDialog("Credentials Does Not Exist");
                    await dialog.ShowAsync();
                }
            } 
        }
    }
}
    
            
        
    
    

   

