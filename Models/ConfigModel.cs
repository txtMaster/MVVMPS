using Mvvm.Core.Bases;
using System;
namespace Mvvm.Models   
{
    public class ConfigModel : BaseModel
    {
        public string Password {get;set;}
        public string InstanceName {get;set;}
        public string SystemLocation {get;set;}
        public string SystemZipFilePath {get;set;}
        public string SqlInstallerPath {get;set;}
        public string ServerName {get;set;}
    }
}