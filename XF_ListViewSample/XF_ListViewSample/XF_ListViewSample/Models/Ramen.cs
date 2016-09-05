using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace XF_ListViewSample.Models
{
    public class Ramen : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// シングルトンのインスタンス
        /// </summary>
        public static Ramen Instance { get; } = new Ramen();

        /// <summary>
        /// コンストラクターは隠ぺい
        /// </summary>
        private Ramen() { }

        #region プロパティ
        // ランダム選択用の配列
        private string[] _ramens = { "ramen1.png", "ramen2.png", "ramen3.png", "ramen4.png", "ramen5.png", "ramen6.png", "ramen7.png", "ramen8.png", "ramen9.png" };

        public ObservableCollection<RamenItem> Items { get; } = new ObservableCollection<RamenItem>();

        #endregion

        #region メソッド

        public void Initialize()
        {
            this.Items.Clear();
            this.Items.Insert(0, new RamenItem("Item_1", "Description_1", "ramen4.png"));
        }

        public void AddItem()
        {
            var rdm = new Random();
            this.Items.Insert(0, new RamenItem(
                "Item_" + rdm.Next(),
                "Description_" + rdm.Next(),
                _ramens[rdm.Next(0, 8)]
                ));
            // PropertyChangedイベントを発火
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Items)));
        }

        public void DeleteItem()
        {
            if (this.Items.Count > 0)
            {
                this.Items.Remove(this.Items[this.Items.Count - 1]);
                // PropertyChangedイベントを発火
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Items)));

            }
        }
        #endregion


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
