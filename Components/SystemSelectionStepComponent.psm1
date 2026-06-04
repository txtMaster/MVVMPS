Import-Module "$($App.Utils)\ComponentUtils.psm1"
Import-Module "$($App.Utils)\XAMLUtils.psm1"
Function New-SystemSelectionStepComponent{
    param(
        [Mvvm.Models.ConfigModel] $config
    )
    $stepVM = [Mvvm.ViewModels.SystemSelectionStepViewModel]::new(
        [Mvvm.Models.StepModel]::new("SystemSelectionStep"),
        $config
    )
    $v = LoadView "SystemSelectionStep"
    $v.DataContext = $stepVM
    return @{
        viewmodel=$stepVM
    }

    
}
Export-ModuleMember -Function New-SystemSelectionStepComponent