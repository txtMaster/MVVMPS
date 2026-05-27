Add-Type -AssemblyName PresentationFramework
Add-Type -AssemblyName PresentationCore
Add-Type -AssemblyName WindowsBase
Add-Type -AssemblyName System.Xaml

$Global:App = @{
    Route=$PSScriptRoot
    Views=Join-Path $PSScriptRoot "Views"
    ViewModels=Join-Path $PSScriptRoot "ViewModels"
    Core=Join-Path $PSScriptRoot "Core"
    Bases= ($PSScriptRoot| Join-Path -ChildPath "Core" | Join-Path -ChildPath "Bases")
    Interfaces= ($PSScriptRoot | Join-Path -ChildPath "Core" | Join-Path -ChildPath "Interfaces")
    Commands= ($PSScriptRoot | Join-Path -ChildPath "Core" | Join-Path -ChildPath "Commands")
    Components= (Join-Path $PSScriptRoot "Components")
    Utils= (Join-Path $PSScriptRoot "Utils")
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

Import-Module "$($App.Components)\MainPageComponent.psm1"

$MainPage = New-MainPageComponent
$MainPage.view.ShowDialog() | Out-Null