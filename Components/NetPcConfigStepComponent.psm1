Import-Module "$($App.Utils)\ComponentUtils.psm1"
Import-Module "$($App.Utils)\XAMLUtils.psm1"
Function New-NetPcConfigStepComponent{
    param(
        [Mvvm.Models.ConfigModel] $config
    )
    $stepVM = [Mvvm.ViewModels.NetPcConfigStepViewModel]::new(
        [Mvvm.Models.StepModel]::new("NetPcConfigStep"),
        $config
    )
    return @{
        viewmodel=$stepVM
    }

    
}
Export-ModuleMember -Function New-NetPcConfigStepComponent