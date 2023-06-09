namespace COBieCoach.COBie

open COBieCoach.IO
open COBieCoach.Scan
open COBieCoach.Error
open COBieCoach.Metrics


/// Generic representation of the 
/// COBie Assembly Excel Worksheet.
type Assembly<'TField> =
    {
        Name            :   'TField
        CreatedBy       :   'TField
        CreatedOn       :   'TField
        AssemblyType    :   'TField
        SheetName       :   'TField
        ParentName      :   'TField
        ChildNames      :   'TField
        ExtSystem       :   'TField
        ExtObject       :   'TField
        ExtIdentifier   :   'TField
        Description     :   'TField
    }
        
    /// Produce an Assembly record 
    /// where the value for each field 
    /// is an empty generic list.
    static member empty () : Assembly<'TField list> =
        {
            Name            =   []
            CreatedBy       =   []
            CreatedOn       =   []
            AssemblyType    =   []
            SheetName       =   []
            ParentName      =   []
            ChildNames      =   []
            ExtSystem       =   []
            ExtObject       =   []
            ExtIdentifier   =   []
            Description     =   []
        }

    /// Fetch the full set of scan reports for
    /// all fields in the Assembly worksheet.
    static member getFieldReports (sr: Assembly<ScanReport<_>>) = 
        [ 
            sr.Name
            sr.CreatedBy
            sr.CreatedOn
            sr.SheetName 
            sr.ParentName 
            sr.ChildNames  
            sr.AssemblyType
            sr.ExtSystem
            sr.ExtObject    
            sr.ExtIdentifier
            sr.Description 
        ]

    static member serialize (map: 'TErrorLog -> 'TErrorLogDTO) (sr: Assembly<ScanReport<_>>) : Assembly<ScanReportDTO<_>> = 
        {
            Name            =   sr.Name             |>  Serialize.scanReport map
            CreatedBy       =   sr.CreatedBy        |>  Serialize.scanReport map
            CreatedOn       =   sr.CreatedOn        |>  Serialize.scanReport map
            AssemblyType    =   sr.AssemblyType     |>  Serialize.scanReport map
            SheetName       =   sr.SheetName        |>  Serialize.scanReport map
            ParentName      =   sr.ParentName       |>  Serialize.scanReport map
            ChildNames      =   sr.ChildNames       |>  Serialize.scanReport map
            ExtSystem       =   sr.ExtSystem        |>  Serialize.scanReport map
            ExtObject       =   sr.ExtObject        |>  Serialize.scanReport map
            ExtIdentifier   =   sr.ExtIdentifier    |>  Serialize.scanReport map
            Description     =   sr.Description      |>  Serialize.scanReport map
        }
        
    
/// Generic representation of the 
/// COBie Attribute Excel Worksheet.
type Attribute<'TField> =
    {
        Name            :   'TField
        CreatedBy       :   'TField
        CreatedOn       :   'TField
        Category        :   'TField
        SheetName       :   'TField
        RowName         :   'TField
        Value           :   'TField
        Unit            :   'TField
        ExtSystem       :   'TField
        ExtObject       :   'TField
        ExtIdentifier   :   'TField
        Description     :   'TField
        AllowedValues   :   'TField
    }
       
    /// Produce an Attribute record 
    /// where the value for each field 
    /// is an empty generic list.
    static member empty () : Attribute<'TField list> =
        {
            Name            =   []
            CreatedBy       =   []
            CreatedOn       =   []
            Category        =   []
            SheetName       =   []
            RowName         =   []
            Value           =   []
            Unit            =   []
            ExtSystem       =   []
            ExtObject       =   []
            ExtIdentifier   =   []
            Description     =   []
            AllowedValues   =   []
        }

    /// Fetch the full set of scan reports for
    /// all fields in the Attribute worksheet.
    static member getFieldReports (sr: Attribute<ScanReport<_>>) = 
        [ 
            sr.Name
            sr.CreatedBy
            sr.CreatedOn
            sr.Category
            sr.SheetName
            sr.RowName
            sr.Value
            sr.Unit
            sr.ExtSystem
            sr.ExtObject
            sr.ExtIdentifier
            sr.Description
            sr.AllowedValues
        ]

    static member serialize (map: 'TErrorLog -> 'TErrorLogDTO) (sr: Attribute<ScanReport<_>>) : Attribute<ScanReportDTO<_>> = 
        {
            Name            =   sr.Name             |>  Serialize.scanReport map
            CreatedBy       =   sr.CreatedBy        |>  Serialize.scanReport map
            CreatedOn       =   sr.CreatedOn        |>  Serialize.scanReport map
            Category        =   sr.Category         |>  Serialize.scanReport map
            SheetName       =   sr.SheetName        |>  Serialize.scanReport map
            RowName         =   sr.RowName          |>  Serialize.scanReport map
            Value           =   sr.Value            |>  Serialize.scanReport map
            Unit            =   sr.Unit             |>  Serialize.scanReport map
            ExtSystem       =   sr.ExtSystem        |>  Serialize.scanReport map
            ExtObject       =   sr.ExtObject        |>  Serialize.scanReport map
            ExtIdentifier   =   sr.ExtIdentifier    |>  Serialize.scanReport map
            Description     =   sr.Description      |>  Serialize.scanReport map
            AllowedValues   =   sr.AllowedValues    |>  Serialize.scanReport map
        }

/// Generic representation of the 
/// COBie Component Excel Worksheet.
type Component<'TField> =
    {
        Name                :   'TField
        CreatedBy           :   'TField
        CreatedOn           :   'TField
        TypeName            :   'TField
        Space               :   'TField
        Description         :   'TField
        ExtSystem           :   'TField
        ExtObject           :   'TField
        ExtIdentifier       :   'TField
        SerialNumber        :   'TField
        InstallationDate    :   'TField
        WarrantyStartDate   :   'TField
        TagNumber           :   'TField
        BarCode             :   'TField
        AssetIdentifier     :   'TField
        Area                :   'TField
        Length              :   'TField 
    }
        
    /// Produce a Component record 
    /// where the value for each field 
    /// is an empty generic list.
    static member empty () : Component<'TField list> =
        {
            Name                =   []
            CreatedBy           =   []
            CreatedOn           =   []
            TypeName            =   []
            Space               =   []
            Description         =   []
            ExtSystem           =   []
            ExtObject           =   []
            ExtIdentifier       =   []
            SerialNumber        =   []
            InstallationDate    =   []
            WarrantyStartDate   =   []
            TagNumber           =   []
            BarCode             =   []
            AssetIdentifier     =   []
            Area                =   []
            Length              =   []
        }

    /// Fetch the full set of scan reports for
    /// all fields in the Component worksheet.
    static member getFieldReports (sr: Component<ScanReport<_>>) = 
        [ 
            sr.Name             
            sr.CreatedBy        
            sr.CreatedOn        
            sr.TypeName         
            sr.Space            
            sr.Description      
            sr.ExtSystem        
            sr.ExtObject        
            sr.ExtIdentifier    
            sr.SerialNumber     
            sr.InstallationDate 
            sr.WarrantyStartDate
            sr.TagNumber        
            sr.BarCode          
            sr.AssetIdentifier  
            sr.Area             
            sr.Length 
        ]

    static member serialize (map: 'TErrorLog -> 'TErrorLogDTO) (sr: Component<ScanReport<_>>) : Component<ScanReportDTO<_>> = 
        {
            Name                 =   sr.Name                 |>  Serialize.scanReport map 
            CreatedBy            =   sr.CreatedBy            |>  Serialize.scanReport map
            CreatedOn            =   sr.CreatedOn            |>  Serialize.scanReport map
            TypeName             =   sr.TypeName             |>  Serialize.scanReport map
            Space                =   sr.Space                |>  Serialize.scanReport map
            Description          =   sr.Description          |>  Serialize.scanReport map
            ExtSystem            =   sr.ExtSystem            |>  Serialize.scanReport map
            ExtObject            =   sr.ExtObject            |>  Serialize.scanReport map
            ExtIdentifier        =   sr.ExtIdentifier        |>  Serialize.scanReport map
            SerialNumber         =   sr.SerialNumber         |>  Serialize.scanReport map
            InstallationDate     =   sr.InstallationDate     |>  Serialize.scanReport map
            WarrantyStartDate    =   sr.WarrantyStartDate    |>  Serialize.scanReport map
            TagNumber            =   sr.TagNumber            |>  Serialize.scanReport map
            BarCode              =   sr.BarCode              |>  Serialize.scanReport map
            AssetIdentifier      =   sr.AssetIdentifier      |>  Serialize.scanReport map
            Area                 =   sr.Area                 |>  Serialize.scanReport map
            Length               =   sr.Length               |>  Serialize.scanReport map
        }
    
