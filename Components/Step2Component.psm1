Import-Module "$($App.Utils)\ComponentUtils.psm1"
Import-Module "$($App.Utils)\XAMLUtils.psm1"
Function New-Step2Component{
    param(
        [Mvvm.Models.ConfigModel] $config
    )
    $stepVM = [Mvvm.ViewModels.Step2ViewModel]::new(
        [Mvvm.Models.StepModel]::new("Step2"),
        $config
    )
    return @{
        viewmodel=$stepVM
    }

    
}
Export-ModuleMember -Function New-Step2Component