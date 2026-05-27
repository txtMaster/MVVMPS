using System.Windows.Input;
using Mvvm.Core.Bases;
using Mvvm.Core.Interfaces;
using Mvvm.Core.Commands;
using Mvvm.Models;
using System.Collections.Generic;

namespace Mvvm.ViewModels
{
    public class MainPageViewModel : NotifyBase
    {
        private ConfigModel config = new ConfigModel();
        private object _currentStep;
        private List<IWizardStep> _views = new List<IWizardStep>();
        private int _currentStepIndex = 0;

        public object CurrentStep
        {
            get { return _currentStep; }
            set
            {
                _currentStep = value;
                OnPropertyChanged();
            }
        }

        public ICommand NextCommand { get; set; }

        public MainPageViewModel(ConfigModel config)
        {
            this.config = config;
            CurrentStep = new Step1ViewModel();

            NextCommand = new RelayCommand(_ => ToogleView(1));
        }

        private void ToogleView(int jump)
        {
            IWizardStep step = CurrentStep as IWizardStep;
            if (step != null)
            {
                if (!step.Validate())
                    return;
                int nextStepIndex = _currentStepIndex + jump;
                if((nextStepIndex < 0) || (_views.Count - 1 < nextStepIndex)) return;
                _currentStepIndex = nextStepIndex;
                CurrentStep = _views[_currentStepIndex];
/*
                if (CurrentStep is Step1ViewModel)
                    CurrentStep = new Step2ViewModel();

                else if (CurrentStep is Step2ViewModel)
                    CurrentStep = new Step3ViewModel();
*/
            }
        }
    }
}