/// Generic representation of the 
/// COBie Connection Excel Worksheet.
type Connection<'TField> =
    {
        Name                :   'TField
        CreatedBy           :   'TField
        CreatedOn           :   'TField
        ConnectionType      :   'TField
        SheetName           :   'TField
        RowName1            :   'TField
        RowName2            :   'TField
        RealizingElement    :   'TField
        PortName1           :   'TField
        PortName2           :   'TField
        ExtSystem           :   'TField
        ExtObject           :   'TField
        ExtIdentifier       :   'TField
        Description         :   'TField
    }
        
    /// Produce a Connection record 
    /// where the value for each field 
    /// is an empty generic list.
    static member empty () : Connection<'TField list> =
        {
            Name                =   []
            CreatedBy           =   []
            CreatedOn           =   []
            ConnectionType      =   []
            SheetName           =   []
            RowName1            =   []
            RowName2            =   []
            RealizingElement    =   []
            PortName1           =   []
            PortName2           =   []
            ExtSystem           =   []
            ExtObject           =   []
            ExtIdentifier       =   []
            Description         =   []
        }

    /// Fetch the full set of scan reports for
    /// all fields in the Connection worksheet.
    static member getFieldReports (sr: Connection<ScanReport<_>>) = 
        [ 
            sr.Name            
            sr.CreatedBy       
            sr.CreatedOn       
            sr.ConnectionType  
            sr.SheetName       
            sr.RowName1        
            sr.RowName2        
            sr.RealizingElement
            sr.PortName1       
            sr.PortName2       
            sr.ExtSystem       
            sr.ExtObject       
            sr.ExtIdentifier   
            sr.Description  
        ]

    static member serialize (map: 'TErrorLog -> 'TErrorLogDTO) (sr: Connection<ScanReport<_>>) : Connection<ScanReportDTO<_>> = 
        {
            Name                 =   sr.Name                |>  Serialize.scanReport map
            CreatedBy            =   sr.CreatedBy           |>  Serialize.scanReport map
            CreatedOn            =   sr.CreatedOn           |>  Serialize.scanReport map
            ConnectionType       =   sr.ConnectionType      |>  Serialize.scanReport map
            SheetName            =   sr.SheetName           |>  Serialize.scanReport map
            RowName1             =   sr.RowName1            |>  Serialize.scanReport map
            RowName2             =   sr.RowName2            |>  Serialize.scanReport map
            RealizingElement     =   sr.RealizingElement    |>  Serialize.scanReport map
            PortName1            =   sr.PortName1           |>  Serialize.scanReport map
            PortName2            =   sr.PortName2           |>  Serialize.scanReport map
            ExtSystem            =   sr.ExtSystem           |>  Serialize.scanReport map
            ExtObject            =   sr.ExtObject           |>  Serialize.scanReport map
            ExtIdentifier        =   sr.ExtIdentifier       |>  Serialize.scanReport map
            Description          =   sr.Description         |>  Serialize.scanReport map
        }
   
/// Generic representation of the 
/// COBie Contact Excel Worksheet.
type Contact<'TField> =
    {
        Email               :   'TField
        CreatedBy           :   'TField
        CreatedOn           :   'TField
        Category            :   'TField
        Company             :   'TField
        Phone               :   'TField
        ExtSystem           :   'TField
        ExtObject           :   'TField
        ExtIdentifier       :   'TField
        Department          :   'TField
        OrganizationCode    :   'TField
        GivenName           :   'TField
        FamilyName          :   'TField
        Street              :   'TField
        PostalBox           :   'TField
        Town                :   'TField
        StateRegion         :   'TField
        PostalCode          :   'TField
        Country             :   'TField
    }
        
    /// Produce a Contact record 
    /// where the value for each field 
    /// is an empty generic list.
    static member empty () : Contact<'TField list> =
        {
            Email               =   []
            CreatedBy           =   []
            CreatedOn           =   []
            Category            =   []
            Company             =   []
            Phone               =   []
            ExtSystem           =   []
            ExtObject           =   []
            ExtIdentifier       =   []
            Department          =   []
            OrganizationCode    =   []
            GivenName           =   []
            FamilyName          =   []
            Street              =   []
            PostalBox           =   []
            Town                =   []
            StateRegion         =   []
            PostalCode          =   []
            Country             =   []
        }

    /// Fetch the full set of scan reports for
    /// all fields in the Contact worksheet.
    static member getFieldReports (sr: Contact<ScanReport<_>>) = 
        [ 
            sr.Email           
            sr.CreatedBy       
            sr.CreatedOn       
            sr.Category        
            sr.Company         
            sr.Phone           
            sr.ExtSystem       
            sr.ExtObject       
            sr.ExtIdentifier   
            sr.Department      
            sr.OrganizationCode
            sr.GivenName       
            sr.FamilyName      
            sr.Street          
            sr.PostalBox       
            sr.Town            
            sr.StateRegion     
            sr.PostalCode      
            sr.Country  
        ]

    static member serialize (map: 'TErrorLog -> 'TErrorLogDTO) (sr: Contact<ScanReport<_>>) : Contact<ScanReportDTO<_>> = 
        {
            Email                =   sr.Email                |>  Serialize.scanReport map
            CreatedBy            =   sr.CreatedBy            |>  Serialize.scanReport map
            CreatedOn            =   sr.CreatedOn            |>  Serialize.scanReport map
            Category             =   sr.Category             |>  Serialize.scanReport map
            Company              =   sr.Company              |>  Serialize.scanReport map
            Phone                =   sr.Phone                |>  Serialize.scanReport map
            ExtSystem            =   sr.ExtSystem            |>  Serialize.scanReport map
            ExtObject            =   sr.ExtObject            |>  Serialize.scanReport map
            ExtIdentifier        =   sr.ExtIdentifier        |>  Serialize.scanReport map
            Department           =   sr.Department           |>  Serialize.scanReport map
            OrganizationCode     =   sr.OrganizationCode     |>  Serialize.scanReport map
            GivenName            =   sr.GivenName            |>  Serialize.scanReport map
            FamilyName           =   sr.FamilyName           |>  Serialize.scanReport map
            Street               =   sr.Street               |>  Serialize.scanReport map
            PostalBox            =   sr.PostalBox            |>  Serialize.scanReport map
            Town                 =   sr.Town                 |>  Serialize.scanReport map
            StateRegion          =   sr.StateRegion          |>  Serialize.scanReport map
            PostalCode           =   sr.PostalCode           |>  Serialize.scanReport map
            Country              =   sr.Country              |>  Serialize.scanReport map
        }
   
