Import-Module "$($App.Utils)\ComponentUtils.psm1"
Import-Module "$($App.Utils)\XAMLUtils.psm1"

Function New-MainPageComponent {
    param([Mvvm.Models.ConfigModel] $config)
    $view = LoadView "MainPage"
    $configVM = [Mvvm.ViewModels.ConfigViewModel]::new($config)
    $script:vm = [Mvvm.ViewModels.MainPageViewModel]::new($configVM)
    $view.DataContext = $vm

    #reemplazar por navigate command
    $vm.OnStepChanged = {
        param($step)
        $vm.CurrentView = LoadView $step.ViewName
        $vm.CurrentView.DataContext = $vm.ConfigVM
        Write-Host $vm.ConfigVM.Config.SystemDirname
    }
    $vm.AddStep([Mvvm.Models.StepModel]::new("Step1"))
    $vm.AddStep([Mvvm.Models.StepModel]::new("Step2"))
    $vm.CurrentStep = $vm.steps[0]
    return @{
        view      = $view
        viewmodel = $script:vm
    }
}
Export-ModuleMember -Function New-MainPageComponent