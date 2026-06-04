using Mvvm.Models;
using Mvvm.Core.Bases;
using System.Collections.ObjectModel;
namespace Mvvm.ViewModels
{
    public class InstallPipelineModel : NotifyBase
    {
        private ObservableCollection<InstallStepModel> InstallSteps = new ObservableCollection<InstallStepModel>();
    }
}