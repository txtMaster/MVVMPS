using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Mvvm.Core.Bases
{
    public class NotifyBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        protected void OnPropertyChanged(
            [CallerMemberName] string propertyName = null
        )
        {
            if (PropertyChanged == null) return;
            Logger.VMLog.Invoke("PropertyChanged => "+propertyName);
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}