/// Generic representation of the 
/// COBie Coordinate Excel Worksheet.
type Coordinate<'TField> =
    {
        Name                    :   'TField
        CreatedBy               :   'TField
        CreatedOn               :   'TField
        Category                :   'TField
        SheetName               :   'TField
        RowName                 :   'TField
        CoordinateXAxis         :   'TField
        CoordinateYAxis         :   'TField
        CoordinateZAxis         :   'TField
        ExtSystem               :   'TField
        ExtObject               :   'TField
        ExtIdentifier           :   'TField
        ClockwiseRotation       :   'TField
        ElevationalRotation     :   'TField
        YawRotation             :   'TField
    }

    /// Produce a Coordinate record 
    /// where the value for each field 
    /// is an empty generic list.
    static member empty () : Coordinate<'TField list> =
        {
            Name                    =   []
            CreatedBy               =   []
            CreatedOn               =   []
            Category                =   []
            SheetName               =   []
            RowName                 =   []
            CoordinateXAxis         =   []
            CoordinateYAxis         =   []
            CoordinateZAxis         =   []
            ExtSystem               =   []
            ExtObject               =   []
            ExtIdentifier           =   []
            ClockwiseRotation       =   []
            ElevationalRotation     =   []
            YawRotation             =   []
        }

    /// Fetch the full set of scan reports for
    /// all fields in the Coordinate worksheet.
    static member getFieldReports (sr: Coordinate<ScanReport<_>>) = 
        [ 
            sr.Name               
            sr.CreatedBy          
            sr.CreatedOn          
            sr.Category           
            sr.SheetName          
            sr.RowName            
            sr.CoordinateXAxis    
            sr.CoordinateYAxis    
            sr.CoordinateZAxis    
            sr.ExtSystem          
            sr.ExtObject          
            sr.ExtIdentifier      
            sr.ClockwiseRotation  
            sr.ElevationalRotation
            sr.YawRotation   
        ]

    static member serialize (map: 'TErrorLog -> 'TErrorLogDTO) (sr: Coordinate<ScanReport<_>>) : Coordinate<ScanReportDTO<_>> = 
        {
            Name                 =   sr.Name                    |>  Serialize.scanReport map  
            CreatedBy            =   sr.CreatedBy               |>  Serialize.scanReport map  
            CreatedOn            =   sr.CreatedOn               |>  Serialize.scanReport map  
            Category             =   sr.Category                |>  Serialize.scanReport map  
            SheetName            =   sr.SheetName               |>  Serialize.scanReport map  
            RowName              =   sr.RowName                 |>  Serialize.scanReport map  
            CoordinateXAxis      =   sr.CoordinateXAxis         |>  Serialize.scanReport map  
            CoordinateYAxis      =   sr.CoordinateYAxis         |>  Serialize.scanReport map  
            CoordinateZAxis      =   sr.CoordinateZAxis         |>  Serialize.scanReport map  
            ExtSystem            =   sr.ExtSystem               |>  Serialize.scanReport map  
            ExtObject            =   sr.ExtObject               |>  Serialize.scanReport map  
            ExtIdentifier        =   sr.ExtIdentifier           |>  Serialize.scanReport map  
            ClockwiseRotation    =   sr.ClockwiseRotation       |>  Serialize.scanReport map  
            ElevationalRotation  =   sr.ElevationalRotation     |>  Serialize.scanReport map  
            YawRotation          =   sr.YawRotation             |>  Serialize.scanReport map
        }
  
/// Generic representation of the 
/// COBie Document Excel Worksheet.
type Document<'TField> =
    {
        Name            :   'TField
        CreatedBy       :   'TField
        CreatedOn       :   'TField
        Category        :   'TField
        ApprovalBy      :   'TField
        Stage           :   'TField
        SheetName       :   'TField
        RowName         :   'TField
        Directory       :   'TField
        File            :   'TField
        ExtSystem       :   'TField
        ExtObject       :   'TField
        ExtIdentifier   :   'TField
        Description     :   'TField
        Reference       :   'TField
    }
        
    /// Produce a Document record 
    /// where the value for each field 
    /// is an empty generic list.
    static member empty () : Document<'TField list> =
        {
            Name            =   []
            CreatedBy       =   []
            CreatedOn       =   []
            Category        =   []
            ApprovalBy      =   []
            Stage           =   []
            SheetName       =   []
            RowName         =   []
            Directory       =   []
            File            =   []
            ExtSystem       =   []
            ExtObject       =   []
            ExtIdentifier   =   []
            Description     =   []
            Reference       =   []
        }

    /// Fetch the full set of scan reports for
    /// all fields in the Document worksheet.
    static member getFieldReports (sr: Document<ScanReport<_>>) = 
        [ 
            sr.Name         
            sr.CreatedBy    
            sr.CreatedOn    
            sr.Category     
            sr.ApprovalBy   
            sr.Stage        
            sr.SheetName    
            sr.RowName      
            sr.Directory    
            sr.File         
            sr.ExtSystem    
            sr.ExtObject    
            sr.ExtIdentifier
            sr.Description  
            sr.Reference 
        ]

    static member serialize (map: 'TErrorLog -> 'TErrorLogDTO) (sr: Document<ScanReport<_>>) : Document<ScanReportDTO<_>> = 
        {
            Name            =   sr.Name             |>  Serialize.scanReport map 
            CreatedBy       =   sr.CreatedBy        |>  Serialize.scanReport map
            CreatedOn       =   sr.CreatedOn        |>  Serialize.scanReport map
            Category        =   sr.Category         |>  Serialize.scanReport map
            ApprovalBy      =   sr.ApprovalBy       |>  Serialize.scanReport map
            Stage           =   sr.Stage            |>  Serialize.scanReport map
            SheetName       =   sr.SheetName        |>  Serialize.scanReport map
            RowName         =   sr.RowName          |>  Serialize.scanReport map
            Directory       =   sr.Directory        |>  Serialize.scanReport map
            File            =   sr.File             |>  Serialize.scanReport map
            ExtSystem       =   sr.ExtSystem        |>  Serialize.scanReport map
            ExtObject       =   sr.ExtObject        |>  Serialize.scanReport map
            ExtIdentifier   =   sr.ExtIdentifier    |>  Serialize.scanReport map
            Description     =   sr.Description      |>  Serialize.scanReport map
            Reference       =   sr.Reference        |>  Serialize.scanReport map
        }
    
