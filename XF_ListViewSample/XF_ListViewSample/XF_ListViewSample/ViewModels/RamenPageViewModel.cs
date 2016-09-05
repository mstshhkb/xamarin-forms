using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;
using XF_ListViewSample.Models;

namespace XF_ListViewSample.ViewModels
{
    public class RamenPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        #region プロパティ

        private ObservableCollection<RamenItem> _items = Ramen.Instance.Items;
        public ObservableCollection<RamenItem> Items
        {
            get { return _items; }
            set
            {
                if (_items != value)
                {
                    _items = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        #region コマンド

        public ICommand AddCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }

        #endregion

        /// <summary>
        /// コンストラクター
        /// </summary>
        public RamenPageViewModel()
        {
            // 初期化
            Ramen.Instance.Initialize();
            
            // ModelのPropertyChangedを拾う場合
            //Ramen.Instance.PropertyChanged += Instance_PropertyChanged;

            // コマンドはModelのメソッドを呼ぶ
            this.AddCommand = new Command(() => Ramen.Instance.AddItem());
            this.DeleteCommand = new Command(() => Ramen.Instance.DeleteItem());
        }

        // ModelのPropertyChangedを拾う場合
        //private void Instance_PropertyChanged(object sender, PropertyChangedEventArgs e)
        //{
        //    // 変更されたプロパティ別にVMで個別の処理を追加できる
        //    switch (e.PropertyName)
        //    {
        //        case nameof(Ramen.Items):
        //            this.Items = Ramen.Instance.Items;
        //            break;
        //        default:
        //            break;
        //    }
        //}

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
