using Mvvm.Core.Bases;
namespace Mvvm.Models
{
    public class ConfigModel : BaseModel
    {
        public string _password = "";
        public string _instanceName = "ITS2026";
        public string _systemDirname = "VisualCont2021";

        public string SystemDirname
        {
            get { return _systemDirname; }
            set { _systemDirname = value; OnPropertyChanged(); }
        }
    }
}