/// Generic representation of the 
/// COBie Facility Excel Worksheet.
type Facility<'TField> =
    {
        Name                            :   'TField
        CreatedBy                       :   'TField
        CreatedOn                       :   'TField
        Category                        :   'TField
        ProjectName                     :   'TField
        SiteName                        :   'TField
        LinearUnits                     :   'TField
        AreaUnits                       :   'TField
        VolumeUnits                     :   'TField
        CurrencyUnit                    :   'TField
        AreaMeasurement                 :   'TField
        ExternalSystem                  :   'TField
        ExternalProjectObject           :   'TField
        ExternalProjectIdentifier       :   'TField
        ExternalSiteObject              :   'TField
        ExternalSiteIdentifier          :   'TField
        ExternalFacilityObject          :   'TField
        ExternalFacilityIdentifier      :   'TField
        Description                     :   'TField
        ProjectDescription              :   'TField
        SiteDescription                 :   'TField
        Phase                           :   'TField
    }

    /// Produce a Facility record 
    /// where the value for each field 
    /// is an empty generic list.
    static member empty () : Facility<'TField list> =
        {
            Name                        =   []
            CreatedBy                   =   []
            CreatedOn                   =   []
            Category                    =   []
            ProjectName                 =   []
            SiteName                    =   []
            LinearUnits                 =   []
            AreaUnits                   =   []
            VolumeUnits                 =   []
            CurrencyUnit                =   []
            AreaMeasurement             =   []
            ExternalSystem              =   []
            ExternalProjectObject       =   []
            ExternalProjectIdentifier   =   []
            ExternalSiteObject          =   []
            ExternalSiteIdentifier      =   []
            ExternalFacilityObject      =   []
            ExternalFacilityIdentifier  =   []
            Description                 =   []
            ProjectDescription          =   []
            SiteDescription             =   []
            Phase                       =   []
        }

    /// Fetch the full set of scan reports for
    /// all fields in the Facility worksheet.
    static member getFieldReports (sr: Facility<ScanReport<_>>) = 
        [ 
            sr.Name                      
            sr.CreatedBy                 
            sr.CreatedOn                 
            sr.Category                  
            sr.ProjectName               
            sr.SiteName                  
            sr.LinearUnits               
            sr.AreaUnits                 
            sr.VolumeUnits               
            sr.CurrencyUnit              
            sr.AreaMeasurement           
            sr.ExternalSystem            
            sr.ExternalProjectObject     
            sr.ExternalProjectIdentifier 
            sr.ExternalSiteObject        
            sr.ExternalSiteIdentifier    
            sr.ExternalFacilityObject    
            sr.ExternalFacilityIdentifier
            sr.Description               
            sr.ProjectDescription        
            sr.SiteDescription           
            sr.Phase 
        ]

    static member serialize (map: 'TErrorLog -> 'TErrorLogDTO) (sr: Facility<ScanReport<_>>) : Facility<ScanReportDTO<_>> = 
        {
            Name                        =   sr.Name                         |>  Serialize.scanReport map                   
            CreatedBy                   =   sr.CreatedBy                    |>  Serialize.scanReport map
            CreatedOn                   =   sr.CreatedOn                    |>  Serialize.scanReport map
            Category                    =   sr.Category                     |>  Serialize.scanReport map
            ProjectName                 =   sr.ProjectName                  |>  Serialize.scanReport map
            SiteName                    =   sr.SiteName                     |>  Serialize.scanReport map
            LinearUnits                 =   sr.LinearUnits                  |>  Serialize.scanReport map
            AreaUnits                   =   sr.AreaUnits                    |>  Serialize.scanReport map
            VolumeUnits                 =   sr.VolumeUnits                  |>  Serialize.scanReport map
            CurrencyUnit                =   sr.CurrencyUnit                 |>  Serialize.scanReport map
            AreaMeasurement             =   sr.AreaMeasurement              |>  Serialize.scanReport map
            ExternalSystem              =   sr.ExternalSystem               |>  Serialize.scanReport map
            ExternalProjectObject       =   sr.ExternalProjectObject        |>  Serialize.scanReport map
            ExternalProjectIdentifier   =   sr.ExternalProjectIdentifier    |>  Serialize.scanReport map
            ExternalSiteObject          =   sr.ExternalSiteObject           |>  Serialize.scanReport map
            ExternalSiteIdentifier      =   sr.ExternalSiteIdentifier       |>  Serialize.scanReport map
            ExternalFacilityObject      =   sr.ExternalFacilityObject       |>  Serialize.scanReport map
            ExternalFacilityIdentifier  =   sr.ExternalFacilityIdentifier   |>  Serialize.scanReport map
            Description                 =   sr.Description                  |>  Serialize.scanReport map
            ProjectDescription          =   sr.ProjectDescription           |>  Serialize.scanReport map
            SiteDescription             =   sr.SiteDescription              |>  Serialize.scanReport map
            Phase                       =   sr.Phase                        |>  Serialize.scanReport map
        }
    
/// Generic representation of the 
/// COBie Floor Excel Worksheet.
type Floor<'TField> =
    {
        Name            :   'TField
        CreatedBy       :   'TField
        CreatedOn       :   'TField
        Category        :   'TField
        ExtSystem       :   'TField
        ExtObject       :   'TField
        ExtIdentifier   :   'TField
        Description     :   'TField
        Elevation       :   'TField
        Height          :   'TField
    }

    /// Produce a Floor record 
    /// where the value for each field 
    /// is an empty generic list.
    static member empty () : Floor<'TField list> =
        {
            Name            =   []
            CreatedBy       =   []
            CreatedOn       =   []
            Category        =   []
            ExtSystem       =   []
            ExtObject       =   []
            ExtIdentifier   =   []
            Description     =   []
            Elevation       =   []
            Height          =   []
        }

    /// Fetch the full set of scan reports for
    /// all fields in the Floor worksheet.
    static member getFieldReports (sr: Floor<ScanReport<_>>) = 
        [ 
            sr.Name         
            sr.CreatedBy    
            sr.CreatedOn    
            sr.Category     
            sr.ExtSystem    
            sr.ExtObject    
            sr.ExtIdentifier
            sr.Description  
            sr.Elevation    
            sr.Height    
        ]

    static member serialize (map: 'TErrorLog -> 'TErrorLogDTO) (sr: Floor<ScanReport<_>>) : Floor<ScanReportDTO<_>> = 
        {
            Name             =   sr.Name              |>  Serialize.scanReport map 
            CreatedBy        =   sr.CreatedBy         |>  Serialize.scanReport map 
            CreatedOn        =   sr.CreatedOn         |>  Serialize.scanReport map 
            Category         =   sr.Category          |>  Serialize.scanReport map 
            ExtSystem        =   sr.ExtSystem         |>  Serialize.scanReport map 
            ExtObject        =   sr.ExtObject         |>  Serialize.scanReport map 
            ExtIdentifier    =   sr.ExtIdentifier     |>  Serialize.scanReport map 
            Description      =   sr.Description       |>  Serialize.scanReport map 
            Elevation        =   sr.Elevation         |>  Serialize.scanReport map 
            Height           =   sr.Height            |>  Serialize.scanReport map 
        }
    
/// Generic representation of the 
/// COBie Impact Excel Worksheet.
type Impact<'TField> =
    {
        Name            :   'TField
        CreatedBy       :   'TField
        CreatedOn       :   'TField
        ImpactType      :   'TField
        ImpactStage     :   'TField
        SheetName       :   'TField
        RowName         :   'TField
        Value           :   'TField
        ImpactUnit      :   'TField
        LeadInTime      :   'TField
        Duration        :   'TField
        LeadOutTime     :   'TField
        ExtSystem       :   'TField
        ExtObject       :   'TField
        ExtIdentifier   :   'TField
        Description     :   'TField
    }

    /// Produce an Impact record 
    /// where the value for each field 
    /// is an empty generic list.
    static member empty () : Impact<'TField list> =
        {
            Name            =   []
            CreatedBy       =   []
            CreatedOn       =   []
            ImpactType      =   []
            ImpactStage     =   []
            SheetName       =   []
            RowName         =   []
            Value           =   []
            ImpactUnit      =   []
            LeadInTime      =   []
            Duration        =   []
            LeadOutTime     =   []
            ExtSystem       =   []
            ExtObject       =   []
            ExtIdentifier   =   []
            Description     =   []
        }

    /// Fetch the full set of scan reports for
    /// all fields in the Impact worksheet.
    static member getFieldReports (sr: Impact<ScanReport<_>>) = 
        [ 
            sr.Name         
            sr.CreatedBy    
            sr.CreatedOn    
            sr.ImpactType   
            sr.SheetName    
            sr.RowName      
            sr.Value        
            sr.ImpactUnit   
            sr.ImpactStage  
            sr.LeadInTime   
            sr.Duration     
            sr.LeadOutTime  
            sr.ExtSystem    
            sr.ExtObject    
            sr.ExtIdentifier
            sr.Description   
        ]

    static member serialize (map: 'TErrorLog -> 'TErrorLogDTO) (sr: Impact<ScanReport<_>>) : Impact<ScanReportDTO<_>> = 
        {
            Name             =   sr.Name            |>  Serialize.scanReport map       
            CreatedBy        =   sr.CreatedBy       |>  Serialize.scanReport map
            CreatedOn        =   sr.CreatedOn       |>  Serialize.scanReport map
            ImpactType       =   sr.ImpactType      |>  Serialize.scanReport map
            SheetName        =   sr.SheetName       |>  Serialize.scanReport map
            RowName          =   sr.RowName         |>  Serialize.scanReport map
            Value            =   sr.Value           |>  Serialize.scanReport map
            ImpactUnit       =   sr.ImpactUnit      |>  Serialize.scanReport map
            ImpactStage      =   sr.ImpactStage     |>  Serialize.scanReport map
            LeadInTime       =   sr.LeadInTime      |>  Serialize.scanReport map
            Duration         =   sr.Duration        |>  Serialize.scanReport map
            LeadOutTime      =   sr.LeadOutTime     |>  Serialize.scanReport map
            ExtSystem        =   sr.ExtSystem       |>  Serialize.scanReport map
            ExtObject        =   sr.ExtObject       |>  Serialize.scanReport map
            ExtIdentifier    =   sr.ExtIdentifier   |>  Serialize.scanReport map
            Description      =   sr.Description     |>  Serialize.scanReport map
        }

