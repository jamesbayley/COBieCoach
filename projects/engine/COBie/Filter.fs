namespace COBieCoach.COBie

[<RequireQualifiedAccess>]
module Filter =
    
    /// The workbook data is passed through a two-stage filtration process to avoid 
    /// scanning data not required either at the current RIBA stage, or for the 
    /// project as a whole. Stage 1 replaces any unnecessary sheets with a set of 
    /// empty lists. Stage 2 is more granular and replaces unrequired fields with 
    /// empty lists for those worksheets that remain.
    let workbook (config: ConfigFile) (currentStage: RIBAStage) (data: Workbook<FieldData>): Workbook<FieldData> =
        
        /// For each worksheet in the workbook, cross-reference against the configuration file 
        /// to determine if the worksheet data should be included within the scan. If a sheet
        /// has been toggled off, then a record consisting of empty lists is returned instead.
        let filterActiveWorksheets (config: ActiveWorksheets) (data: Workbook<FieldData>) : Workbook<FieldData> =           
            {
                Assembly        =   if config.Assembly      then data.Assembly      else Assembly.empty     ()
                Attribute       =   if config.Attribute     then data.Attribute     else Attribute.empty    ()
                Component       =   if config.Component     then data.Component     else Component.empty    ()
                Connection      =   if config.Connection    then data.Connection    else Connection.empty   ()
                Contact         =   if config.Contact       then data.Contact       else Contact.empty      ()
                Coordinate      =   if config.Coordinate    then data.Coordinate    else Coordinate.empty   ()
                Document        =   if config.Document      then data.Document      else Document.empty     ()
                Facility        =   if config.Facility      then data.Facility      else Facility.empty     ()
                Floor           =   if config.Floor         then data.Floor         else Floor.empty        ()
                Impact          =   if config.Impact        then data.Impact        else Impact.empty       ()
                Issue           =   if config.Issue         then data.Issue         else Issue.empty        ()
                Job             =   if config.Job           then data.Job           else Job.empty          ()
                Space           =   if config.Space         then data.Space         else Space.empty        ()
                Spare           =   if config.Spare         then data.Spare         else Spare.empty        ()
                System          =   if config.System        then data.System        else System.empty       ()
                Resource        =   if config.Resource      then data.Resource      else Resource.empty     ()
                Type            =   if config.Type          then data.Type          else Type.empty         ()
                Zone            =   if config.Zone          then data.Zone          else Zone.empty         ()
            }
        
        /// For every field in each worksheet, verify whether the field data should be included within
        /// the COBie scan. If a column is not required then it is replaced within an empty list.
        let filterWorksheetFields (config: Workbook<FieldSettings>) (data: Workbook<FieldData>): Workbook<FieldData> =
            
            /// For a given field of data (i.e. Excel column from a single worksheet)
            /// cross-reference against the field configuration to determine whether
            /// the field has been toggled on/off, and the min. RIBA stage at which 
            /// the data in the field is required. If it is determined that the field
            /// data is not yet necessary, then an empty list is returned instead.
            let filterField (fieldData: FieldData) (fieldSettings: FieldSettings) =
                match fieldSettings.Scan, fieldSettings.RIBAStage with
                | true, rs when rs <= currentStage -> fieldData
                | _ -> []
        
            let filterAssembly (data: Assembly<FieldData>) (config: Assembly<FieldSettings>) =
                {
                    Name                =   filterField     data.Name           config.Name
                    CreatedBy           =   filterField     data.CreatedBy      config.CreatedBy
                    CreatedOn           =   filterField     data.CreatedOn      config.CreatedOn
                    AssemblyType        =   filterField     data.AssemblyType   config.AssemblyType
                    SheetName           =   filterField     data.SheetName      config.SheetName
                    ParentName          =   filterField     data.ParentName     config.ParentName
                    ChildNames          =   filterField     data.ChildNames     config.ChildNames
                    ExtSystem           =   filterField     data.ExtSystem      config.ExtSystem
                    ExtObject           =   filterField     data.ExtObject      config.ExtObject
                    ExtIdentifier       =   filterField     data.ExtIdentifier  config.ExtIdentifier
                    Description         =   filterField     data.Description    config.Description
                }
                
            let filterAttribute (data: Attribute<FieldData>) (config: Attribute<FieldSettings>) =
                {
                    Name                =   filterField     data.Name           config.Name
                    CreatedBy           =   filterField     data.CreatedBy      config.CreatedBy
                    CreatedOn           =   filterField     data.CreatedOn      config.CreatedOn
                    Category            =   filterField     data.Category       config.Category
                    SheetName           =   filterField     data.SheetName      config.SheetName
                    RowName             =   filterField     data.RowName        config.RowName
                    Value               =   filterField     data.Value          config.Value
                    Unit                =   filterField     data.Unit           config.Unit
                    ExtSystem           =   filterField     data.ExtSystem      config.ExtSystem
                    ExtObject           =   filterField     data.ExtObject      config.ExtObject
                    ExtIdentifier       =   filterField     data.ExtIdentifier  config.ExtIdentifier
                    Description         =   filterField     data.Description    config.Description
                    AllowedValues       =   filterField     data.AllowedValues  config.AllowedValues
                }
                
            let filterComponent (data: Component<FieldData>) (config: Component<FieldSettings>) =
                {
                    Name                =   filterField     data.Name               config.Name
                    CreatedBy           =   filterField     data.CreatedBy          config.CreatedBy
                    CreatedOn           =   filterField     data.CreatedOn          config.CreatedOn
                    TypeName            =   filterField     data.TypeName           config.TypeName
                    Space               =   filterField     data.Space              config.Space
                    Description         =   filterField     data.Description        config.Description
                    ExtSystem           =   filterField     data.ExtSystem          config.ExtSystem
                    ExtObject           =   filterField     data.ExtObject          config.ExtObject
                    ExtIdentifier       =   filterField     data.ExtIdentifier      config.ExtIdentifier
                    SerialNumber        =   filterField     data.SerialNumber       config.SerialNumber
                    InstallationDate    =   filterField     data.InstallationDate   config.InstallationDate
                    WarrantyStartDate   =   filterField     data.WarrantyStartDate  config.WarrantyStartDate
                    TagNumber           =   filterField     data.TagNumber          config.TagNumber
                    BarCode             =   filterField     data.BarCode            config.BarCode
                    AssetIdentifier     =   filterField     data.AssetIdentifier    config.AssetIdentifier
                    Area                =   filterField     data.Area               config.Area
                    Length              =   filterField     data.Length             config.Length
                }
                
            let filterConnection (data: Connection<FieldData>) (config: Connection<FieldSettings>) =
                {
                    Name                =   filterField     data.Name               config.Name
                    CreatedBy           =   filterField     data.CreatedBy          config.CreatedBy
                    CreatedOn           =   filterField     data.CreatedOn          config.CreatedOn
                    ConnectionType      =   filterField     data.ConnectionType     config.ConnectionType
                    SheetName           =   filterField     data.SheetName          config.SheetName
                    RowName1            =   filterField     data.RowName1           config.RowName1
                    RowName2            =   filterField     data.RowName2           config.RowName2
                    RealizingElement    =   filterField     data.RealizingElement   config.RealizingElement
                    PortName1           =   filterField     data.PortName1          config.PortName1
                    PortName2           =   filterField     data.PortName2          config.PortName2
                    ExtSystem           =   filterField     data.ExtSystem          config.ExtSystem
                    ExtObject           =   filterField     data.ExtObject          config.ExtObject
                    ExtIdentifier       =   filterField     data.ExtIdentifier      config.ExtIdentifier
                    Description         =   filterField     data.Description        config.Description
                }
                    
            let filterContact (data: Contact<FieldData>) (config: Contact<FieldSettings>) =
                {
                    Email               =   filterField     data.Email              config.Email
                    CreatedBy           =   filterField     data.CreatedBy          config.CreatedBy
                    CreatedOn           =   filterField     data.CreatedOn          config.CreatedOn
                    Category            =   filterField     data.Category           config.Category
                    Company             =   filterField     data.Company            config.Company 
                    Phone               =   filterField     data.Phone              config.Phone
                    ExtSystem           =   filterField     data.ExtSystem          config.ExtSystem
                    ExtObject           =   filterField     data.ExtObject          config.ExtObject
                    ExtIdentifier       =   filterField     data.ExtIdentifier      config.ExtIdentifier
                    Department          =   filterField     data.Department         config.Department
                    OrganizationCode    =   filterField     data.OrganizationCode   config.OrganizationCode
                    GivenName           =   filterField     data.GivenName          config.GivenName
                    FamilyName          =   filterField     data.FamilyName         config.FamilyName
                    Street              =   filterField     data.Street             config.Street
                    PostalBox           =   filterField     data.PostalBox          config.PostalBox
                    Town                =   filterField     data.Town               config.Town
                    StateRegion         =   filterField     data.StateRegion        config.StateRegion
                    PostalCode          =   filterField     data.PostalCode         config.PostalCode
                    Country             =   filterField     data.Country            config.Country 
                }
                
            let filterCoordinate (data: Coordinate<FieldData>) (config: Coordinate<FieldSettings>) =
                {
                    Name                =   filterField     data.Name                   config.Name
                    CreatedBy           =   filterField     data.CreatedBy              config.CreatedBy
                    CreatedOn           =   filterField     data.CreatedOn              config.CreatedOn
                    Category            =   filterField     data.Category               config.Category
                    SheetName           =   filterField     data.SheetName              config.SheetName
                    RowName             =   filterField     data.RowName                config.RowName
                    CoordinateXAxis     =   filterField     data.CoordinateXAxis        config.CoordinateXAxis
                    CoordinateYAxis     =   filterField     data.CoordinateYAxis        config.CoordinateYAxis
                    CoordinateZAxis     =   filterField     data.CoordinateZAxis        config.CoordinateZAxis
                    ExtSystem           =   filterField     data.ExtSystem              config.ExtSystem
                    ExtObject           =   filterField     data.ExtObject              config.ExtObject
                    ExtIdentifier       =   filterField     data.ExtIdentifier          config.ExtIdentifier
                    ClockwiseRotation   =   filterField     data.ClockwiseRotation      config.ClockwiseRotation
                    ElevationalRotation =   filterField     data.ElevationalRotation    config.ElevationalRotation
                    YawRotation         =   filterField     data.YawRotation            config.YawRotation
                }
                
            let filterDocument (data: Document<FieldData>) (config: Document<FieldSettings>) =
                {
                    Name            =    filterField     data.Name           config.Name
                    CreatedBy       =    filterField     data.CreatedBy      config.CreatedBy
                    CreatedOn       =    filterField     data.CreatedOn      config.CreatedOn
                    Category        =    filterField     data.Category       config.Category
                    ApprovalBy      =    filterField     data.ApprovalBy     config.ApprovalBy
                    Stage           =    filterField     data.Stage          config.Stage
                    SheetName       =    filterField     data.SheetName      config.SheetName
                    RowName         =    filterField     data.RowName        config.RowName
                    Directory       =    filterField     data.Directory      config.Directory
                    File            =    filterField     data.File           config.File
                    ExtSystem       =    filterField     data.ExtSystem      config.ExtSystem
                    ExtObject       =    filterField     data.ExtObject      config.ExtObject
                    ExtIdentifier   =    filterField     data.ExtIdentifier  config.ExtIdentifier
                    Description     =    filterField     data.Description    config.Description
                    Reference       =    filterField     data.Reference      config.Reference
                }
                
            let filterFacility (data: Facility<FieldData>) (config: Facility<FieldSettings>) =
                {
                    Name                        =    filterField     data.Name                           config.Name
                    CreatedBy                   =    filterField     data.CreatedBy                      config.CreatedBy
                    CreatedOn                   =    filterField     data.CreatedOn                      config.CreatedOn
                    Category                    =    filterField     data.Category                       config.Category
                    ProjectName                 =    filterField     data.ProjectName                    config.ProjectName
                    SiteName                    =    filterField     data.SiteName                       config.SiteName
                    LinearUnits                 =    filterField     data.LinearUnits                    config.LinearUnits
                    AreaUnits                   =    filterField     data.AreaUnits                      config.AreaUnits
                    VolumeUnits                 =    filterField     data.VolumeUnits                    config.VolumeUnits
                    CurrencyUnit                =    filterField     data.CurrencyUnit                   config.CurrencyUnit
                    AreaMeasurement             =    filterField     data.AreaMeasurement                config.AreaMeasurement
                    ExternalSystem              =    filterField     data.ExternalSystem                 config.ExternalSystem
                    ExternalProjectObject       =    filterField     data.ExternalProjectObject          config.ExternalProjectObject
                    ExternalProjectIdentifier   =    filterField     data.ExternalProjectIdentifier      config.ExternalProjectIdentifier
                    ExternalSiteObject          =    filterField     data.ExternalSiteObject             config.ExternalSiteObject
                    ExternalSiteIdentifier      =    filterField     data.ExternalSiteIdentifier         config.ExternalSiteIdentifier
                    ExternalFacilityObject      =    filterField     data.ExternalFacilityObject         config.ExternalFacilityObject
                    ExternalFacilityIdentifier  =    filterField     data.ExternalFacilityIdentifier     config.ExternalFacilityIdentifier
                    Description                 =    filterField     data.Description                    config.Description
                    ProjectDescription          =    filterField     data.ProjectDescription             config.ProjectDescription
                    SiteDescription             =    filterField     data.SiteDescription                config.SiteDescription
                    Phase                       =    filterField     data.Phase                          config.Phase
                }
                
            let filterFloor (data: Floor<FieldData>) (config: Floor<FieldSettings>) =
                {
                    Name            =    filterField     data.Name               config.Name
                    CreatedBy       =    filterField     data.CreatedBy          config.CreatedBy
                    CreatedOn       =    filterField     data.CreatedOn          config.CreatedOn
                    Category        =    filterField     data.Category           config.Category
                    ExtSystem       =    filterField     data.ExtSystem          config.ExtSystem
                    ExtObject       =    filterField     data.ExtObject          config.ExtObject
                    ExtIdentifier   =    filterField     data.ExtIdentifier      config.ExtIdentifier
                    Description     =    filterField     data.Description        config.Description
                    Elevation       =    filterField     data.Elevation          config.Elevation
                    Height          =    filterField     data.Height             config.Height
                }
                
            let filterImpact (data: Impact<FieldData>) (config: Impact<FieldSettings>) =
                {
                    Name            =    filterField     data.Name               config.Name
                    CreatedBy       =    filterField     data.CreatedBy          config.CreatedBy
                    CreatedOn       =    filterField     data.CreatedOn          config.CreatedOn
                    ImpactType      =    filterField     data.ImpactType         config.ImpactType
                    SheetName       =    filterField     data.SheetName          config.SheetName
                    RowName         =    filterField     data.RowName            config.RowName
                    Value           =    filterField     data.Value              config.Value
                    ImpactUnit      =    filterField     data.ImpactUnit         config.ImpactUnit
                    ImpactStage     =    filterField     data.ImpactStage        config.ImpactStage
                    LeadInTime      =    filterField     data.LeadInTime         config.LeadInTime
                    Duration        =    filterField     data.Duration           config.Duration
                    LeadOutTime     =    filterField     data.LeadOutTime        config.LeadOutTime
                    ExtSystem       =    filterField     data.ExtSystem          config.ExtSystem
                    ExtObject       =    filterField     data.ExtObject          config.ExtObject
                    ExtIdentifier   =    filterField     data.ExtIdentifier      config.ExtIdentifier
                    Description     =    filterField     data.Description        config.Description
                }
                
            let filterIssue (data: Issue<FieldData>) (config: Issue<FieldSettings>) =
                {
                    Name            =    filterField     data.Name               config.Name
                    CreatedBy       =    filterField     data.CreatedBy          config.CreatedBy
                    CreatedOn       =    filterField     data.CreatedOn          config.CreatedOn
                    Type            =    filterField     data.Type               config.Type
                    Risk            =    filterField     data.Risk               config.Risk
                    Chance          =    filterField     data.Chance             config.Chance
                    Impact          =    filterField     data.Impact             config.Impact
                    SheetName1      =    filterField     data.SheetName1         config.SheetName1
                    RowName1        =    filterField     data.RowName1           config.RowName1
                    SheetName2      =    filterField     data.SheetName2         config.SheetName2
                    RowName2        =    filterField     data.RowName2           config.RowName2
                    Description     =    filterField     data.Description        config.Description
                    Owner           =    filterField     data.Owner              config.Owner
                    Mitigation      =    filterField     data.Mitigation         config.Mitigation
                    ExtSystem       =    filterField     data.ExtSystem          config.ExtSystem
                    ExtObject       =    filterField     data.ExtObject          config.ExtObject
                    ExtIdentifier   =    filterField     data.ExtIdentifier      config.ExtIdentifier
                }
                
            let filterJob (data: Job<FieldData>) (config: Job<FieldSettings>) =
                {
                    Name            =    filterField     data.Name               config.Name
                    CreatedBy       =    filterField     data.CreatedBy          config.CreatedBy
                    CreatedOn       =    filterField     data.CreatedOn          config.CreatedOn
                    Category        =    filterField     data.Category           config.Category
                    Status          =    filterField     data.Status             config.Status
                    TypeName        =    filterField     data.TypeName           config.TypeName
                    Description     =    filterField     data.Description        config.Description
                    Duration        =    filterField     data.Duration           config.Duration
                    DurationUnit    =    filterField     data.DurationUnit       config.DurationUnit
                    Start           =    filterField     data.Start              config.Start
                    TaskStartUnit   =    filterField     data.TaskStartUnit      config.TaskStartUnit
                    Frequency       =    filterField     data.Frequency          config.Frequency
                    FrequencyUnit   =    filterField     data.FrequencyUnit      config.FrequencyUnit
                    ExtSystem       =    filterField     data.ExtSystem          config.ExtSystem
                    ExtObject       =    filterField     data.ExtObject          config.ExtObject
                    ExtIdentifier   =    filterField     data.ExtIdentifier      config.ExtIdentifier
                    TaskNumber      =    filterField     data.TaskNumber         config.TaskNumber
                    Priors          =    filterField     data.Priors             config.Priors
                    ResourceNames   =    filterField     data.ResourceNames      config.ResourceNames
                }
                
            let filterSpace (data: Space<FieldData>) (config: Space<FieldSettings>) =
                {
                    Name            =    filterField     data.Name               config.Name
                    CreatedBy       =    filterField     data.CreatedBy          config.CreatedBy
                    CreatedOn       =    filterField     data.CreatedOn          config.CreatedOn
                    Category        =    filterField     data.Category           config.Category
                    FloorName       =    filterField     data.FloorName          config.FloorName
                    Description     =    filterField     data.Description        config.Description
                    ExtSystem       =    filterField     data.ExtSystem          config.ExtSystem
                    ExtObject       =    filterField     data.ExtObject          config.ExtObject
                    ExtIdentifier   =    filterField     data.ExtIdentifier      config.ExtIdentifier
                    RoomTag         =    filterField     data.RoomTag            config.RoomTag
                    UsableHeight    =    filterField     data.UsableHeight       config.UsableHeight
                    GrossArea       =    filterField     data.GrossArea          config.GrossArea
                    NetArea         =    filterField     data.NetArea            config.NetArea
                }
                
            let filterSpare (data: Spare<FieldData>) (config: Spare<FieldSettings>) =
                {
                    Name            =    filterField     data.Name               config.Name
                    CreatedBy       =    filterField     data.CreatedBy          config.CreatedBy
                    CreatedOn       =    filterField     data.CreatedOn          config.CreatedOn
                    Category        =    filterField     data.Category           config.Category
                    TypeName        =    filterField     data.TypeName           config.TypeName
                    Suppliers       =    filterField     data.Suppliers          config.Suppliers
                    ExtSystem       =    filterField     data.ExtSystem          config.ExtSystem
                    ExtObject       =    filterField     data.ExtObject          config.ExtObject
                    ExtIdentifier   =    filterField     data.ExtIdentifier      config.ExtIdentifier
                    Description     =    filterField     data.Description        config.Description
                    SetNumber       =    filterField     data.SetNumber          config.SetNumber
                    PartNumber      =    filterField     data.PartNumber         config.PartNumber
                }
                
            let filterSystem (data: System<FieldData>) (config: System<FieldSettings>) =
                {
                    Name            =    filterField     data.Name               config.Name
                    CreatedBy       =    filterField     data.CreatedBy          config.CreatedBy
                    CreatedOn       =    filterField     data.CreatedOn          config.CreatedOn
                    Category        =    filterField     data.Category           config.Category
                    ComponentNames  =    filterField     data.ComponentNames     config.ComponentNames
                    ExtSystem       =    filterField     data.ExtSystem          config.ExtSystem
                    ExtObject       =    filterField     data.ExtObject          config.ExtObject
                    ExtIdentifier   =    filterField     data.ExtIdentifier      config.ExtIdentifier
                    Description     =    filterField     data.Description        config.Description
                }
                
            let filterResource (data: Resource<FieldData>) (config: Resource<FieldSettings>) =
                {
                    Name            =    filterField     data.Name               config.Name
                    CreatedBy       =    filterField     data.CreatedBy          config.CreatedBy
                    CreatedOn       =    filterField     data.CreatedOn          config.CreatedOn
                    Category        =    filterField     data.Category           config.Category
                    ExtSystem       =    filterField     data.ExtSystem          config.ExtSystem 
                    ExtObject       =    filterField     data.ExtObject          config.ExtObject
                    ExtIdentifier   =    filterField     data.ExtIdentifier      config.ExtIdentifier
                    Description     =    filterField     data.Description        config.Description
                }
                
            let filterType (data: Type<FieldData>) (config: Type<FieldSettings>) =
                {
                    Name                        =   filterField     data.Name                       config.Name
                    CreatedBy                   =   filterField     data.CreatedBy                  config.CreatedBy
                    CreatedOn                   =   filterField     data.CreatedOn                  config.CreatedOn
                    Category                    =   filterField     data.Category                   config.Category
                    Description                 =   filterField     data.Description                config.Description
                    AssetType                   =   filterField     data.AssetType                  config.AssetType
                    Manufacturer                =   filterField     data.Manufacturer               config.Manufacturer
                    ModelNumber                 =   filterField     data.ModelNumber                config.ModelNumber
                    WarrantyGuarantorParts      =   filterField     data.WarrantyGuarantorParts     config.WarrantyGuarantorParts
                    WarrantyDurationParts       =   filterField     data.WarrantyDurationParts      config.WarrantyDurationParts
                    WarrantyGuarantorLabor      =   filterField     data.WarrantyGuarantorLabor     config.WarrantyGuarantorLabor
                    WarrantyDurationLabor       =   filterField     data.WarrantyDurationLabor      config.WarrantyDurationLabor
                    WarrantyDurationUnit        =   filterField     data.WarrantyDurationUnit       config.WarrantyDurationUnit
                    ExtSystem                   =   filterField     data.ExtSystem                  config.ExtSystem
                    ExtObject                   =   filterField     data.ExtObject                  config.ExtObject
                    ExtIdentifier               =   filterField     data.ExtIdentifier              config.ExtIdentifier
                    ReplacementCost             =   filterField     data.ReplacementCost            config.ReplacementCost
                    ExpectedLife                =   filterField     data.ExpectedLife               config.ExpectedLife
                    DurationUnit                =   filterField     data.DurationUnit               config.DurationUnit
                    WarrantyDescription         =   filterField     data.WarrantyDescription        config.WarrantyDescription
                    NominalLength               =   filterField     data.NominalLength              config.NominalLength
                    NominalWidth                =   filterField     data.NominalWidth               config.NominalWidth
                    NominalHeight               =   filterField     data.NominalHeight              config.NominalHeight
                    ModelReference              =   filterField     data.ModelReference             config.ModelReference
                    Shape                       =   filterField     data.Shape                      config.Shape
                    Size                        =   filterField     data.Size                       config.Size
                    Color                       =   filterField     data.Color                      config.Color
                    Finish                      =   filterField     data.Finish                     config.Finish
                    Grade                       =   filterField     data.Grade                      config.Grade
                    Material                    =   filterField     data.Material                   config.Material
                    Constituents                =   filterField     data.Constituents               config.Constituents
                    Features                    =   filterField     data.Features                   config.Features
                    AccessibilityPerformance    =   filterField     data.AccessibilityPerformance   config.AccessibilityPerformance
                    CodePerformance             =   filterField     data.CodePerformance            config.CodePerformance
                    SustainabilityPerformance   =   filterField     data.SustainabilityPerformance  config.SustainabilityPerformance
                    Area                        =   filterField     data.Area                       config.Area
                    Length                      =   filterField     data.Length                     config.Length
                }
        
            let filterZone (data: Zone<FieldData>) (config: Zone<FieldSettings>) =
                {
                    Name            =       filterField     data.Name               config.Name
                    CreatedBy       =       filterField     data.CreatedBy          config.CreatedBy
                    CreatedOn       =       filterField     data.CreatedOn          config.CreatedOn
                    Category        =       filterField     data.Category           config.Category
                    SpaceNames      =       filterField     data.SpaceNames         config.SpaceNames
                    ExtSystem       =       filterField     data.ExtSystem          config.ExtSystem
                    ExtObject       =       filterField     data.ExtObject          config.ExtObject
                    ExtIdentifier   =       filterField     data.ExtIdentifier      config.ExtIdentifier
                    Description     =       filterField     data.Description        config.Description
                }
                
            {
                Assembly    =    filterAssembly      data.Assembly       config.Assembly
                Attribute   =    filterAttribute     data.Attribute      config.Attribute
                Component   =    filterComponent     data.Component      config.Component
                Connection  =    filterConnection    data.Connection     config.Connection
                Contact     =    filterContact       data.Contact        config.Contact
                Coordinate  =    filterCoordinate    data.Coordinate     config.Coordinate
                Document    =    filterDocument      data.Document       config.Document
                Facility    =    filterFacility      data.Facility       config.Facility
                Floor       =    filterFloor         data.Floor          config.Floor
                Impact      =    filterImpact        data.Impact         config.Impact
                Issue       =    filterIssue         data.Issue          config.Issue
                Job         =    filterJob           data.Job            config.Job
                Space       =    filterSpace         data.Space          config.Space
                Spare       =    filterSpare         data.Spare          config.Spare
                System      =    filterSystem        data.System         config.System
                Resource    =    filterResource      data.Resource       config.Resource
                Type        =    filterType          data.Type           config.Type
                Zone        =    filterZone          data.Zone           config.Zone
            }
         
        data
        |> filterActiveWorksheets config.ActiveWorksheets
        |> filterWorksheetFields  config.WorksheetSettings