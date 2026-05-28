[Mvvm.Core.Bases.Logger]::Log = {
    param($msg)
    Write-Host $msg -ForegroundColor Green
}
[Mvvm.Core.Bases.Logger]::VMLog = {
    param($msg)
    Write-Host "[VM] $msg" -ForegroundColor Cyan
}