/// Generic representation of the 
/// COBie Issue Excel Worksheet.
type Issue<'TField> =
    {
        Name            :   'TField
        CreatedBy       :   'TField
        CreatedOn       :   'TField
        Type            :   'TField
        Risk            :   'TField
        Chance          :   'TField
        Impact          :   'TField
        SheetName1      :   'TField
        RowName1        :   'TField
        SheetName2      :   'TField
        RowName2        :   'TField
        Description     :   'TField
        Owner           :   'TField
        Mitigation      :   'TField
        ExtSystem       :   'TField
        ExtObject       :   'TField
        ExtIdentifier   :   'TField
    }

    /// Produce an Issue record 
    /// where the value for each field 
    /// is an empty generic list.
    static member empty () : Issue<'TField list> =
        {
            Name            =   []
            CreatedBy       =   []
            CreatedOn       =   []
            Type            =   []
            Risk            =   []
            Chance          =   []
            Impact          =   []
            SheetName1      =   []
            RowName1        =   []
            SheetName2      =   []
            RowName2        =   []
            Description     =   []
            Owner           =   []
            Mitigation      =   []
            ExtSystem       =   []
            ExtObject       =   []
            ExtIdentifier   =   []
        }

    /// Fetch the full set of scan reports for
    /// all fields in the Issue worksheet.
    static member getFieldReports (sr: Issue<ScanReport<_>>) = 
        [ 
            sr.Name         
            sr.CreatedBy    
            sr.CreatedOn    
            sr.Type         
            sr.Risk         
            sr.Chance       
            sr.Impact       
            sr.SheetName1   
            sr.RowName1     
            sr.SheetName2   
            sr.RowName2     
            sr.Description  
            sr.Owner        
            sr.Mitigation   
            sr.ExtSystem    
            sr.ExtObject    
            sr.ExtIdentifier   
        ]

    static member serialize (map: 'TErrorLog -> 'TErrorLogDTO) (sr: Issue<ScanReport<_>>) : Issue<ScanReportDTO<_>> = 
        {
            Name             =   sr.Name            |>  Serialize.scanReport map
            CreatedBy        =   sr.CreatedBy       |>  Serialize.scanReport map
            CreatedOn        =   sr.CreatedOn       |>  Serialize.scanReport map
            Type             =   sr.Type            |>  Serialize.scanReport map
            Risk             =   sr.Risk            |>  Serialize.scanReport map
            Chance           =   sr.Chance          |>  Serialize.scanReport map
            Impact           =   sr.Impact          |>  Serialize.scanReport map
            SheetName1       =   sr.SheetName1      |>  Serialize.scanReport map
            RowName1         =   sr.RowName1        |>  Serialize.scanReport map
            SheetName2       =   sr.SheetName2      |>  Serialize.scanReport map
            RowName2         =   sr.RowName2        |>  Serialize.scanReport map
            Description      =   sr.Description     |>  Serialize.scanReport map
            Owner            =   sr.Owner           |>  Serialize.scanReport map
            Mitigation       =   sr.Mitigation      |>  Serialize.scanReport map
            ExtSystem        =   sr.ExtSystem       |>  Serialize.scanReport map
            ExtObject        =   sr.ExtObject       |>  Serialize.scanReport map
            ExtIdentifier    =   sr.ExtIdentifier   |>  Serialize.scanReport map
        }

/// Generic representation of the 
/// COBie Job Excel Worksheet.
type Job<'TField> =
    {
        Name            :   'TField
        CreatedBy       :   'TField
        CreatedOn       :   'TField
        Category        :   'TField
        Status          :   'TField
        TypeName        :   'TField
        Description     :   'TField
        Duration        :   'TField
        DurationUnit    :   'TField
        Start           :   'TField
        TaskStartUnit   :   'TField
        Frequency       :   'TField
        FrequencyUnit   :   'TField
        ExtSystem       :   'TField
        ExtObject       :   'TField
        ExtIdentifier   :   'TField
        TaskNumber      :   'TField
        Priors          :   'TField
        ResourceNames   :   'TField
    }

    /// Produce a Job record where 
    /// the value for each field 
    /// is an empty generic list.
    static member empty () : Job<'TField list> =
        {
            Name            =   []
            CreatedBy       =   []
            CreatedOn       =   []
            Category        =   []
            Status          =   []
            TypeName        =   []
            Description     =   []
            Duration        =   []
            DurationUnit    =   []
            Start           =   []
            TaskStartUnit   =   []
            Frequency       =   []
            FrequencyUnit   =   []
            ExtSystem       =   []
            ExtObject       =   []
            ExtIdentifier   =   []
            TaskNumber      =   []
            Priors          =   []
            ResourceNames   =   []
        }

    /// Fetch the full set of scan reports for
    /// all fields in the Job worksheet.
    static member getFieldReports (sr: Job<ScanReport<_>>) = 
        [ 
            sr.Name         
            sr.CreatedBy    
            sr.CreatedOn    
            sr.Category     
            sr.Status       
            sr.TypeName     
            sr.Description  
            sr.Duration     
            sr.DurationUnit 
            sr.Start        
            sr.TaskStartUnit
            sr.Frequency    
            sr.FrequencyUnit
            sr.ExtSystem    
            sr.ExtObject    
            sr.ExtIdentifier
            sr.TaskNumber   
            sr.Priors       
            sr.ResourceNames 
        ]

    static member serialize (map: 'TErrorLog -> 'TErrorLogDTO) (sr: Job<ScanReport<_>>) : Job<ScanReportDTO<_>> = 
        {
            Name             =   sr.Name            |>  Serialize.scanReport map     
            CreatedBy        =   sr.CreatedBy       |>  Serialize.scanReport map
            CreatedOn        =   sr.CreatedOn       |>  Serialize.scanReport map
            Category         =   sr.Category        |>  Serialize.scanReport map
            Status           =   sr.Status          |>  Serialize.scanReport map
            TypeName         =   sr.TypeName        |>  Serialize.scanReport map
            Description      =   sr.Description     |>  Serialize.scanReport map
            Duration         =   sr.Duration        |>  Serialize.scanReport map
            DurationUnit     =   sr.DurationUnit    |>  Serialize.scanReport map
            Start            =   sr.Start           |>  Serialize.scanReport map
            TaskStartUnit    =   sr.TaskStartUnit   |>  Serialize.scanReport map
            Frequency        =   sr.Frequency       |>  Serialize.scanReport map
            FrequencyUnit    =   sr.FrequencyUnit   |>  Serialize.scanReport map
            ExtSystem        =   sr.ExtSystem       |>  Serialize.scanReport map
            ExtObject        =   sr.ExtObject       |>  Serialize.scanReport map
            ExtIdentifier    =   sr.ExtIdentifier   |>  Serialize.scanReport map
            TaskNumber       =   sr.TaskNumber      |>  Serialize.scanReport map
            Priors           =   sr.Priors          |>  Serialize.scanReport map
            ResourceNames    =   sr.ResourceNames   |>  Serialize.scanReport map
        }

