using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace XF_MvvmSample.View
{
    public partial class XamlPage : ContentPage
    {
        public XamlPage()
        {
            InitializeComponent();
            this.BindingContext = new XF_MvvmSample.ViewModel.XamlPageViewModel();
        }
    }
}
