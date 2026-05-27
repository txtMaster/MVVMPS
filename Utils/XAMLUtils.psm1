function LoadView {
    param($path)
    $path = Join-Path $Global:App.Views "$($path)View.xaml"
    [xml]$xaml = Get-Content $path
    $nodes = $xaml.SelectNodes("//*[@Source]")
    foreach ($node in $nodes) {
        $node.ParentNode.RemoveChild($node) | Out-Null
    }
    $reader = New-Object System.Xml.XmlNodeReader $xaml
    return [Windows.Markup.XamlReader]::Load($reader)
}
Export-ModuleMember -Function LoadView