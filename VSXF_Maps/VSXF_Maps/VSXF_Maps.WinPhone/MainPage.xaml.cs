using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

using Xamarin.Forms;
using Xamarin.Forms.Maps;


namespace VSXF_Maps.WinPhone
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();

            Forms.Init();
            Xamarin.FormsMaps.Init();

            Content = VSXF_Maps.App.GetMainPage().ConvertPageToUIElement(this);
        }
    }
}
