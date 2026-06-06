using System;
namespace Mvvm.Models
{
    public class InstallStep
    {
        public InstallStep(Func<Configuration, string> Validation)
        {
            this.Validation = Validation;
            Message = "";
        }
        public string Message { get; set; }
        public bool Success { get; set; }
        public string Name { get; set; }
        public Func<Configuration,string> Validation { get; set; }
        public bool Execute(Configuration Config)
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