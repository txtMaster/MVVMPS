using Mvvm.Core.Bases;
using System;
namespace Mvvm.Models
{
    public class ConfigModel : BaseModel
    {
        public string _password = "";
        public string _instanceName = "ITS"+DateTime.Now.Year;
        public string _systemLocation = "C:\\VisualCont2021";
        public string _systemZipFilePath = "";
        public string _sqlInstallerPath = "";
        public string _serverName = "";

        public string SystemLocation
        {
            get { return _systemLocation; }
            set { _systemLocation = value; OnPropertyChanged(); }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged(); }
        }
        public string SystemZipFilePath
        {
            get { return _systemZipFilePath; }
            set { _systemZipFilePath = value; OnPropertyChanged(); }
        }
        public string SqlInstallerPath
        {
            get { return _sqlInstallerPath; }
            set { _sqlInstallerPath = value; OnPropertyChanged(); }
        }
    }
}