param staticWebAppName string
param location string = resourceGroup().location

resource swa 'Microsoft.Web/staticSites@2022-03-01' = {
  name: staticWebAppName
  location: location
  properties: {}
  tags: null
  sku: {
    name: 'Standard'
    size: 'Standard'
  }
}
