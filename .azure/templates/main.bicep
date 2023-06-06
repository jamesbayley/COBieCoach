param staticWebAppName string

@allowed([
  'westus2'
  'centralus'
  'eastus2'
  'westeurope'
  'eastasia'
  'eastasiastage'
])
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
