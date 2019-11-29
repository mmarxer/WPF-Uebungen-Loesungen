using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalClock
{
    public class Clock : INotifyPropertyChanged
    {
        private DateTime _time;
        public DateTime Time
        {
            get { return _time; }
            set
            {
                if (value != _time)
                {
                    _time = value;
                    OnPropertyChanged(nameof(Time));
                    OnPropertyChanged(nameof(TimeString));
                }
            }
        }

        public string TimeString => Time.ToString("dd.MM.yyyy HH:mm:ss");

        public Clock()
        {
            Time = DateTime.Now;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
