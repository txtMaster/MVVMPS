using System.Windows.Input;
using Mvvm.Core.Bases;
using Mvvm.Core.Interfaces;
using Mvvm.Core.Commands;
using Mvvm.Models;
namespace Mvvm.ViewModels
{
    public class Step1ViewModel : StepViewModel
    {
        public Step1ViewModel(StepModel StepM, ConfigModel ConfigM) : base(StepM, ConfigM)
        {
            this.StepM.Title = "Selecciona el sistema a instalar";
            this.StepM.BeforeStepText = "";
            this.StepM.NextStepText = "Iniciar";
        }
    }
}