using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace BandApp___Gravity_Hero.ViewModel
{
    [DataContract]
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler pceh = PropertyChanged;
            if(pceh != null)
            {
                pceh(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void NotifyPropertyChanged(params string[] changedProperties)
        {
            if(changedProperties != null)
            {
                foreach(string property in changedProperties)
                {
                    OnPropertyChanged(property);
                }
            }
        }

        protected virtual bool SetValue<T>(ref T target, T value, params string[] changedProperties)
        {
            if(object.Equals(target, value))
            {
                return false;
            }
            target = value;
            foreach (string property in changedProperties)
            {
                OnPropertyChanged(property);
            }
            return true;
        }
    }
}
