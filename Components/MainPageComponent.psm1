Import-Module "$($App.Utils)\ComponentUtils.psm1"
Import-Module "$($App.Utils)\XAMLUtils.psm1"
Function New-MainPageComponent{
    param([Mvvm.Models.ConfigModel] $config)
    $view = LoadView("MainPage")
    $vm = [Mvvm.ViewModels.MainPageViewModel]::new($config)
    return @{
        view=$view
        viewmodel=$vm
    }
}
Export-ModuleMember -Function New-MainPageComponent