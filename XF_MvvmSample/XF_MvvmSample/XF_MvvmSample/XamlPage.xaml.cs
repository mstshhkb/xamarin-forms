using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XF_MvvmSample
{
    public partial class XamlPage : ContentPage
    {
        public XamlPage()
        {
            InitializeComponent();

            // コードビハインドで BindingContext を指定する場合は初期値を入れられる（？）
            this.BindingContext = new XamlPageViewModel() { Name = "My Name" };

            
        }
    }
}