/// Generic representation of the 
/// COBie Space Excel Worksheet.
type Space<'TField> =
    {
        Name            :   'TField
        CreatedBy       :   'TField
        CreatedOn       :   'TField
        Category        :   'TField
        FloorName       :   'TField
        Description     :   'TField
        ExtSystem       :   'TField
        ExtObject       :   'TField
        ExtIdentifier   :   'TField
        RoomTag         :   'TField
        UsableHeight    :   'TField
        GrossArea       :   'TField
        NetArea         :   'TField
    }

    /// Produce a Space record where 
    /// the value for each field 
    /// is an empty generic list.
    static member empty () : Space<'TField list> = 
        {
            Name            =   []
            CreatedBy       =   []
            CreatedOn       =   []
            Category        =   []
            FloorName       =   []
            Description     =   []
            ExtSystem       =   []
            ExtObject       =   []
            ExtIdentifier   =   []
            RoomTag         =   []
            UsableHeight    =   []
            GrossArea       =   []
            NetArea         =   []
        }

    /// Fetch the full set of scan reports for
    /// all fields in the Space worksheet.
    static member getFieldReports (sr: Space<ScanReport<_>>) = 
        [ 
            sr.Name         
            sr.CreatedBy    
            sr.CreatedOn    
            sr.Category     
            sr.FloorName    
            sr.Description  
            sr.ExtSystem    
            sr.ExtObject    
            sr.ExtIdentifier
            sr.RoomTag      
            sr.UsableHeight 
            sr.GrossArea    
            sr.NetArea   
        ]

    static member serialize (map: 'TErrorLog -> 'TErrorLogDTO) (sr: Space<ScanReport<_>>) : Space<ScanReportDTO<_>> = 
        {
            Name             =   sr.Name             |>  Serialize.scanReport map          
            CreatedBy        =   sr.CreatedBy        |>  Serialize.scanReport map  
            CreatedOn        =   sr.CreatedOn        |>  Serialize.scanReport map  
            Category         =   sr.Category         |>  Serialize.scanReport map  
            FloorName        =   sr.FloorName        |>  Serialize.scanReport map  
            Description      =   sr.Description      |>  Serialize.scanReport map  
            ExtSystem        =   sr.ExtSystem        |>  Serialize.scanReport map  
            ExtObject        =   sr.ExtObject        |>  Serialize.scanReport map  
            ExtIdentifier    =   sr.ExtIdentifier    |>  Serialize.scanReport map  
            RoomTag          =   sr.RoomTag          |>  Serialize.scanReport map  
            UsableHeight     =   sr.UsableHeight     |>  Serialize.scanReport map  
            GrossArea        =   sr.GrossArea        |>  Serialize.scanReport map  
            NetArea          =   sr.NetArea          |>  Serialize.scanReport map  
        }
    
/// Generic representation of the 
/// COBie Spare Excel Worksheet.
type Spare<'TField> =
    {
        Name            :   'TField
        CreatedBy       :   'TField
        CreatedOn       :   'TField
        Category        :   'TField
        TypeName        :   'TField
        Suppliers       :   'TField
        ExtSystem       :   'TField
        ExtObject       :   'TField
        ExtIdentifier   :   'TField
        Description     :   'TField
        SetNumber       :   'TField
        PartNumber      :   'TField
    }

    /// Produce a Spare record where 
    /// the value for each field 
    /// is an empty generic list.
    static member empty () : Spare<'TField list> =
        {
            Name            =   []
            CreatedBy       =   []
            CreatedOn       =   []
            Category        =   []
            TypeName        =   []
            Suppliers       =   []
            ExtSystem       =   []
            ExtObject       =   []
            ExtIdentifier   =   []
            Description     =   []
            SetNumber       =   []
            PartNumber      =   []
        }

    /// Fetch the full set of scan reports for
    /// all fields in the Spare worksheet.
    static member getFieldReports (sr: Spare<ScanReport<_>>) = 
        [ 
            sr.Name         
            sr.CreatedBy    
            sr.CreatedOn    
            sr.Category     
            sr.TypeName     
            sr.Suppliers    
            sr.ExtSystem    
            sr.ExtObject    
            sr.ExtIdentifier
            sr.Description  
            sr.SetNumber    
            sr.PartNumber  
        ]

    static member serialize (map: 'TErrorLog -> 'TErrorLogDTO) (sr: Spare<ScanReport<_>>) : Spare<ScanReportDTO<_>> = 
        {
            Name             =   sr.Name            |>  Serialize.scanReport map       
            CreatedBy        =   sr.CreatedBy       |>  Serialize.scanReport map 
            CreatedOn        =   sr.CreatedOn       |>  Serialize.scanReport map 
            Category         =   sr.Category        |>  Serialize.scanReport map 
            TypeName         =   sr.TypeName        |>  Serialize.scanReport map 
            Suppliers        =   sr.Suppliers       |>  Serialize.scanReport map 
            ExtSystem        =   sr.ExtSystem       |>  Serialize.scanReport map 
            ExtObject        =   sr.ExtObject       |>  Serialize.scanReport map 
            ExtIdentifier    =   sr.ExtIdentifier   |>  Serialize.scanReport map 
            Description      =   sr.Description     |>  Serialize.scanReport map 
            SetNumber        =   sr.SetNumber       |>  Serialize.scanReport map 
            PartNumber       =   sr.PartNumber      |>  Serialize.scanReport map 
        }
    
/// Generic representation of the 
/// COBie System Excel Worksheet.
type System<'TField> =
    {
        Name            :   'TField
        CreatedBy       :   'TField
        CreatedOn       :   'TField
        Category        :   'TField
        ComponentNames  :   'TField
        ExtSystem       :   'TField
        ExtObject       :   'TField
        ExtIdentifier   :   'TField
        Description     :   'TField
    }

    /// Produce a System record where 
    /// the value for each field 
    /// is an empty generic list.
    static member empty () : System<'TField list> =
        {
            Name            =   []
            CreatedBy       =   []
            CreatedOn       =   []
            Category        =   []
            ComponentNames  =   []
            ExtSystem       =   []
            ExtObject       =   []
            ExtIdentifier   =   []
            Description     =   []
        }

    /// Fetch the full set of scan reports for
    /// all fields in the System worksheet.
    static member getFieldReports (sr: System<ScanReport<_>>) = 
        [ 
            sr.Name          
            sr.CreatedBy     
            sr.CreatedOn     
            sr.Category      
            sr.ComponentNames
            sr.ExtSystem     
            sr.ExtObject     
            sr.ExtIdentifier 
            sr.Description   
        ]

    static member serialize (map: 'TErrorLog -> 'TErrorLogDTO) (sr: System<ScanReport<_>>) : System<ScanReportDTO<_>> = 
        {
            Name             =   sr.Name             |>  Serialize.scanReport map 
            CreatedBy        =   sr.CreatedBy        |>  Serialize.scanReport map 
            CreatedOn        =   sr.CreatedOn        |>  Serialize.scanReport map 
            Category         =   sr.Category         |>  Serialize.scanReport map 
            ComponentNames   =   sr.ComponentNames   |>  Serialize.scanReport map 
            ExtSystem        =   sr.ExtSystem        |>  Serialize.scanReport map 
            ExtObject        =   sr.ExtObject        |>  Serialize.scanReport map 
            ExtIdentifier    =   sr.ExtIdentifier    |>  Serialize.scanReport map 
            Description      =   sr.Description      |>  Serialize.scanReport map 
        }
    
/// Generic representation of the 
/// COBie Resource Excel Worksheet.
type Resource<'TField> =
    {
        Name            :   'TField
        CreatedBy       :   'TField
        CreatedOn       :   'TField
        Category        :   'TField
        ExtSystem       :   'TField
        ExtObject       :   'TField
        ExtIdentifier   :   'TField
        Description     :   'TField
    }

    /// Produce a Resource record where 
    /// the value for each field 
    /// is an empty generic list.
    static member empty () : Resource<'TField list> =
        {
            Name            =   []
            CreatedBy       =   []
            CreatedOn       =   []
            Category        =   []
            ExtSystem       =   []
            ExtObject       =   []
            ExtIdentifier   =   []
            Description     =   []
        }

    /// Fetch the full set of scan reports for
    /// all fields in the Resource worksheet.
    static member getFieldReports (sr: Resource<ScanReport<_>>) = 
        [ 
            sr.Name         
            sr.CreatedBy    
            sr.CreatedOn    
            sr.Category     
            sr.ExtSystem    
            sr.ExtObject    
            sr.ExtIdentifier
            sr.Description  
        ]

    static member serialize (map: 'TErrorLog -> 'TErrorLogDTO) (sr: Resource<ScanReport<_>>) : Resource<ScanReportDTO<_>> = 
        {
            Name             =   sr.Name            |>  Serialize.scanReport map 
            CreatedBy        =   sr.CreatedBy       |>  Serialize.scanReport map 
            CreatedOn        =   sr.CreatedOn       |>  Serialize.scanReport map 
            Category         =   sr.Category        |>  Serialize.scanReport map 
            ExtSystem        =   sr.ExtSystem       |>  Serialize.scanReport map 
            ExtObject        =   sr.ExtObject       |>  Serialize.scanReport map 
            ExtIdentifier    =   sr.ExtIdentifier   |>  Serialize.scanReport map 
            Description      =   sr.Description     |>  Serialize.scanReport map 
        }
    
