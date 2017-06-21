using DiDo.Multiplayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace DiDo.MenuFolder
{
    public sealed partial class InvadeConnect : Page
    {
        private NetHandlerClient netHandler;

        public InvadeConnect()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            this.netHandler = e.Parameter as NetHandlerClient;

            await this.netHandler.ConnectAsync();
        }
    }
}
