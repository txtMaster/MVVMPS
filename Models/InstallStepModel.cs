using System;
namespace Mvvm.Models
{
    public class InstallStepModel
    {
        public InstallStepModel(Func<ConfigModel, string> Validation)
        {
            this.Validation = Validation;
            Message = "";
        }
        public string Message { get; set; }
        public bool Success { get; set; }
        public string Name { get; set; }
        public Func<ConfigModel,string> Validation { get; set; }
        public bool Execute(ConfigModel Config)
        {
            if (Validation == null)
            {
                Message = "Proceso no definido";
            }
            else
            {
                Message = Validation(Config) ?? "";
            }
            return Message.Length == 0;
        }
    }
}