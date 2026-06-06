Import-Module "$($App.Utils)\ComponentUtils.psm1"
Import-Module "$($App.Utils)\XAMLUtils.psm1"
Import-Module "$($App.Components)\NetPcConfigStepComponent.psm1"
Import-Module "$($App.Components)\SystemSelectionStepComponent.psm1"

Function New-MainPageComponent {
    param([Mvvm.Models.Configuration] $configM)
    $script:view = LoadView "MainPage"
    
    #corregir
    $view.FindName("closeBtn").Add_Click({$script:view.close()})

    $script:vm = [Mvvm.ViewModels.MainPageViewModel]::new(
        $configM,
        [Func[string, System.Windows.Controls.UserControl]] {
            param([string]$viewName)
            return LoadView $viewName
        }
    )
    $view.DataContext = $vm

    #reemplazar por navigate command
    <#
    $vm.OnStepChanged = {
        param($step)
        $vm.CurrentView = LoadView $step.ViewName
        $vm.CurrentView.DataContext = $vm.ConfigVM
        Write-Host $vm.ConfigVM.Config.SystemDirname
    }
    #>
    $vm.AddStep( (New-SystemSelectionStepComponent $configM).viewmodel)
    $vm.AddStep((New-NetPcConfigStepComponent $configM).viewmodel)
    $vm.CurrentStep = $vm.steps[0]
    return @{
        view      = $view
        viewmodel = $script:vm
    }
}
Export-ModuleMember -Function New-MainPageComponent