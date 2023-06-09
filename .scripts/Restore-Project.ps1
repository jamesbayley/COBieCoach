Set-Location "$PSScriptRoot/.."

$DirectoryCommands = @(
  @{ RelativePath = "projects"; Command = "npm install -g npm@latest" }  
  @{ RelativePath = "projects"; Command = "dotnet tool restore" }
  @{ RelativePath = "projects"; Command = "dotnet restore" }
  @{ RelativePath = "projects/engine"; Command = "npm install" }
  @{ RelativePath = "projects/webapp"; Command = " npm install" }
)

$DirectoryCommands | ForEach-Object { 
  Push-Location $_.RelativePath
  Invoke-Expression $_.Command
  Pop-Location
}