using FontAwesome6;
using Microsoft.UI.Composition.SystemBackdrops;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Enumeration;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;


// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Virtual_Serial_Port_Emulator
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            InitialisePortList();
            AppWindow.Resize(new Windows.Graphics.SizeInt32(800, 600));
            this.ExtendsContentIntoTitleBar = true;
            this.SetTitleBar(AppTitleBar);
        }

        private void InitialisePortList()
        {
            string[] ports = System.IO.Ports.SerialPort.GetPortNames();
            var comPorts = ports.Select(x => new ComPort { Name = x, Icon = FontAwesome6.EFontAwesomeIcon.Solid_Plug}).ToList();
            //livePortsList.ItemsSource = comPorts;
        }
    }

    public class ComPort
    {
        public string Name { get; set; }
        public EFontAwesomeIcon Icon { get; set; }
    }
}
