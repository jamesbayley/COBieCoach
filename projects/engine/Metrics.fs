namespace COBieCoach.Metrics

/// Represents the number of cells, typically 
/// with reference to Excel or SQL data.
type CellCount = 

    | CellCount of uint 
 
    static member unwrap (CellCount cc) = cc

    static member (+) (left: CellCount, right: CellCount) = 
        let (CellCount left) = left
        let (CellCount right) = right 
        left + right

    static member (+) (left: uint, right: CellCount) = 
        let (CellCount right) = right 
        left + right

/// Represents the number of errors identified.
type ErrorCount = 

    | ErrorCount of uint 
 
    static member unwrap (ErrorCount ec) = ec

    static member (+) (left: ErrorCount, right: ErrorCount) = 
        let (ErrorCount left) = left
        let (ErrorCount right) = right 
        left + right

    static member (+) (left: uint, right: ErrorCount) = 
        let (ErrorCount right) = right 
        left + right

/// Describes the level of achieved compliance.
type ComplianceScore = 
    
    | ComplianceScore of string

    static member unwrap (ComplianceScore cs) = cs