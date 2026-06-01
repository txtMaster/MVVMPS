using Mvvm.Models;
using Mvvm.Core.Bases;
using Mvvm.Core.Interfaces;
namespace Mvvm.ViewModels
{
    public class StepViewModel : NotifyBase, IWizardStep
    {
        public StepViewModel(StepModel StepM, ConfigModel ConfigM)
        {
            this.StepM = StepM;
            this.ConfigM = ConfigM;
        }
        private StepModel _stepM;
        private ConfigModel _configM;
        public ConfigModel ConfigM
        {
            get { return _configM; }
            set { _configM = value; OnPropertyChanged(); }
        }
        public StepModel StepM
        {
            get { return _stepM; }
            set
            {
                _stepM = value;
                OnPropertyChanged();
            }
        }
        public bool Validate()
        {
            return true;
        }
    }
}