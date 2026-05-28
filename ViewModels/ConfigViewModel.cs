using Mvvm.Models;
using Mvvm.Core.Bases;

namespace Mvvm.ViewModels
{
    public class ConfigViewModel : NotifyBase
    {
        private ConfigModel _config;
        public ConfigViewModel(ConfigModel config)
        {
            if(config == null) config = new ConfigModel();
            _config = config;
        }
        public ConfigModel Config
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