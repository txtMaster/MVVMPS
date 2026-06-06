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
        private Configuration _Configuration;
        public Configuration ConfigM
        {
            get { return _Configuration; }
            set
            {
                _Configuration = value;
                OnPropertyChanged();

            }
        }
        private StepViewModel _currentStep;
        private UserControl _currentView;
        public List<StepViewModel> steps = new List<StepViewModel>();
        private int _currentStepIndex = 0;
        private readonly Func<string, UserControl> _viewFactory;
        public MainPageViewModel(
            Configuration config,
            Func<string, UserControl> viewFactory
        )
        {
            _viewFactory = viewFactory;
            ConfigM = config ?? new Configuration();
            PreviousCommand = new RelayCommand(_ => ToogleStep(-1));
            NextCommand = new RelayCommand(_ => ToogleStep(1));
        }
        public void AddStep(StepViewModel step)
        {
            steps.Add(step);
            if (CurrentStep == null) CurrentStep = step;
        }
        public StepViewModel CurrentStep
        {
            get { return _currentStep; }
            set
            {
                _currentStep = value;
                OnPropertyChanged();

                CurrentView = _viewFactory(value.StepM.ViewName);
                if (CurrentView != null) { CurrentView.DataContext = CurrentStep; }
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