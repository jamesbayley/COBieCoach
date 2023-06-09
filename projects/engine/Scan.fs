namespace COBieCoach.Scan

open COBieCoach.Error
open COBieCoach.Metrics


/// Type alias referencing the output
/// produced following Semantic validation.
type ScanResult<'T> = Result<'T, Error<'T>>

/// Validator functions accept generic  
/// arguments and compute a ScanResult.  
type Validator<'T> = 'T -> ScanResult<'T>

/// A convenient summary of the key results 
/// obtained from the validation scan.
type ScanReport<'TErrorLog> =
    {
        Compliance: ComplianceScore
        ErrorCount: ErrorCount
        CellCount: CellCount
        Errors: 'TErrorLog
    }

    /// Instantiates a fully initialized ScanReport object.
    static member create (errorLog: 'TErrorLog) cellCount errorCount complianceScore =
        {
            Compliance = complianceScore
            CellCount = cellCount
            ErrorCount = errorCount
            Errors = errorLog
        }


[<RequireQualifiedAccess>]
module Scan = 

    [<RequireQualifiedAccess>]
    module Results = 

        // Separates the errors from the scan results union type. 
        let extractErrors (results: ScanResult<_> list): Error<_> list =
            let rec extract results errs =
                match results with
                | h::t ->
                    match h with
                    | Error e -> extract t (e::errs)
                    | _ -> extract t errs
                | [] -> errs
            extract results []

        /// Produces a formatted string representing the 
        /// percentage of cells that passed the validation checks.
        let calculateCompliance (cc: CellCount) (ec: ErrorCount): ComplianceScore =
            let (CellCount cc), (ErrorCount ec) = cc, ec
            match cc with
            | x when x < 0u -> ComplianceScore "ERROR"
            | 0u -> ComplianceScore "N/A"
            | _ ->
                let cc = float cc
                let ec = float ec
                let score = 100.0 * ((cc - ec) / cc)
                ComplianceScore $"%.2f{score}%%"

        /// Converts the full raw list of ScanResult objects into 
        /// a refined summary, containing the complete list of
        /// ErrorPayloads and some useful stats about the scan.
        let createReport (results: ScanResult<_> list): ScanReport<_> =
            let errs = results |> extractErrors 
            let cellCount = uint results.Length |> CellCount
            let errCount = uint errs.Length |> ErrorCount
            let compliance = (cellCount, errCount) ||> calculateCompliance
            ScanReport.create errs cellCount errCount compliance

    [<RequireQualifiedAccess>]
    module Report = 

        [<RequireQualifiedAccess>]
        module Create = 

            /// Converts the full raw list of ScanResult objects into 
            /// a refined summary, containing the complete list of
            /// ErrorPayloads and some useful stats about the scan.
            let fromResults (results: ScanResult<_> list): ScanReport<_> =
                let errs = results |> Results.extractErrors 
                let cellCount = uint results.Length |> CellCount
                let errCount = uint errs.Length |> ErrorCount
                let compliance = (cellCount, errCount) ||> Results.calculateCompliance
                ScanReport.create errs cellCount errCount compliance
        
        [<RequireQualifiedAccess>]
        module Count = 

            /// Counts the total number of cells in a list of scan reports.
            let cells (fieldReports: ScanReport<_> list) = 
                fieldReports
                |> List.map (fun field -> field.CellCount)
                |> List.sumBy (fun (CellCount cc) -> cc) 
                |> CellCount

            /// Counts the total number of errors in a list of scan reports.
            let errors (fieldReports: ScanReport<_> list) = 
                fieldReports
                |> List.map (fun field -> field.ErrorCount) 
                |> List.sumBy (fun (ErrorCount ec) -> ec)
                |> ErrorCount

        [<RequireQualifiedAccess>]
        module Metrics = 

            let create (fieldReports: ScanReport<_> list) = 
                let cellCount   =   fieldReports |> Count.cells
                let errorCount  =   fieldReports |> Count.errors
                let compliance  =   Results.calculateCompliance cellCount errorCount
                cellCount, errorCount, compliance