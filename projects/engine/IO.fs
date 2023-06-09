namespace COBieCoach.IO

open COBieCoach.Metrics
open COBieCoach.Scan
open COBieCoach.Error


/// A serializable representation
/// of the Error domain type.
type ErrorDTO<'TErrorValueDTO> = 
    {
        Category    :   string
        Message     :   string
        Value       :   'TErrorValueDTO
    }

/// A serializable representation
/// of the ScanReport domain type.
type ScanReportDTO<'TErrorLogDTO> = 
    {
        Compliance  :   string
        ErrorCount  :   uint
        CellCount   :   uint
        Errors      :   'TErrorLogDTO
    }
    

[<RequireQualifiedAccess>]
module Serialize = 

    /// Maps the Error domain type to a serializable equivalent.
    /// A custom mapping function must be provided to explicitly define the 
    /// relationship between the rich domain type and the serialized DTO.
    let error (map: 'TErrorValue -> 'TErrorValueDTO) (e: Error<'TErrorValue>) : ErrorDTO<'TErrorValueDTO> = 
        {
            Category    =   e.Category.ToString()
            Message     =   e.Message
            Value       =   e.Value |> map
        }

    /// Maps the ScanReport domain type to a serializable equivalent.
    /// A custom mapping function must be provided to explicitly define the 
    /// relationship between the error log data structure and the serialized DTO.
    let scanReport (serializeErrors: 'TErrorLog -> 'TErrorLogDTO) (sr: ScanReport<_>): ScanReportDTO<_> = 
        {
            Compliance  =   sr.Compliance   |> ComplianceScore.unwrap
            CellCount   =   sr.CellCount    |> CellCount.unwrap
            ErrorCount  =   sr.ErrorCount   |> ErrorCount.unwrap
            Errors      =   sr.Errors       |> serializeErrors
        }

    [<RequireQualifiedAccess>]
    module List = 

        // Maps a list of Errors to a serializable equivalent.
        /// A custom mapping function must be provided to explicitly define the 
        /// relationship between the rich domain type and the serialized DTO.
        let ofErrors (map: 'TErrorValue -> 'TErrorValueDTO) (errorLog: Error<_> list) : ErrorDTO<_> list = 
            errorLog |> List.map (error map)