/// Generic representation of the 
/// COBie Type Excel Worksheet.
type Type<'TField> =
    {
        Name                        :   'TField
        CreatedBy                   :   'TField
        CreatedOn                   :   'TField
        Category                    :   'TField
        Description                 :   'TField
        AssetType                   :   'TField
        Manufacturer                :   'TField
        ModelNumber                 :   'TField
        WarrantyGuarantorParts      :   'TField
        WarrantyDurationParts       :   'TField
        WarrantyGuarantorLabor      :   'TField
        WarrantyDurationLabor       :   'TField
        WarrantyDurationUnit        :   'TField
        ExtSystem                   :   'TField
        ExtObject                   :   'TField
        ExtIdentifier               :   'TField
        ReplacementCost             :   'TField
        ExpectedLife                :   'TField
        DurationUnit                :   'TField
        WarrantyDescription         :   'TField
        NominalLength               :   'TField
        NominalWidth                :   'TField
        NominalHeight               :   'TField
        ModelReference              :   'TField
        Shape                       :   'TField
        Size                        :   'TField
        Color                       :   'TField
        Finish                      :   'TField
        Grade                       :   'TField
        Material                    :   'TField
        Constituents                :   'TField
        Features                    :   'TField
        AccessibilityPerformance    :   'TField
        CodePerformance             :   'TField
        SustainabilityPerformance   :   'TField
        Area                        :   'TField
        Length                      :   'TField
    }

    /// Produce a Type record where 
    /// the value for each field 
    /// is an empty generic list.
    static member empty () : Type<'TField list> =
        {
            Name                        =   []
            CreatedBy                   =   []
            CreatedOn                   =   []
            Category                    =   []
            Description                 =   []
            AssetType                   =   []
            Manufacturer                =   []
            ModelNumber                 =   []
            WarrantyGuarantorParts      =   []
            WarrantyDurationParts       =   []
            WarrantyGuarantorLabor      =   []
            WarrantyDurationLabor       =   []
            WarrantyDurationUnit        =   []
            ExtSystem                   =   []
            ExtObject                   =   []
            ExtIdentifier               =   []
            ReplacementCost             =   []
            ExpectedLife                =   []
            DurationUnit                =   []
            WarrantyDescription         =   []
            NominalLength               =   []
            NominalWidth                =   []
            NominalHeight               =   []
            ModelReference              =   []
            Shape                       =   []
            Size                        =   []
            Color                       =   []
            Finish                      =   []
            Grade                       =   []
            Material                    =   []
            Constituents                =   []
            Features                    =   []
            AccessibilityPerformance    =   []
            CodePerformance             =   []
            SustainabilityPerformance   =   []
            Area                        =   []
            Length                      =   []
        }

    /// Fetch the full set of scan reports for
    /// all fields in the Type worksheet.
    static member getFieldReports (sr: Type<ScanReport<_>>) = 
        [ 
            sr.Name                     
            sr.CreatedBy                
            sr.CreatedOn                
            sr.Category                 
            sr.Description              
            sr.AssetType                
            sr.Manufacturer             
            sr.ModelNumber              
            sr.WarrantyGuarantorParts   
            sr.WarrantyDurationParts    
            sr.WarrantyGuarantorLabor   
            sr.WarrantyDurationLabor    
            sr.WarrantyDurationUnit     
            sr.ExtSystem                
            sr.ExtObject                
            sr.ExtIdentifier            
            sr.ReplacementCost          
            sr.ExpectedLife             
            sr.DurationUnit             
            sr.WarrantyDescription      
            sr.NominalLength            
            sr.NominalWidth             
            sr.NominalHeight            
            sr.ModelReference           
            sr.Shape                    
            sr.Size                     
            sr.Color                    
            sr.Finish                   
            sr.Grade                    
            sr.Material                 
            sr.Constituents             
            sr.Features                 
            sr.AccessibilityPerformance 
            sr.CodePerformance          
            sr.SustainabilityPerformance
            sr.Area                     
            sr.Length   
        ]

    static member serialize (map: 'TErrorLog -> 'TErrorLogDTO) (sr: Type<ScanReport<_>>) : Type<ScanReportDTO<_>> = 
        {
            Name                         =   sr.Name                         |>  Serialize.scanReport map      
            CreatedBy                    =   sr.CreatedBy                    |>  Serialize.scanReport map 
            CreatedOn                    =   sr.CreatedOn                    |>  Serialize.scanReport map 
            Category                     =   sr.Category                     |>  Serialize.scanReport map 
            Description                  =   sr.Description                  |>  Serialize.scanReport map 
            AssetType                    =   sr.AssetType                    |>  Serialize.scanReport map 
            Manufacturer                 =   sr.Manufacturer                 |>  Serialize.scanReport map 
            ModelNumber                  =   sr.ModelNumber                  |>  Serialize.scanReport map 
            WarrantyGuarantorParts       =   sr.WarrantyGuarantorParts       |>  Serialize.scanReport map 
            WarrantyDurationParts        =   sr.WarrantyDurationParts        |>  Serialize.scanReport map 
            WarrantyGuarantorLabor       =   sr.WarrantyGuarantorLabor       |>  Serialize.scanReport map 
            WarrantyDurationLabor        =   sr.WarrantyDurationLabor        |>  Serialize.scanReport map 
            WarrantyDurationUnit         =   sr.WarrantyDurationUnit         |>  Serialize.scanReport map 
            ExtSystem                    =   sr.ExtSystem                    |>  Serialize.scanReport map 
            ExtObject                    =   sr.ExtObject                    |>  Serialize.scanReport map 
            ExtIdentifier                =   sr.ExtIdentifier                |>  Serialize.scanReport map 
            ReplacementCost              =   sr.ReplacementCost              |>  Serialize.scanReport map 
            ExpectedLife                 =   sr.ExpectedLife                 |>  Serialize.scanReport map 
            DurationUnit                 =   sr.DurationUnit                 |>  Serialize.scanReport map 
            WarrantyDescription          =   sr.WarrantyDescription          |>  Serialize.scanReport map 
            NominalLength                =   sr.NominalLength                |>  Serialize.scanReport map 
            NominalWidth                 =   sr.NominalWidth                 |>  Serialize.scanReport map 
            NominalHeight                =   sr.NominalHeight                |>  Serialize.scanReport map 
            ModelReference               =   sr.ModelReference               |>  Serialize.scanReport map 
            Shape                        =   sr.Shape                        |>  Serialize.scanReport map 
            Size                         =   sr.Size                         |>  Serialize.scanReport map 
            Color                        =   sr.Color                        |>  Serialize.scanReport map 
            Finish                       =   sr.Finish                       |>  Serialize.scanReport map 
            Grade                        =   sr.Grade                        |>  Serialize.scanReport map 
            Material                     =   sr.Material                     |>  Serialize.scanReport map 
            Constituents                 =   sr.Constituents                 |>  Serialize.scanReport map 
            Features                     =   sr.Features                     |>  Serialize.scanReport map 
            AccessibilityPerformance     =   sr.AccessibilityPerformance     |>  Serialize.scanReport map 
            CodePerformance              =   sr.CodePerformance              |>  Serialize.scanReport map 
            SustainabilityPerformance    =   sr.SustainabilityPerformance    |>  Serialize.scanReport map 
            Area                         =   sr.Area                         |>  Serialize.scanReport map 
            Length                       =   sr.Length                       |>  Serialize.scanReport map 
        }

