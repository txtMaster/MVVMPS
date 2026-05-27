using System.Windows.Input;
using Mvvm.Core.Bases;
using Mvvm.Core.Interfaces;
using Mvvm.Core.Commands;

namespace Mvvm.ViewModels
{
    public class Step1ViewModel : NotifyBase, IWizardStep
    {
        private string _title = "Pagina 1";

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        public bool Validate()
        {
            return !string.IsNullOrWhiteSpace(Title);
        }
    }
}