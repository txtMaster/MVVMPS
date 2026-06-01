function LoadView {
    param($path)
    $path = Join-Path $Global:App.Views "$($path)View.xaml"
    [xml]$xaml = Get-Content $path
    $nodes = $xaml.SelectNodes("//*[@Source]")
    foreach ($node in $nodes) {
        $node.ParentNode.RemoveChild($node) | Out-Null
    }
    $reader = New-Object System.Xml.XmlNodeReader $xaml
    $window = [Windows.Markup.XamlReader]::Load($reader)
    return $window
    <#
        $styleXaml = Get-Content "./Views/Styles/Styles.xaml" -Raw
        $styleReader = New-Object System.Xml.XmlNodeReader([xml]$styleXaml)
        $style = [Windows.Markup.XamlReader]::Load($styleReader)
        $MainPage.view.Resources.MergedDictionaries.Add($style)
        #>
}
Export-ModuleMember -Function LoadView