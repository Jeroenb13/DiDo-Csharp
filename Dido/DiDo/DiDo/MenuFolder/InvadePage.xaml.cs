using DiDo.Multiplayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Networking;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace DiDo.MenuFolder
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class InvadePage : Page
    {

        public string Adress{get; set;}
        public ushort Port { get; set;}
        public InvadePage()
        {
            this.InitializeComponent();
        }
        /// <summary>
        /// Connect button where you can invade stuff sends you to another xaml page if your ip adress and poort number are not null or empty
        /// </summary>
        /// <param name="sender">ecent handler</param>
        /// <param name="e">event handler</param>
        private async void ConnectBTN_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(IpAdressTBX.Text) || string.IsNullOrWhiteSpace(PoortTBX.Text))
            {
                MessageDialog msgBox = new MessageDialog("Please fill in the form");
                await msgBox.ShowAsync();
            }
            else
            {
                Adress = IpAdressTBX.Text;
                try
                {
                    Port = Convert.ToUInt16(PoortTBX.Text);

                    NetHandlerClient netHandler = new NetHandlerClient(new HostName(Adress), Port);

                    this.Frame.Navigate(typeof(InvadeConnect), netHandler);
                }
                catch(Exception ex)
                {
                    MessageDialog msgError = new MessageDialog("The current value of the port is not a valid port");
                    await msgError.ShowAsync();
                }
            }
        }
    }
}
