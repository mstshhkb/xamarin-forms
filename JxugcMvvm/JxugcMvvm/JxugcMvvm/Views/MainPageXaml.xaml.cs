using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace JxugcMvvm.Views
{
    public partial class MainPageXaml : ContentPage
    {
        public MainPageXaml()
        {
            InitializeComponent();

            var viewModel = new ViewModels.MainPageViewModel();
            this.BindingContext = viewModel;
        }
    }
}
