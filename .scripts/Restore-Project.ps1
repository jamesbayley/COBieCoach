Set-Location "$PSScriptRoot/.."

$DirectoryCommands = @(
  @{ RelativePath = "."; Command = "npm install -g npm@latest; npm install" }
  @{ RelativePath = "."; Command = "npm install" }
  @{ RelativePath = "."; Command = "npx playwright install" }
  @{ RelativePath = "."; Command = "sudo npx playwright install-deps" }
)

$DirectoryCommands | ForEach-Object { 
  Push-Location $_.RelativePath
  Invoke-Expression $_.Command
  Pop-Location
}