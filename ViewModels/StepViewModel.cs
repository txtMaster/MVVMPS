using Mvvm.Models;
using Mvvm.Core.Bases;
using Mvvm.Core.Interfaces;
using Mvvm.Core.Commands;
using System.Windows.Input;
namespace Mvvm.ViewModels
{
    public class StepViewModel : NotifyBase, IWizardStep
    {
        public StepViewModel(StepModel StepM, Configuration ConfigM)
        {
            this.StepM = StepM;
            this.ConfigM = ConfigM;
            ToNextCommand = new _RelayCommand(_=>{
                bool Result = Validate();
                if(Result) StepM.GetNextStep();
            });
        }
        private StepModel _stepM;
        private Configuration _configM;
        public ICommand ToNextCommand { get; set; }
        public Configuration ConfigM
        {
            get { return _configM; }
            set { _configM = value; OnPropertyChanged(); }
        }
        public StepModel StepM
        {
            get { return _stepM; }
            set { _stepM = value; OnPropertyChanged(); }
        }
        public bool Validate()
        {
            bool Result = StepM.Validate();
            OnPropertyChanged("StepM");
            return Result;
        }
    }
}