Add-Type -AssemblyName PresentationFramework
Add-Type -AssemblyName PresentationCore
Add-Type -AssemblyName WindowsBase
Add-Type -AssemblyName System.Xaml

$Global:App = @{
    Route      = $PSScriptRoot
    Views      = Join-Path $PSScriptRoot "Views"
    ViewModels = Join-Path $PSScriptRoot "ViewModels"
    Core       = Join-Path $PSScriptRoot "Core"
    Bases      = ($PSScriptRoot | Join-Path -ChildPath "Core" | Join-Path -ChildPath "Bases")
    Interfaces = ($PSScriptRoot | Join-Path -ChildPath "Core" | Join-Path -ChildPath "Interfaces")
    Commands   = ($PSScriptRoot | Join-Path -ChildPath "Core" | Join-Path -ChildPath "Commands")
    Components = (Join-Path $PSScriptRoot "Components")
    Utils      = (Join-Path $PSScriptRoot "Utils")
}

$csFiles = Get-ChildItem `
    -Path "${PSScriptRoot}\Core", "${PSScriptRoot}\ViewModels", "${PSScriptRoot}\Models" `
    -Filter *.cs `
    -Recurse

Add-Type `
    -Path $csFiles.FullName `
    -ReferencedAssemblies @(
    "PresentationFramework",
    "PresentationCore",
    "WindowsBase",
    "System.Xaml"
)

. (Join-Path $App.Utils "Logger.ps1")

if (-not [System.Windows.Application]::Current) {
    $App.root = New-Object System.Windows.Application
}

$styleXaml = Get-Content "./Views/Styles/Styles.xaml" -Raw
$styleReader = New-Object System.Xml.XmlNodeReader([xml]$styleXaml)
$style = [Windows.Markup.XamlReader]::Load($styleReader)
[System.Windows.Application]::Current.Resources.MergedDictionaries.Add($style)

Import-Module "$($App.Components)\MainPageComponent.psm1"

$MainPage = New-MainPageComponent([Mvvm.Models.ConfigModel]::new())
$MainPage.view.ShowDialog() | Out-Null