/// Generic representation of the 
/// COBie Zone Excel Worksheet.
type Zone<'TField> =
    {
        Name            :   'TField
        CreatedBy       :   'TField
        CreatedOn       :   'TField
        Category        :   'TField
        SpaceNames      :   'TField
        ExtSystem       :   'TField
        ExtObject       :   'TField
        ExtIdentifier   :   'TField
        Description     :   'TField
    }

    /// Produce a Zone record where 
    /// the value for each field 
    /// is an empty generic list.
    static member empty () : Zone<'TField list> =
        {
            Name            =   []
            CreatedBy       =   []
            CreatedOn       =   []
            Category        =   []
            SpaceNames      =   []
            ExtSystem       =   []
            ExtObject       =   []
            ExtIdentifier   =   []
            Description     =   []
        }

    /// Fetch the full set of scan reports for
    /// all fields in the Zone worksheet.
    static member getFieldReports (sr: Zone<ScanReport<_>>) = 
        [ 
            sr.Name         
            sr.CreatedBy    
            sr.CreatedOn    
            sr.Category     
            sr.SpaceNames   
            sr.ExtSystem    
            sr.ExtObject    
            sr.ExtIdentifier
            sr.Description  
        ]

    static member serialize (map: 'TErrorLog -> 'TErrorLogDTO) (sr: Zone<ScanReport<_>>) : Zone<ScanReportDTO<_>> = 
        {
            Name             =   sr.Name             |>  Serialize.scanReport map 
            CreatedBy        =   sr.CreatedBy        |>  Serialize.scanReport map 
            CreatedOn        =   sr.CreatedOn        |>  Serialize.scanReport map 
            Category         =   sr.Category         |>  Serialize.scanReport map 
            SpaceNames       =   sr.SpaceNames       |>  Serialize.scanReport map 
            ExtSystem        =   sr.ExtSystem        |>  Serialize.scanReport map 
            ExtObject        =   sr.ExtObject        |>  Serialize.scanReport map 
            ExtIdentifier    =   sr.ExtIdentifier    |>  Serialize.scanReport map 
            Description      =   sr.Description      |>  Serialize.scanReport map 
        }
    
/// Generic representation of the 
/// complete COBie Excel Workbook.
type Workbook<'TField> =
    {
        Assembly    :   Assembly<'TField>
        Attribute   :   Attribute<'TField>
        Component   :   Component<'TField>
        Connection  :   Connection<'TField>
        Contact     :   Contact<'TField>
        Coordinate  :   Coordinate<'TField>
        Document    :   Document<'TField>
        Facility    :   Facility<'TField>
        Floor       :   Floor<'TField>
        Impact      :   Impact<'TField>
        Issue       :   Issue<'TField>
        Job         :   Job<'TField>
        Space       :   Space<'TField>
        Spare       :   Spare<'TField>
        System      :   System<'TField>
        Resource    :   Resource<'TField>
        Type        :   Type<'TField>
        Zone        :   Zone<'TField>  
    }

/// Type alias referring to the 
/// project RIBA stage.
type RIBAStage = int

/// Type alias referencing the typical
/// data captured within a single 
/// COBie field in the Excel worksheet.
type FieldData = string list

/// Configuration object specifying 
/// whether a given COBie field should
/// be captured within a scan and the
/// minimum RIBA stage at which the
/// field is required for scanning.
type FieldSettings =
    {
        Scan        :   bool
        RIBAStage   :   RIBAStage
    }
    
/// Configuration object specifying
/// the Excel worksheets that should
/// be included within the COBie scan.
type ActiveWorksheets =
    {
        Assembly        :   bool
        Attribute       :   bool
        Component       :   bool
        Connection      :   bool
        Contact         :   bool
        Coordinate      :   bool
        Document        :   bool
        Facility        :   bool
        Floor           :   bool
        Impact          :   bool
        Issue           :   bool
        Job             :   bool
        Space           :   bool
        Spare           :   bool
        System          :   bool
        Resource        :   bool
        Type            :   bool
        Zone            :   bool
    }
       
/// Complex configuration object capturing
/// the full set of worksheets that should
/// be included within the scan, alongside
/// a more granular breakdown of the 
/// scan settings on a per-field basis.
type ConfigFile =
    {
        ActiveWorksheets    :   ActiveWorksheets
        WorksheetSettings   :   Workbook<FieldSettings>
    }

/// Unique identifier to switch
/// on the various cache items.
type CacheKey =
    | ContactEmail
    | SpaceName
    | TypeName
    | ComponentName
    | FloorName
        
    /// Serializes the respective 
    /// union case to a string.
    override self.ToString () =
        match self with
        | ContactEmail  ->  "Contact.Email"
        | SpaceName     ->  "Space.Name"
        | TypeName      ->  "Type.Name"
        | ComponentName ->  "Component.Name"
        | FloorName     ->  "Floor.Name"
    
/// Captures the field data required 
/// for cross-reference validation
/// checks during the COBie scan.
type Cache =
    {
        ComponentName   :   FieldData
        ContactEmail    :   FieldData
        FloorName       :   FieldData
        SpaceName       :   FieldData
        TypeName        :   FieldData
    }
            
    /// Instantiates a fully initialized 
    /// instance of the Cache record.
    static member create (data: Workbook<FieldData>) =
        {
            ComponentName   =   data.Component.Name
            ContactEmail    =   data.Contact.Email
            FloorName       =   data.Floor.Name
            SpaceName       =   data.Space.Name
            TypeName        =   data.Type.Name
        }
            
    /// Searches for a provided string value in 
    /// the specified object cache. If the value is found
    /// in the cache then the original string is returned;
    /// otherwise, an ErrorPayload is produced.
    static member search (cache: Cache) (key: CacheKey) (value: string) : ScanResult<_> =
                
        let validateCacheResult (valueInCache: bool) = 
            match valueInCache with 
            | true -> Ok value
            | false -> Error (Error.create CrossReferenceFailure $"Item not found in {key}." value) 
    
        match key with
        | ContactEmail -> cache.ContactEmail 
        | SpaceName -> cache.SpaceName
        | TypeName -> cache.TypeName
        | ComponentName -> cache.ComponentName
        | FloorName -> cache.FloorName
        |> List.contains value
        |> validateCacheResult

/// Captures the analysis reports 
/// for all individual worksheets.
type WorkbookScanReport =
    {
        Assembly    :   ScanReport<Assembly<ScanReport<Error<string> list>>>
        Attribute   :   ScanReport<Attribute<ScanReport<Error<string> list>>>
        Component   :   ScanReport<Component<ScanReport<Error<string> list>>>
        Connection  :   ScanReport<Connection<ScanReport<Error<string> list>>>
        Contact     :   ScanReport<Contact<ScanReport<Error<string> list>>>
        Coordinate  :   ScanReport<Coordinate<ScanReport<Error<string> list>>>
        Document    :   ScanReport<Document<ScanReport<Error<string> list>>>
        Facility    :   ScanReport<Facility<ScanReport<Error<string> list>>>
        Floor       :   ScanReport<Floor<ScanReport<Error<string> list>>>
        Impact      :   ScanReport<Impact<ScanReport<Error<string> list>>>
        Issue       :   ScanReport<Issue<ScanReport<Error<string> list>>>
        Job         :   ScanReport<Job<ScanReport<Error<string> list>>>
        Space       :   ScanReport<Space<ScanReport<Error<string> list>>>
        Spare       :   ScanReport<Spare<ScanReport<Error<string> list>>>
        System      :   ScanReport<System<ScanReport<Error<string> list>>>
        Resource    :   ScanReport<Resource<ScanReport<Error<string> list>>>
        Type        :   ScanReport<Type<ScanReport<Error<string> list>>>
        Zone        :   ScanReport<Zone<ScanReport<Error<string> list>>>
    }

/// Encapuslates the over-arching
/// macro data describing the 
/// scan as a concise summary.
type ScanSummary =
    {
        FileName            :   string
        Date                :   System.DateOnly
        Time                :   System.TimeOnly
        OverallCompliance   :   ComplianceScore
        TotalErrorCount     :   ErrorCount
        TotalCellCount      :   CellCount
    }