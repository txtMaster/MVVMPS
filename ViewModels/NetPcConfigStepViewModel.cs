using System.Windows.Input;
using Mvvm.Core.Bases;
using Mvvm.Core.Interfaces;
using Mvvm.Core.Commands;
using Mvvm.Models;

namespace Mvvm.ViewModels
{
    public class NetPcConfigStepViewModel : StepViewModel
    {
        public NetPcConfigStepViewModel(StepModel StepM, ConfigModel ConfigM) : base(StepM, ConfigM)
        {
            this.StepM.Title = "Selecciona los parametros para la instalación";
            this.StepM.NextStepText = "Configurar Ejecución";
        }
}
}