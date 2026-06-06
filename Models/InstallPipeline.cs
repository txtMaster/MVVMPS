using System.Collections.Generic;
namespace Mvvm.Models
{
    public class InstallPipeline
    {
        public InstallPipeline(List<InstallStep> InstallSteps)
        {
            this.InstallSteps = InstallSteps ?? new List<InstallStep>();
        }
        public List<InstallStep> InstallSteps { get; set; }
        public bool Execute(Configuration Config)
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