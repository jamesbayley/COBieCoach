namespace COBieCoach.IO

open COBieCoach.Metrics
open COBieCoach.IO
open COBieCoach.COBie


/// Captures the analysis reports 
/// for all individual worksheets.
type WorkbookScanReportDTO =
    {
        Assembly    :   ScanReportDTO<Assembly<ScanReportDTO<ErrorDTO<string> list>>>
        Attribute   :   ScanReportDTO<Attribute<ScanReportDTO<ErrorDTO<string> list>>>
        Component   :   ScanReportDTO<Component<ScanReportDTO<ErrorDTO<string> list>>>
        Connection  :   ScanReportDTO<Connection<ScanReportDTO<ErrorDTO<string> list>>>
        Contact     :   ScanReportDTO<Contact<ScanReportDTO<ErrorDTO<string> list>>>
        Coordinate  :   ScanReportDTO<Coordinate<ScanReportDTO<ErrorDTO<string> list>>>
        Document    :   ScanReportDTO<Document<ScanReportDTO<ErrorDTO<string> list>>>
        Facility    :   ScanReportDTO<Facility<ScanReportDTO<ErrorDTO<string> list>>>
        Floor       :   ScanReportDTO<Floor<ScanReportDTO<ErrorDTO<string> list>>>
        Impact      :   ScanReportDTO<Impact<ScanReportDTO<ErrorDTO<string> list>>>
        Issue       :   ScanReportDTO<Issue<ScanReportDTO<ErrorDTO<string> list>>>
        Job         :   ScanReportDTO<Job<ScanReportDTO<ErrorDTO<string> list>>>
        Space       :   ScanReportDTO<Space<ScanReportDTO<ErrorDTO<string> list>>>
        Spare       :   ScanReportDTO<Spare<ScanReportDTO<ErrorDTO<string> list>>>
        System      :   ScanReportDTO<System<ScanReportDTO<ErrorDTO<string> list>>>
        Resource    :   ScanReportDTO<Resource<ScanReportDTO<ErrorDTO<string> list>>>
        Type        :   ScanReportDTO<Type<ScanReportDTO<ErrorDTO<string> list>>>
        Zone        :   ScanReportDTO<Zone<ScanReportDTO<ErrorDTO<string> list>>>
    }

/// Encapuslates the over-arching
/// macro data describing the 
/// scan as a concise summary.
type ScanSummaryDTO =
    {
        FileName            :   string
        Date                :   string
        Time                :   string
        OverallCompliance   :   string
        TotalErrorCount     :   uint
        TotalCellCount      :   uint
    }


[<RequireQualifiedAccess>]
module Serialize = 

    let scanSummary (ss: ScanSummary) : ScanSummaryDTO = 
        {
            FileName            =   ss.FileName
            Date                =   ss.Date.ToString()
            Time                =   ss.Time.ToString()
            OverallCompliance   =   ss.OverallCompliance |> ComplianceScore.unwrap
            TotalErrorCount     =   ss.TotalErrorCount   |> ErrorCount.unwrap
            TotalCellCount      =   ss.TotalCellCount    |> CellCount.unwrap
        }

    let workbookScanReport (wb: WorkbookScanReport) : WorkbookScanReportDTO = 
        {
            Assembly    =   wb.Assembly     |>  Serialize.scanReport    ( Assembly<_>.serialize     (Serialize.List.ofErrors id) )    
            Attribute   =   wb.Attribute    |>  Serialize.scanReport    ( Attribute<_>.serialize    (Serialize.List.ofErrors id) )    
            Component   =   wb.Component    |>  Serialize.scanReport    ( Component<_>.serialize    (Serialize.List.ofErrors id) )    
            Connection  =   wb.Connection   |>  Serialize.scanReport    ( Connection<_>.serialize   (Serialize.List.ofErrors id) )   
            Contact     =   wb.Contact      |>  Serialize.scanReport    ( Contact<_>.serialize      (Serialize.List.ofErrors id) )      
            Coordinate  =   wb.Coordinate   |>  Serialize.scanReport    ( Coordinate<_>.serialize   (Serialize.List.ofErrors id) )   
            Document    =   wb.Document     |>  Serialize.scanReport    ( Document<_>.serialize     (Serialize.List.ofErrors id) )     
            Facility    =   wb.Facility     |>  Serialize.scanReport    ( Facility<_>.serialize     (Serialize.List.ofErrors id) )     
            Floor       =   wb.Floor        |>  Serialize.scanReport    ( Floor<_>.serialize        (Serialize.List.ofErrors id) )        
            Impact      =   wb.Impact       |>  Serialize.scanReport    ( Impact<_>.serialize       (Serialize.List.ofErrors id) )       
            Issue       =   wb.Issue        |>  Serialize.scanReport    ( Issue<_>.serialize        (Serialize.List.ofErrors id) )        
            Job         =   wb.Job          |>  Serialize.scanReport    ( Job<_>.serialize          (Serialize.List.ofErrors id) )          
            Space       =   wb.Space        |>  Serialize.scanReport    ( Space<_>.serialize        (Serialize.List.ofErrors id) )        
            Spare       =   wb.Spare        |>  Serialize.scanReport    ( Spare<_>.serialize        (Serialize.List.ofErrors id) )        
            System      =   wb.System       |>  Serialize.scanReport    ( System<_>.serialize       (Serialize.List.ofErrors id) )       
            Resource    =   wb.Resource     |>  Serialize.scanReport    ( Resource<_>.serialize     (Serialize.List.ofErrors id) )     
            Type        =   wb.Type         |>  Serialize.scanReport    ( Type<_>.serialize         (Serialize.List.ofErrors id) )         
            Zone        =   wb.Zone         |>  Serialize.scanReport    ( Zone<_>.serialize         (Serialize.List.ofErrors id) )         
        }


[<RequireQualifiedAccess>]
module HTTP =
    
    [<Struct>]
    [<NoComparison>]
    [<StructuralEquality>]
    type Request =
        {
            Data: Workbook<FieldData>
            Configuration: ConfigFile
        }
      
    [<Struct>]
    [<NoComparison>]
    [<StructuralEquality>]
    type Response =
        {
            ScanSummary: ScanSummaryDTO
            AnalysisReport: WorkbookScanReportDTO
        }
        
        static member create (summary: ScanSummary) (report: WorkbookScanReport) =
            {
                ScanSummary     =   summary  |>  Serialize.scanSummary
                AnalysisReport  =   report   |>  Serialize.workbookScanReport
            }


[<AutoOpen>]
module EntryPoint =
   
    let runCOBieScan (data: Workbook<FieldData>) (config: ConfigFile) (rs: RIBAStage) (fileName: string) : HTTP.Response =
         let cache = Cache.create data
         
         (config, rs, data) 
         |||> Filter.workbook 
         |> Scan.workbook cache fileName
         ||> HTTP.Response.create