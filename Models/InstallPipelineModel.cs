using System.Collections.Generic;
namespace Mvvm.Models
{
    public class InstallPipelineModel
    {
        public InstallPipelineModel(List<InstallStepModel> InstallSteps)
        {
            this.InstallSteps = InstallSteps ?? new List<InstallStepModel>();
        }
        public List<InstallStepModel> InstallSteps { get; set; }
        public bool Execute(ConfigModel Config)
        {
            bool result = false;
            foreach (var InstallStep in InstallSteps)
            {
                bool stepResult = InstallStep.Execute(Config);
                if (!stepResult) break;
            }
            return result;
        }
    }
}