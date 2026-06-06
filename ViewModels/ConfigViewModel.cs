using Mvvm.Models;
using Mvvm.Core.Bases;

namespace Mvvm.ViewModels
{
    public class ConfigViewModel : NotifyBase
    {
        private Configuration _config;
        public ConfigViewModel(Configuration Config)
        {
            this.Config = Config ?? new Configuration();
        }
        public Configuration Config
        {
            get { return _config; }
            set
            {
                _config = value;
                OnPropertyChanged();
            }
        }
    }
}