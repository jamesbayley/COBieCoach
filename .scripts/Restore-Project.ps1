Set-Location "$PSScriptRoot/.."

$DirectoryCommands = @(
  @{ RelativePath = "projects/client"; Command = "npm install -g npm@latest; npm install" }
  @{ RelativePath = "projects/server"; Command = "dotnet restore" }
)

$DirectoryCommands | ForEach-Object { 
  Push-Location $_.RelativePath
  Invoke-Expression $_.Command
  Pop-Location
}