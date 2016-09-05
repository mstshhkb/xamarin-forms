using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace XF_ListViewSample.Views
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        void CodeBehindButtonClicked(object sender, EventArgs s)
        {
            Navigation.PushAsync(new CodeBehindRamenPage());
        }

        void MvvmButtonClicked(object sender, EventArgs s)
        {
            Navigation.PushAsync(new MvvmRamenPage());
        }
    }
}
