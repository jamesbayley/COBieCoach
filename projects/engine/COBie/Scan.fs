namespace COBieCoach

open System
open COBieCoach
open COBieCoach.Error
open COBieCoach.Scan
open COBieCoach.Metrics


[<RequireQualifiedAccess>]
module Scan = 

    [<RequireQualifiedAccess>]
    module Report = 
    
        [<RequireQualifiedAccess>]
        module Calculate = 
    
            let cellCount (sr: WorkbookScanReport) : CellCount = 
                sr.Assembly.CellCount     +
                sr.Attribute.CellCount    +
                sr.Component.CellCount    +
                sr.Connection.CellCount   +
                sr.Contact.CellCount      +
                sr.Coordinate.CellCount   +
                sr.Document.CellCount     +
                sr.Facility.CellCount     +
                sr.Floor.CellCount        +
                sr.Impact.CellCount       +
                sr.Issue.CellCount        +
                sr.Job.CellCount          +
                sr.Space.CellCount        +
                sr.Spare.CellCount        +
                sr.System.CellCount       +
                sr.Resource.CellCount     +
                sr.Type.CellCount         +
                sr.Zone.CellCount 
                |> CellCount
    
            let errorCount (sr: WorkbookScanReport) : ErrorCount =
                sr.Assembly.ErrorCount    +
                sr.Attribute.ErrorCount   +
                sr.Component.ErrorCount   +
                sr.Connection.ErrorCount  +
                sr.Contact.ErrorCount     +
                sr.Coordinate.ErrorCount  +
                sr.Document.ErrorCount    +
                sr.Facility.ErrorCount    +
                sr.Floor.ErrorCount       +
                sr.Impact.ErrorCount      +
                sr.Issue.ErrorCount       +
                sr.Job.ErrorCount         +
                sr.Space.ErrorCount       +
                sr.Spare.ErrorCount       +
                sr.System.ErrorCount      +
                sr.Resource.ErrorCount    +
                sr.Type.ErrorCount        +
                sr.Zone.ErrorCount 
                |> ErrorCount
                
            let complianceScore (sr: WorkbookScanReport) : ComplianceScore = 
                let cc = cellCount sr
                let ec = errorCount sr
                Scan.Results.calculateCompliance cc ec
             
        let create (sr: WorkbookScanReport) (fileName: string) = 
            {
                FileName            =       fileName
                Date                =       DateOnly.FromDateTime(DateTime.UtcNow)
                Time                =       TimeOnly.FromDateTime(DateTime.UtcNow)
                OverallCompliance   =       Calculate.complianceScore sr
                TotalErrorCount     =       Calculate.errorCount sr
                TotalCellCount      =       Calculate.cellCount sr
            }


    let workbook (cache: Cache) (fileName: string) (data: Workbook<FieldData>): ScanSummary * WorkbookScanReport =

        let scan (v: Validator<_>) (data: _ list) =
            data 
            |> List.map v 
            |> Scan.Results.createReport

        let scanAssembly () : ScanReport<Assembly<ScanReport<Error<string> list>>> =
            let report = 
                {
                    Name            =       data.Assembly.Name              |> scan Validate.String.Is.nonEmpty
                    CreatedBy       =       data.Assembly.CreatedBy         |> scan (Validate.String.Is.emailAddress >>> Cache.search cache ContactEmail)
                    CreatedOn       =       data.Assembly.CreatedOn         |> scan Validate.String.Is.dateTime
                    SheetName       =       data.Assembly.SheetName         |> scan Validate.String.Is.nonEmpty
                    ParentName      =       data.Assembly.ParentName        |> scan Validate.String.Is.nonEmpty
                    ChildNames      =       data.Assembly.ChildNames        |> scan Validate.String.Is.nonEmpty   
                    AssemblyType    =       data.Assembly.AssemblyType      |> scan Validate.String.Is.nonEmpty
                    ExtSystem       =       data.Assembly.ExtSystem         |> scan Validate.String.Is.nonEmpty
                    ExtObject       =       data.Assembly.ExtObject         |> scan Validate.String.Is.nonEmpty
                    ExtIdentifier   =       data.Assembly.ExtIdentifier     |> scan Validate.String.Is.guid
                    Description     =       data.Assembly.Description       |> scan Validate.String.Is.nonEmpty
                }    
            
            report
            |> Assembly.getFieldReports<_> 
            |> Scan.Report.Metrics.create
            |||> ScanReport.create report
                          
            
        let scanAttribute () : ScanReport<Attribute<ScanReport<Error<string> list>>> =
            let report = 
                {
                    Name                = data.Attribute.Name               |> scan Validate.String.Is.nonEmpty
                    CreatedBy           = data.Attribute.CreatedBy          |> scan (Validate.String.Is.emailAddress >>> Cache.search cache ContactEmail)
                    CreatedOn           = data.Attribute.CreatedOn          |> scan Validate.String.Is.dateTime
                    Category            = data.Attribute.Category           |> scan Validate.String.Is.nonEmpty
                    SheetName           = data.Attribute.SheetName          |> scan Validate.String.Is.nonEmpty
                    RowName             = data.Attribute.RowName            |> scan Validate.String.Is.nonEmpty
                    Value               = data.Attribute.Value              |> scan Validate.String.Is.nonEmpty
                    Unit                = data.Attribute.Unit               |> scan Validate.String.Is.nonEmpty
                    ExtSystem           = data.Attribute.ExtSystem          |> scan Validate.String.Is.nonEmpty
                    ExtObject           = data.Attribute.ExtObject          |> scan Validate.String.Is.nonEmpty
                    ExtIdentifier       = data.Attribute.ExtIdentifier      |> scan Validate.String.Is.guid            
                    Description         = data.Attribute.Description        |> scan Validate.String.Is.nonEmpty
                    AllowedValues       = data.Attribute.AllowedValues      |> scan Validate.String.Is.nonEmpty
                }
            
            report
            |> Attribute.getFieldReports<_> 
            |> Scan.Report.Metrics.create
            |||> ScanReport.create report
 
 
        let scanComponent () : ScanReport<Component<ScanReport<Error<string> list>>> =
            let report = 
                {
                    Name                = data.Component.Name               |> scan Validate.String.Is.nonEmpty
                    CreatedBy           = data.Component.CreatedBy          |> scan (Validate.String.Is.emailAddress >>> Cache.search cache ContactEmail)
                    CreatedOn           = data.Component.CreatedOn          |> scan Validate.String.Is.dateTime
                    TypeName            = data.Component.TypeName           |> scan (Validate.String.Is.nonEmpty >>> Cache.search cache TypeName)
                    Space               = data.Component.Space              |> scan (Validate.String.Is.nonEmpty >>> Cache.search cache SpaceName)
                    Description         = data.Component.Description        |> scan Validate.String.Is.nonEmpty
                    ExtSystem           = data.Component.ExtSystem          |> scan Validate.String.Is.nonEmpty
                    ExtObject           = data.Component.ExtObject          |> scan Validate.String.Is.nonEmpty
                    ExtIdentifier       = data.Component.ExtIdentifier      |> scan Validate.String.Is.guid
                    SerialNumber        = data.Component.SerialNumber       |> scan Validate.String.Is.nonEmpty
                    InstallationDate    = data.Component.InstallationDate   |> scan Validate.String.Is.date
                    WarrantyStartDate   = data.Component.WarrantyStartDate  |> scan Validate.String.Is.date
                    TagNumber           = data.Component.TagNumber          |> scan Validate.String.Is.nonEmpty
                    BarCode             = data.Component.BarCode            |> scan Validate.String.Is.nonEmpty
                    AssetIdentifier     = data.Component.AssetIdentifier    |> scan Validate.String.Is.nonEmpty
                    Area                = data.Component.Area               |> scan Validate.String.Is.positiveNumber
                    Length              = data.Component.Length             |> scan Validate.String.Is.positiveNumber
                }

            report
            |> Component.getFieldReports<_> 
            |> Scan.Report.Metrics.create
            |||> ScanReport.create report
                

        let scanConnection () : ScanReport<Connection<ScanReport<Error<string> list>>> =
            let report = 
                {
                    Name                = data.Connection.Name              |> scan Validate.String.Is.nonEmpty
                    CreatedBy           = data.Connection.CreatedBy         |> scan (Validate.String.Is.emailAddress >>> Cache.search cache ContactEmail)
                    CreatedOn           = data.Connection.CreatedOn         |> scan Validate.String.Is.dateTime  
                    ConnectionType      = data.Connection.ConnectionType    |> scan Validate.String.Is.nonEmpty
                    SheetName           = data.Connection.SheetName         |> scan Validate.String.Is.nonEmpty
                    RowName1            = data.Connection.RowName1          |> scan Validate.String.Is.nonEmpty
                    RowName2            = data.Connection.RowName2          |> scan Validate.String.Is.nonEmpty
                    RealizingElement    = data.Connection.RealizingElement  |> scan Validate.String.Is.nonEmpty
                    PortName1           = data.Connection.PortName1         |> scan Validate.String.Is.nonEmpty
                    PortName2           = data.Connection.PortName2         |> scan Validate.String.Is.nonEmpty
                    ExtSystem           = data.Connection.ExtSystem         |> scan Validate.String.Is.nonEmpty
                    ExtObject           = data.Connection.ExtObject         |> scan Validate.String.Is.nonEmpty
                    ExtIdentifier       = data.Connection.ExtIdentifier     |> scan Validate.String.Is.guid       
                    Description         = data.Connection.Description       |> scan Validate.String.Is.nonEmpty
                }
  
            report
            |> Connection.getFieldReports<_> 
            |> Scan.Report.Metrics.create
            |||> ScanReport.create report
        

        let scanContact () : ScanReport<Contact<ScanReport<Error<string> list>>> =
            let report = 
                {
                    Email               = data.Contact.Email                |> scan Validate.String.Is.emailAddress    
                    CreatedBy           = data.Contact.CreatedBy            |> scan Validate.String.Is.emailAddress    
                    CreatedOn           = data.Contact.CreatedOn            |> scan Validate.String.Is.dateTime        
                    Category            = data.Contact.Category             |> scan Validate.String.Is.uniClass       
                    Company             = data.Contact.Company              |> scan Validate.String.Is.nonEmpty  
                    Phone               = data.Contact.Phone                |> scan Validate.String.Is.phoneNumber     
                    ExtSystem           = data.Contact.ExtSystem            |> scan Validate.String.Is.nonEmpty 
                    ExtObject           = data.Contact.ExtObject            |> scan Validate.String.Is.nonEmpty  
                    ExtIdentifier       = data.Contact.ExtIdentifier        |> scan Validate.String.Is.guid         
                    Department          = data.Contact.Department           |> scan Validate.String.Is.nonEmpty
                    OrganizationCode    = data.Contact.OrganizationCode     |> scan Validate.String.Is.organizationCode
                    GivenName           = data.Contact.GivenName            |> scan Validate.String.Is.nonEmpty        
                    FamilyName          = data.Contact.FamilyName           |> scan Validate.String.Is.nonEmpty        
                    Street              = data.Contact.Street               |> scan Validate.String.Is.nonEmpty
                    PostalBox           = data.Contact.PostalBox            |> scan Validate.String.Is.POBox      
                    Town                = data.Contact.Town                 |> scan Validate.String.Is.nonEmpty  
                    StateRegion         = data.Contact.StateRegion          |> scan Validate.String.Is.nonEmpty    
                    PostalCode          = data.Contact.PostalCode           |> scan Validate.String.Is.nonEmpty       
                    Country             = data.Contact.Country              |> scan Validate.String.Is.nonEmpty   
                }

            report
            |> Contact.getFieldReports<_> 
            |> Scan.Report.Metrics.create
            |||> ScanReport.create report


        let scanCoordinate () : ScanReport<Coordinate<ScanReport<Error<string> list>>> =
            let report = 
                {
                    Name                = data.Coordinate.Name                  |> scan Validate.String.Is.nonEmpty
                    CreatedBy           = data.Coordinate.CreatedBy             |> scan (Validate.String.Is.emailAddress >>> Cache.search cache ContactEmail)
                    CreatedOn           = data.Coordinate.CreatedOn             |> scan Validate.String.Is.dateTime
                    Category            = data.Coordinate.Category              |> scan Validate.String.Is.nonEmpty     
                    SheetName           = data.Coordinate.SheetName             |> scan Validate.String.Is.nonEmpty     
                    RowName             = data.Coordinate.RowName               |> scan Validate.String.Is.nonEmpty     
                    CoordinateXAxis     = data.Coordinate.CoordinateXAxis       |> scan Validate.String.Is.nonEmpty
                    CoordinateYAxis     = data.Coordinate.CoordinateYAxis       |> scan Validate.String.Is.nonEmpty    
                    CoordinateZAxis     = data.Coordinate.CoordinateZAxis       |> scan Validate.String.Is.nonEmpty    
                    ExtSystem           = data.Coordinate.ExtSystem             |> scan Validate.String.Is.nonEmpty     
                    ExtObject           = data.Coordinate.ExtObject             |> scan Validate.String.Is.nonEmpty
                    ExtIdentifier       = data.Coordinate.ExtIdentifier         |> scan Validate.String.Is.guid              
                    ClockwiseRotation   = data.Coordinate.ClockwiseRotation     |> scan Validate.String.Is.nonEmpty 
                    ElevationalRotation = data.Coordinate.ElevationalRotation   |> scan Validate.String.Is.nonEmpty 
                    YawRotation         = data.Coordinate.YawRotation           |> scan Validate.String.Is.nonEmpty
                }

            report
            |> Coordinate.getFieldReports<_> 
            |> Scan.Report.Metrics.create
            |||> ScanReport.create report

    

        let scanDocument () : ScanReport<Document<ScanReport<Error<string> list>>> =
            let report = 
                {
                    Name                = data.Document.Name            |> scan Validate.String.Is.nonEmpty         
                    CreatedBy           = data.Document.CreatedBy       |> scan (Validate.String.Is.emailAddress >>> Cache.search cache ContactEmail)           
                    CreatedOn           = data.Document.CreatedOn       |> scan Validate.String.Is.dateTime                
                    Category            = data.Document.Category        |> scan Validate.String.Is.nonEmpty          
                    ApprovalBy          = data.Document.ApprovalBy      |> scan Validate.String.Is.nonEmpty          
                    Stage               = data.Document.Stage           |> scan Validate.String.Is.nonEmpty          
                    SheetName           = data.Document.SheetName       |> scan Validate.String.Is.nonEmpty          
                    RowName             = data.Document.RowName         |> scan Validate.String.Is.nonEmpty          
                    Directory           = data.Document.Directory       |> scan Validate.String.Is.nonEmpty          
                    File                = data.Document.File            |> scan Validate.String.Is.nonEmpty          
                    ExtSystem           = data.Document.ExtSystem       |> scan Validate.String.Is.nonEmpty          
                    ExtObject           = data.Document.ExtObject       |> scan Validate.String.Is.nonEmpty          
                    ExtIdentifier       = data.Document.ExtIdentifier   |> scan Validate.String.Is.guid                 
                    Description         = data.Document.Description     |> scan Validate.String.Is.nonEmpty          
                    Reference           = data.Document.Reference       |> scan Validate.String.Is.nonEmpty          
                }

            report
            |> Document.getFieldReports<_> 
            |> Scan.Report.Metrics.create
            |||> ScanReport.create report
  

        let scanFacility () : ScanReport<Facility<ScanReport<Error<string> list>>> =
            let report = 
                {             
                    Name                        = data.Facility.Name                        |> scan Validate.String.Is.nonEmpty         
                    CreatedBy                   = data.Facility.CreatedBy                   |> scan (Validate.String.Is.emailAddress >>> Cache.search cache ContactEmail)
                    CreatedOn                   = data.Facility.CreatedOn                   |> scan Validate.String.Is.dateTime                  
                    Category                    = data.Facility.Category                    |> scan Validate.String.Is.uniClass                  
                    ProjectName                 = data.Facility.ProjectName                 |> scan Validate.String.Is.nonEmpty  
                    SiteName                    = data.Facility.SiteName                    |> scan Validate.String.Is.nonEmpty        
                    LinearUnits                 = data.Facility.LinearUnits                 |> scan Validate.String.Is.linearUnits      
                    AreaUnits                   = data.Facility.AreaUnits                   |> scan Validate.String.Is.areaUnits          
                    VolumeUnits                 = data.Facility.VolumeUnits                 |> scan Validate.String.Is.volumeUnits
                    CurrencyUnit                = data.Facility.CurrencyUnit                |> scan Validate.String.Is.currency               
                    AreaMeasurement             = data.Facility.AreaMeasurement             |> scan Validate.String.Is.nonEmpty
                    ExternalSystem              = data.Facility.ExternalSystem              |> scan Validate.String.Is.nonEmpty          
                    ExternalProjectObject       = data.Facility.ExternalProjectObject       |> scan Validate.String.Is.nonEmpty
                    ExternalProjectIdentifier   = data.Facility.ExternalProjectIdentifier   |> scan Validate.String.Is.guid              
                    ExternalSiteObject          = data.Facility.ExternalSiteObject          |> scan Validate.String.Is.nonEmpty
                    ExternalSiteIdentifier      = data.Facility.ExternalSiteIdentifier      |> scan Validate.String.Is.guid             
                    ExternalFacilityObject      = data.Facility.ExternalFacilityObject      |> scan Validate.String.Is.nonEmpty
                    ExternalFacilityIdentifier  = data.Facility.ExternalFacilityIdentifier  |> scan Validate.String.Is.nonEmpty
                    Description                 = data.Facility.Description                 |> scan Validate.String.Is.nonEmpty
                    ProjectDescription          = data.Facility.ProjectDescription          |> scan Validate.String.Is.nonEmpty
                    SiteDescription             = data.Facility.SiteDescription             |> scan Validate.String.Is.nonEmpty        
                    Phase                       = data.Facility.Phase                       |> scan Validate.String.Is.nonEmpty 
                }

            report
            |> Facility.getFieldReports<_> 
            |> Scan.Report.Metrics.create
            |||> ScanReport.create report


        let scanFloor () : ScanReport<Floor<ScanReport<Error<string> list>>> =
            let report = 
                {             
                    Name            = data.Floor.Name           |> scan Validate.String.Is.nonEmpty   
                    CreatedBy       = data.Floor.CreatedBy      |> scan (Validate.String.Is.emailAddress >>> Cache.search cache ContactEmail)      
                    CreatedOn       = data.Floor.CreatedOn      |> scan Validate.String.Is.dateTime
                    Category        = data.Floor.Category       |> scan Validate.String.Is.nonEmpty
                    ExtSystem       = data.Floor.ExtSystem      |> scan Validate.String.Is.nonEmpty      
                    ExtObject       = data.Floor.ExtObject      |> scan Validate.String.Is.nonEmpty      
                    ExtIdentifier   = data.Floor.ExtIdentifier  |> scan Validate.String.Is.guid             
                    Description     = data.Floor.Description    |> scan Validate.String.Is.nonEmpty
                    Elevation       = data.Floor.Elevation      |> scan Validate.String.Is.realNumber      
                    Height          = data.Floor.Height         |> scan Validate.String.Is.positiveNumber      
                }

            report
            |> Floor.getFieldReports<_> 
            |> Scan.Report.Metrics.create
            |||> ScanReport.create report

 
        let scanImpact () : ScanReport<Impact<ScanReport<Error<string> list>>> =
            let report = 
                {             
                    Name            = data.Impact.Name          |> scan Validate.String.Is.nonEmpty   
                    CreatedBy       = data.Impact.CreatedBy     |> scan (Validate.String.Is.emailAddress >>> Cache.search cache ContactEmail)
                    CreatedOn       = data.Impact.CreatedOn     |> scan Validate.String.Is.dateTime        
                    ImpactType      = data.Impact.ImpactType    |> scan Validate.String.Is.nonEmpty
                    SheetName       = data.Impact.ImpactStage   |> scan Validate.String.Is.nonEmpty     
                    RowName         = data.Impact.SheetName     |> scan Validate.String.Is.nonEmpty     
                    Value           = data.Impact.RowName       |> scan Validate.String.Is.nonEmpty    
                    ImpactUnit      = data.Impact.Value         |> scan Validate.String.Is.nonEmpty    
                    ImpactStage     = data.Impact.ImpactUnit    |> scan Validate.String.Is.nonEmpty
                    LeadInTime      = data.Impact.LeadInTime    |> scan Validate.String.Is.nonEmpty      
                    Duration        = data.Impact.Duration      |> scan Validate.String.Is.nonEmpty    
                    LeadOutTime     = data.Impact.LeadOutTime   |> scan Validate.String.Is.nonEmpty
                    ExtSystem       = data.Impact.ExtSystem     |> scan Validate.String.Is.nonEmpty     
                    ExtObject       = data.Impact.ExtObject     |> scan Validate.String.Is.nonEmpty     
                    ExtIdentifier   = data.Impact.ExtIdentifier |> scan Validate.String.Is.guid        
                    Description     = data.Impact.Description   |> scan Validate.String.Is.nonEmpty
                }

            report
            |>Impact.getFieldReports<_> 
            |> Scan.Report.Metrics.create
            |||> ScanReport.create report


        let scanIssue () : ScanReport<Issue<ScanReport<Error<string> list>>> =
            let report = 
                {             
                    Name            = data.Issue.Name           |> scan Validate.String.Is.nonEmpty
                    CreatedBy       = data.Issue.CreatedBy      |> scan (Validate.String.Is.emailAddress >>> Cache.search cache ContactEmail)        
                    CreatedOn       = data.Issue.CreatedOn      |> scan Validate.String.Is.dateTime          
                    Type            = data.Issue.Type           |> scan Validate.String.Is.nonEmpty       
                    Risk            = data.Issue.Risk           |> scan Validate.String.Is.nonEmpty     
                    Chance          = data.Issue.Chance         |> scan Validate.String.Is.nonEmpty       
                    Impact          = data.Issue.Impact         |> scan Validate.String.Is.nonEmpty      
                    SheetName1      = data.Issue.SheetName1     |> scan Validate.String.Is.nonEmpty 
                    RowName1        = data.Issue.RowName1       |> scan Validate.String.Is.nonEmpty   
                    SheetName2      = data.Issue.SheetName2     |> scan Validate.String.Is.nonEmpty       
                    RowName2        = data.Issue.RowName2       |> scan Validate.String.Is.nonEmpty    
                    Description     = data.Issue.Description    |> scan Validate.String.Is.nonEmpty     
                    Owner           = data.Issue.Owner          |> scan Validate.String.Is.nonEmpty
                    Mitigation      = data.Issue.Mitigation     |> scan Validate.String.Is.nonEmpty
                    ExtSystem       = data.Issue.ExtSystem      |> scan Validate.String.Is.nonEmpty      
                    ExtObject       = data.Issue.ExtObject      |> scan Validate.String.Is.nonEmpty     
                    ExtIdentifier   = data.Issue.ExtIdentifier  |> scan Validate.String.Is.guid       
                }

            report
            |> Issue.getFieldReports<_> 
            |> Scan.Report.Metrics.create
            |||> ScanReport.create report
 

            
        let scanJob () : ScanReport<Job<ScanReport<Error<string> list>>> =
            let report = 
                {
                    Name            = data.Job.Name             |> scan Validate.String.Is.nonEmpty 
                    CreatedBy       = data.Job.CreatedBy        |> scan (Validate.String.Is.emailAddress >>> Cache.search cache ContactEmail) 
                    CreatedOn       = data.Job.CreatedOn        |> scan Validate.String.Is.dateTime        
                    Category        = data.Job.Category         |> scan Validate.String.Is.nonEmpty
                    Status          = data.Job.Status           |> scan Validate.String.Is.nonEmpty    
                    TypeName        = data.Job.TypeName         |> scan Validate.String.Is.nonEmpty
                    Description     = data.Job.Description      |> scan Validate.String.Is.nonEmpty
                    Duration        = data.Job.Duration         |> scan Validate.String.Is.positiveNumber
                    DurationUnit    = data.Job.DurationUnit     |> scan Validate.String.Is.durationUnit
                    Start           = data.Job.Start            |> scan Validate.String.Is.date
                    TaskStartUnit   = data.Job.TaskStartUnit    |> scan Validate.String.Is.nonEmpty
                    Frequency       = data.Job.Frequency        |> scan Validate.String.Is.nonEmpty  
                    FrequencyUnit   = data.Job.FrequencyUnit    |> scan Validate.String.Is.nonEmpty
                    ExtSystem       = data.Job.ExtSystem        |> scan Validate.String.Is.nonEmpty  
                    ExtObject       = data.Job.ExtObject        |> scan Validate.String.Is.nonEmpty      
                    ExtIdentifier   = data.Job.ExtIdentifier    |> scan Validate.String.Is.guid          
                    TaskNumber      = data.Job.TaskNumber       |> scan Validate.String.Is.nonEmpty
                    Priors          = data.Job.Priors           |> scan Validate.String.Is.nonEmpty  
                    ResourceNames   = data.Job.ResourceNames    |> scan Validate.String.Is.nonEmpty
                }

            report
            |> Job.getFieldReports<_> 
            |> Scan.Report.Metrics.create
            |||> ScanReport.create report


        let scanSpace () : ScanReport<Space<ScanReport<Error<string> list>>> =
            let report = 
                {             
                    Name            = data.Space.Name           |> scan Validate.String.Is.nonEmpty
                    CreatedBy       = data.Space.CreatedBy      |> scan (Validate.String.Is.emailAddress >>> Cache.search cache ContactEmail)
                    CreatedOn       = data.Space.CreatedOn      |> scan Validate.String.Is.dateTime      
                    Category        = data.Space.Category       |> scan Validate.String.Is.uniClass         
                    FloorName       = data.Space.FloorName      |> scan (Validate.String.Is.nonEmpty >>> Cache.search cache FloorName)
                    Description     = data.Space.Description    |> scan Validate.String.Is.nonEmpty
                    ExtSystem       = data.Space.ExtSystem      |> scan Validate.String.Is.nonEmpty     
                    ExtObject       = data.Space.ExtObject      |> scan Validate.String.Is.nonEmpty     
                    ExtIdentifier   = data.Space.ExtIdentifier  |> scan Validate.String.Is.guid    
                    RoomTag         = data.Space.RoomTag        |> scan Validate.String.Is.nonEmpty
                    UsableHeight    = data.Space.UsableHeight   |> scan Validate.String.Is.positiveNumber
                    GrossArea       = data.Space.GrossArea      |> scan Validate.String.Is.positiveNumber
                    NetArea         = data.Space.NetArea        |> scan Validate.String.Is.positiveNumber 
                }
            
            report
            |> Space.getFieldReports<_> 
            |> Scan.Report.Metrics.create
            |||> ScanReport.create report
            

        let scanSpare () : ScanReport<Spare<ScanReport<Error<string> list>>> =
            let report = 
                {             
                    Name            = data.Spare.Name           |> scan Validate.String.Is.nonEmpty
                    CreatedBy       = data.Spare.CreatedBy      |> scan (Validate.String.Is.emailAddress >>> Cache.search cache ContactEmail)  
                    CreatedOn       = data.Spare.CreatedOn      |> scan Validate.String.Is.dateTime
                    Category        = data.Spare.Category       |> scan Validate.String.Is.uniClass           
                    TypeName        = data.Spare.TypeName       |> scan Validate.String.Is.nonEmpty 
                    Suppliers       = data.Spare.Suppliers      |> scan Validate.String.Is.nonEmpty      
                    ExtSystem       = data.Spare.ExtSystem      |> scan Validate.String.Is.nonEmpty      
                    ExtObject       = data.Spare.ExtObject      |> scan Validate.String.Is.nonEmpty      
                    ExtIdentifier   = data.Spare.ExtIdentifier  |> scan Validate.String.Is.guid       
                    Description     = data.Spare.Description    |> scan Validate.String.Is.nonEmpty
                    SetNumber       = data.Spare.SetNumber      |> scan Validate.String.Is.nonEmpty  
                    PartNumber      = data.Spare.PartNumber     |> scan Validate.String.Is.nonEmpty      
                }

            report
            |> Spare.getFieldReports<_> 
            |> Scan.Report.Metrics.create
            |||> ScanReport.create report

            
        let scanSystem () : ScanReport<System<ScanReport<Error<string> list>>> =
            let report = 
                {             
                    Name            = data.System.Name           |> scan Validate.String.Is.nonEmpty        
                    CreatedBy       = data.System.CreatedBy      |> scan (Validate.String.Is.emailAddress >>> Cache.search cache ContactEmail)
                    CreatedOn       = data.System.CreatedOn      |> scan Validate.String.Is.dateTime            
                    Category        = data.System.Category       |> scan Validate.String.Is.uniClass  
                    ComponentNames  = data.System.ComponentNames |> scan (Validate.String.Is.nonEmpty >>> Cache.search cache ComponentName)
                    ExtSystem       = data.System.ExtSystem      |> scan Validate.String.Is.nonEmpty     
                    ExtObject       = data.System.ExtObject      |> scan Validate.String.Is.nonEmpty
                    ExtIdentifier   = data.System.ExtIdentifier  |> scan Validate.String.Is.guid    
                    Description     = data.System.Description    |> scan Validate.String.Is.nonEmpty   
                }

            report
            |> System.getFieldReports<_> 
            |> Scan.Report.Metrics.create
            |||> ScanReport.create report
  

        let scanResource () : ScanReport<Resource<ScanReport<Error<string> list>>> =
            let report =
                {             
                    Name            = data.Resource.Name            |> scan Validate.String.Is.nonEmpty
                    CreatedBy       = data.Resource.CreatedBy       |> scan (Validate.String.Is.emailAddress >>> Cache.search cache ContactEmail)
                    CreatedOn       = data.Resource.CreatedOn       |> scan Validate.String.Is.dateTime           
                    Category        = data.Resource.Category        |> scan Validate.String.Is.uniClass           
                    ExtSystem       = data.Resource.ExtSystem       |> scan Validate.String.Is.nonEmpty
                    ExtObject       = data.Resource.ExtObject       |> scan Validate.String.Is.nonEmpty      
                    ExtIdentifier   = data.Resource.ExtIdentifier   |> scan Validate.String.Is.guid          
                    Description     = data.Resource.Description     |> scan Validate.String.Is.nonEmpty
                }

            report
            |> Resource.getFieldReports<_> 
            |> Scan.Report.Metrics.create
            |||> ScanReport.create report


        let scanType () : ScanReport<Type<ScanReport<Error<string> list>>> =
            let report = 
                {             
                    Name                        = data.Type.Name                        |> scan  Validate.String.Is.nonEmpty         
                    CreatedBy                   = data.Type.CreatedBy                   |> scan  (Validate.String.Is.emailAddress >>> Cache.search cache ContactEmail)
                    CreatedOn                   = data.Type.CreatedOn                   |> scan  Validate.String.Is.dateTime                 
                    Category                    = data.Type.Category                    |> scan  Validate.String.Is.nonEmpty
                    Description                 = data.Type.Description                 |> scan  Validate.String.Is.nonEmpty
                    AssetType                   = data.Type.AssetType                   |> scan  Validate.String.Is.assetType         
                    Manufacturer                = data.Type.Manufacturer                |> scan  (Validate.String.Is.emailAddress >>> Cache.search cache ContactEmail)
                    ModelNumber                 = data.Type.ModelNumber                 |> scan  Validate.String.Is.nonEmpty
                    WarrantyGuarantorParts      = data.Type.WarrantyGuarantorParts      |> scan  (Validate.String.Is.emailAddress >>> Cache.search cache ContactEmail)
                    WarrantyDurationParts       = data.Type.WarrantyDurationParts       |> scan  Validate.String.Is.nonEmpty
                    WarrantyGuarantorLabor      = data.Type.WarrantyGuarantorLabor      |> scan  (Validate.String.Is.emailAddress >>> Cache.search cache ContactEmail)
                    WarrantyDurationLabor       = data.Type.WarrantyDurationLabor       |> scan  Validate.String.Is.nonEmpty
                    WarrantyDurationUnit        = data.Type.WarrantyDurationUnit        |> scan  Validate.String.Is.durationUnit          
                    ExtSystem                   = data.Type.ExtSystem                   |> scan  Validate.String.Is.nonEmpty
                    ExtObject                   = data.Type.ExtObject                   |> scan  Validate.String.Is.nonEmpty          
                    ExtIdentifier               = data.Type.ExtIdentifier               |> scan  Validate.String.Is.guid             
                    ReplacementCost             = data.Type.ReplacementCost             |> scan  Validate.String.Is.nonEmpty
                    ExpectedLife                = data.Type.ExpectedLife                |> scan  Validate.String.Is.nonEmpty        
                    DurationUnit                = data.Type.DurationUnit                |> scan  Validate.String.Is.durationUnit           
                    WarrantyDescription         = data.Type.WarrantyDescription         |> scan  Validate.String.Is.nonEmpty
                    NominalLength               = data.Type.NominalLength               |> scan  Validate.String.Is.positiveNumber     
                    NominalWidth                = data.Type.NominalWidth                |> scan  Validate.String.Is.positiveNumber          
                    NominalHeight               = data.Type.NominalHeight               |> scan  Validate.String.Is.positiveNumber            
                    ModelReference              = data.Type.ModelReference              |> scan  Validate.String.Is.nonEmpty            
                    Shape                       = data.Type.Shape                       |> scan  Validate.String.Is.nonEmpty  
                    Size                        = data.Type.Size                        |> scan  Validate.String.Is.nonEmpty          
                    Color                       = data.Type.Color                       |> scan  Validate.String.Is.nonEmpty            
                    Finish                      = data.Type.Finish                      |> scan  Validate.String.Is.nonEmpty            
                    Grade                       = data.Type.Grade                       |> scan  Validate.String.Is.nonEmpty          
                    Material                    = data.Type.Material                    |> scan  Validate.String.Is.nonEmpty
                    Constituents                = data.Type.Constituents                |> scan  Validate.String.Is.nonEmpty
                    Features                    = data.Type.Features                    |> scan  Validate.String.Is.nonEmpty       
                    AccessibilityPerformance    = data.Type.AccessibilityPerformance    |> scan  Validate.String.Is.nonEmpty
                    CodePerformance             = data.Type.CodePerformance             |> scan  Validate.String.Is.nonEmpty  
                    SustainabilityPerformance   = data.Type.SustainabilityPerformance   |> scan  Validate.String.Is.nonEmpty
                    Area                        = data.Type.Area                        |> scan  Validate.String.Is.positiveNumber
                    Length                      = data.Type.Length                      |> scan  Validate.String.Is.positiveNumber
                }

            report
            |> Type.getFieldReports<_> 
            |> Scan.Report.Metrics.create
            |||> ScanReport.create report


        let scanZone () : ScanReport<Zone<ScanReport<Error<string> list>>> =
            let report = 
                {             
                    Name            = data.Zone.Name            |> scan Validate.String.Is.nonEmpty
                    CreatedBy       = data.Zone.CreatedBy       |> scan (Validate.String.Is.emailAddress >>> Cache.search cache ContactEmail)
                    CreatedOn       = data.Zone.CreatedOn       |> scan Validate.String.Is.dateTime      
                    Category        = data.Zone.Category        |> scan Validate.String.Is.zoneCategory
                    SpaceNames      = data.Zone.SpaceNames      |> scan (Validate.String.Is.nonEmpty >>> Cache.search cache SpaceName)
                    ExtSystem       = data.Zone.ExtSystem       |> scan Validate.String.Is.nonEmpty
                    ExtObject       = data.Zone.ExtObject       |> scan Validate.String.Is.nonEmpty    
                    ExtIdentifier   = data.Zone.ExtIdentifier   |> scan Validate.String.Is.guid      
                    Description     = data.Zone.Description     |> scan Validate.String.Is.nonEmpty
                }

            report
            |> Zone.getFieldReports<_> 
            |> Scan.Report.Metrics.create
            |||> ScanReport.create report
        

        let workbookScanReport = 
            {
                Assembly    =   scanAssembly    ()
                Attribute   =   scanAttribute   ()
                Component   =   scanComponent   ()
                Connection  =   scanConnection  ()
                Contact     =   scanContact     ()
                Coordinate  =   scanCoordinate  ()
                Document    =   scanDocument    ()
                Facility    =   scanFacility    ()
                Floor       =   scanFloor       ()
                Impact      =   scanImpact      ()
                Issue       =   scanIssue       ()
                Job         =   scanJob         ()
                Space       =   scanSpace       ()
                Spare       =   scanSpare       ()
                System      =   scanSystem      () 
                Resource    =   scanResource    ()
                Type        =   scanType        ()
                Zone        =   scanZone        ()
            }

        let scanSummary = Report.create workbookScanReport fileName
        scanSummary, workbookScanReport