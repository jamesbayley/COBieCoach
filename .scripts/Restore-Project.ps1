Set-Location "$PSScriptRoot/.."

$DirectoryCommands = @(
  @{ RelativePath = "."; Command = "npm install -g npm@latest; npm install" }
)

$DirectoryCommands | ForEach-Object { 
  Push-Location $_.RelativePath
  Invoke-Expression $_.Command
  Pop-Location
}