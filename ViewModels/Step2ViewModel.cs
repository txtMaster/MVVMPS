using System.Windows.Input;
using Mvvm.Core.Bases;
using Mvvm.Core.Interfaces;
using Mvvm.Core.Commands;
using Mvvm.Models;

namespace Mvvm.ViewModels
{
    public class Step2ViewModel : StepViewModel
    {
        public Step2ViewModel(StepModel StepM, ConfigModel ConfigM) : base(StepM, ConfigM)
        {
            this.StepM.Title = "Selecciona los parametros para la instalación";
            this.StepM.NextStepText = "Configurar Ejecución";
        }
    }
}