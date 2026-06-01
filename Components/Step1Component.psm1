Import-Module "$($App.Utils)\ComponentUtils.psm1"
Import-Module "$($App.Utils)\XAMLUtils.psm1"
Function New-Step1Component{
    param(
        [Mvvm.Models.ConfigModel] $config
    )
    $stepVM = [Mvvm.ViewModels.Step1ViewModel]::new(
        [Mvvm.Models.StepModel]::new("Step1"),
        $config
    )
    $v = LoadView "Step1"
    $v.DataContext = $stepVM
    return @{
        viewmodel=$stepVM
    }

    
}
Export-ModuleMember -Function New-Step1Component