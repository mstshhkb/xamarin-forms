using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace XF_MvvmSample.ViewModel
{
    class XamlPageViewModel : INotifyPropertyChanged
    {
        string _firstName, _lastName, _fullName;
        public event PropertyChangedEventHandler PropertyChanged;

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    OnPropertyChanged("FirstName");
                    SetFullName();
                    OnPropertyChanged("FullName");
                }
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    OnPropertyChanged("LastName");
                    SetFullName();
                    OnPropertyChanged("FullName");
                }
            }
        }

        public string FullName
        {
            get { return _fullName; }
            set { }
        }

        void SetFullName()
        {
            _fullName = string.Format("{0} {1}", _firstName, _lastName);
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,
                    new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
