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
using JxugcMvvm.Models;
using System.Collections.Specialized;

namespace JxugcMvvm.ViewModels
{
    class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public MainPageViewModel()
        {
            _persons = new ObservableCollection<Person>();
            _persons.CollectionChanged += _persons_CollectionChanged;

            this.AddCommand = new Command(() =>
            {
                // 適当にPersonを追加していきます。
                var rnd = new Random(DateTime.Now.Millisecond);
                var rvalue = rnd.Next(10, 70);

                this.Persons.Add(new Person
                {
                    Name = string.Format($"TestUser {rvalue}"),
                    Age = rvalue
                });
            });
        }

        private void _persons_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            // AddしかしていないのでとりあえずAddだけ実装
            if (e.Action == NotifyCollectionChangedAction.Add)
                CalcData((ObservableCollection<Person>)sender); // DataCountとDataAverageは購読されてるので通知できる。
        }

        public ICommand AddCommand { get; protected set; }

        private ObservableCollection<Person> _persons;
        public ObservableCollection<Person> Persons
        {
            get { return this._persons; }
            set
            {
                if (_persons != value)
                    _persons = value;
            }
        }

        private int _dataCount;
        public int DataCount
        {
            get { return _dataCount; }
            set
            {
                if (_dataCount != value)
                {
                    _dataCount = value;
                    OnPropertyChanged();
                }
            }
        }

        private double _dataAverage;
        public double DataAverage
        {
            get { return _dataAverage; }
            set
            {
                if (_dataAverage != value)
                {
                    _dataAverage = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// persons コレクションの個数を平均を返します。
        /// </summary>
        /// <param name="persons"></param>
        private void CalcData(ObservableCollection<Person> persons)
        {
            this.DataCount = persons.Count();
            this.DataAverage = persons.Average(x => x.Age);
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                System.Diagnostics.Debug.WriteLine("PropertyChanged Fired"); // for check
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


    }
}
