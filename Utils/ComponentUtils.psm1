Import-Module "$($App.Utils)\XAMLUtils.psm1"

function New-VM{
    param([string]$name)
    $vmType = [Type]::GetType("Mvvm.ViewModels.$($name)ViewModel")
    $vm = $null
    if ($vmType) {
        $vm = [Activator]::CreateInstance($vmType)
    }
    return $vm
}
function LoadComponent {
    param([string]$name)
    $view = LoadView($name)
    $viewModel = New-VM($name)
    $view.DataContext = $viewModel
    return @{
        view=$view
        viewmodel=$viewModel
    }
}
Export-ModuleMember -Function LoadComponent, New-VM