using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XF_ListViewSample.Models;

namespace XF_ListViewSample.Views
{
    public partial class CodeBehindRamenPage : ContentPage
    {
        ObservableCollection<RamenItem> Items = new ObservableCollection<RamenItem>();

        //サンプル用のランダムデータ(画像)
        string[] _ramens = { "ramen1.png", "ramen2.png", "ramen3.png", "ramen4.png", "ramen5.png", "ramen6.png", "ramen7.png", "ramen8.png", "ramen9.png" };

        public CodeBehindRamenPage()
        {
            InitializeComponent();

            // Items初期化
            this.Items.Clear();
            this.Items.Insert(0, new RamenItem("Item_1", "Description_1", "ramen4.png"));
            // Binding対象にItemsを指定
            listView.BindingContext = this.Items;
        }

        void AddButtonClick(object sender, EventArgs s)
        {
            var rdm = new Random();
            this.Items.Insert(0, new RamenItem(
                "Item_" + rdm.Next(),
                "Description_" + rdm.Next(),
                _ramens[rdm.Next(0, 8)]
                ));
        }

        void DeleteButtonClick(object sender, EventArgs s)
        {
            if (this.Items.Count > 0)
            {
                this.Items.Remove(this.Items[this.Items.Count - 1]);
            }
        }
    }
}
