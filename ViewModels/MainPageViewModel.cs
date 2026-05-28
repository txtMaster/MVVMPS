using System;
using System.Windows.Input;
using System.Windows.Controls;
using Mvvm.Core.Bases;
using Mvvm.Core.Interfaces;
using Mvvm.Core.Commands;
using Mvvm.Models;
using Mvvm.ViewModels;
using System.Collections.Generic;

namespace Mvvm.ViewModels
{
    public class MainPageViewModel : NotifyBase
    {
        public ConfigViewModel ConfigVM { get; set; }
        private StepModel _currentStep;
        private UserControl _currentView;
        public List<StepModel> steps = new List<StepModel>();
        public Action<StepModel> OnStepChanged;
        private int _currentStepIndex = 0;
        public MainPageViewModel(ConfigViewModel config)
        {
            if (config == null) config = new ConfigViewModel(null);
            ConfigVM = config;
            PreviousCommand = new RelayCommand(_ => ToogleStep(-1));
            NextCommand = new RelayCommand(_ => ToogleStep(1));
        }
        public void AddStep(StepModel step)
        {
            steps.Add(step);
            if (CurrentStep == null) CurrentStep = step;
        }
        public StepModel CurrentStep
        {
            get { return _currentStep; }
            set
            {
                _currentStep = value;
                OnPropertyChanged();
                if (OnStepChanged != null) OnStepChanged.Invoke(value);
            }
        }
        public UserControl CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }

        public ICommand NextCommand { get; set; }
        public ICommand PreviousCommand { get; set; }
        private void ToogleStep(int jump)
        {
            int nextStepIndex = _currentStepIndex + jump;
            if ((nextStepIndex < 0) || (steps.Count - 1 < nextStepIndex)) return;
            _currentStepIndex = nextStepIndex;
            CurrentStep = steps[_currentStepIndex];
        }
    }
}
